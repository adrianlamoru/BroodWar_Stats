using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BS.Data;
using BS.Dtos;
using BS.Models;
using Microsoft.EntityFrameworkCore;
using BS.Services;

namespace BS.Data
{
    public class AuthRepository:IAuthRepository
    {
        private BSContext _context;
        public AuthRepository(BSContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<int>> Register(User user, string password )
        {
            ServiceResponse<int> serviceResponse = new ServiceResponse<int>();
            if(await UserExist(user.UserName)){
                serviceResponse.Success = false;
                serviceResponse.Message = "User already exists.";
                return serviceResponse;
            }
            
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
            serviceResponse.Data = user.UserID;
            return serviceResponse;
        }

        public async Task<bool> UserExist(string username )
        {
            if(await _context.User.AnyAsync(x => x.UserName.ToLower() == username.ToLower())){
                return true;
            }
            return false;
        }

        public async Task<ServiceResponse<string>> Login(string username, string password )
        {
           ServiceResponse<string> serviceResponse = new ServiceResponse<string>();
           User user = await _context.User.FirstOrDefaultAsync(c => c.UserName.
                                                        ToLower().Equals(username.ToLower()) );
            if(user==null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "User not found";
            }
            else if(!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "password incorrect.";
            }
            else
            {
                serviceResponse.Success = true;
                serviceResponse.Data = user.UserID.ToString();
            }
            return serviceResponse;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var  computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i =0; i < computedHash.Length;i++)
                {
                    if(computedHash[i]!=passwordHash[i])
                        return false;
                }
                return true;
            }
        }
    }
}