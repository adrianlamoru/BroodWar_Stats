using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BS.Data;
using BS.Dtos;
using BS.Models;
using Microsoft.EntityFrameworkCore;

namespace BS.Services
{
    public class PlayerService : IPlayerService
    {
        
        private BSContext _context;
        private readonly IMapper _mapper;
        
        public PlayerService(IMapper mapper, BSContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<GetPlayerListDto>> GetAllPlayers()
        {
            
            ServiceResponse<GetPlayerListDto> serviceResponse = new ServiceResponse<GetPlayerListDto>();
            try{

                
                List<Player> playerList = await _context.Player.ToListAsync();
                GetPlayerListDto getPlayerListDto = new GetPlayerListDto();
                getPlayerListDto.playersDto = playerList.Select(c => _mapper.Map<GetPlayerDto>(c)).ToArray();
                serviceResponse.Data = getPlayerListDto;
              }
            catch(Exception ex){
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPlayerDto>> GetPlayerById(GetPlayerByIdDto id)
        {
            ServiceResponse<GetPlayerDto> serviceResponse = new ServiceResponse<GetPlayerDto>();
            
            try{

                Player player =  await _context.Player.FirstOrDefaultAsync(c => c.PlayerID == id.PlayerID);
                serviceResponse.Data = _mapper.Map<GetPlayerDto>(player);

            }
            
            catch(Exception ex){
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPlayerDto>> NewPlayer(AddPlayerDto newPlayer)
        {
            ServiceResponse<GetPlayerDto> serviceResponse = new ServiceResponse<GetPlayerDto>();
            try{
                
                Player player = new Player();
                player.NickName = newPlayer.NickName;
                player.Name = newPlayer.Name;
                player.LastName = newPlayer.LastName;
                player.Race = await _context.Race.FirstOrDefaultAsync(c => c.RaceID == newPlayer.RaceID);
                player.Country = await _context.Country.FirstOrDefaultAsync(c => c.CountryID == newPlayer.CountryID);
                //await _context.Player.AddAsync(_mapper.Map<Player>(newPlayer));
                 await _context.Player.AddAsync(player);
                await  _context.SaveChangesAsync();
                //serviceResponse.Data = _mapper.Map<GetPlayerDto>(newPlayer);
                serviceResponse.Data = new GetPlayerDto();
                serviceResponse.Data.CountryID = player.Country.CountryID;
                serviceResponse.Data.PlayerID = player.PlayerID;
                serviceResponse.Data.RaceID = player.Race.RaceID;
                serviceResponse.Data.NickName = player.NickName;
                serviceResponse.Data.Name = player.Name;
                serviceResponse.Data.LastName = player.LastName;
               
            }
            catch(Exception ex){
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;

            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPlayerDto>> UpdatePlayer(UpdatePlayerDto updatePlayer)
        {
            ServiceResponse<GetPlayerDto> serviceResponse = new ServiceResponse<GetPlayerDto>();
            try{
                
                Player player = await _context.Player.FirstOrDefaultAsync(c => c.PlayerID == updatePlayer.PlayerID );
                player.Country= await _context.Country.FirstOrDefaultAsync(c => c.CountryID == updatePlayer.CountryID);
                player.Name = updatePlayer.Name;
                
                _context.Player.Update(player);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetPlayerDto>(updatePlayer);
                
            }
            catch(Exception ex){
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;

            }
            return serviceResponse;
        }
    }
}