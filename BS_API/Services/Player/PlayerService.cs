using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BS.API.Helpers;
using BS.Data;
using BS.Dtos;
using BS.Models;
using Microsoft.EntityFrameworkCore;

namespace BS.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly BSContext _context;
        private readonly IMapper _mapper;

        public PlayerService(IMapper mapper, BSContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<GetPlayerListDto>> GetAllPlayers(PlayerParams param)
        {
            ServiceResponse<GetPlayerListDto> serviceResponse = new ServiceResponse<GetPlayerListDto>();
            try
            {
                List<Player> playerList = await _context.Player.Include(c => c.Country)
                                                               .Include(c => c.Race)
                                                               .OrderBy(c => c.NickName)
                                                               .Skip((param.PageNumber - 1) * param.PageSize)
                                                               .Take(param.PageSize)
                                                               .ToListAsync();
                GetPlayerListDto getPlayerListDto = new GetPlayerListDto();
                List<GetPlayerDto> getPlayerDtoList = new List<GetPlayerDto>();
                foreach (Player item in playerList)
                {
                    GetPlayerDto getPlayerDto = new GetPlayerDto
                    {
                        CountryID = item.Country.CountryID,
                        LastName = item.LastName,
                        Name = item.Name,
                        NickName = item.NickName,
                        PlayerID = item.PlayerID,
                        RaceID = item.Race.RaceID,
                        Age = item.Age
                    };
                    getPlayerDtoList.Add(getPlayerDto);
                }
                //getPlayerListDto.playersDto = playerList.Select(c => _mapper.Map<GetPlayerDto>(c)).ToArray();
                getPlayerListDto.playersDto = getPlayerDtoList.ToArray();
                serviceResponse.Data = getPlayerListDto;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPlayerDto>> GetPlayerById(int id)
        {
            ServiceResponse<GetPlayerDto> serviceResponse = new ServiceResponse<GetPlayerDto>();

            try
            {
                Player player = await _context.Player.Include(x => x.Country)
                                                     .Include(y => y.Race)
                                                     .FirstOrDefaultAsync(c => c.PlayerID == id);
                serviceResponse.Data = _mapper.Map<GetPlayerDto>(player);
                serviceResponse.Data.CountryID = player.Country.CountryID;
                serviceResponse.Data.RaceID = player.Race.RaceID;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPlayerDto>> NewPlayer(AddPlayerDto newPlayer)
        {
            ServiceResponse<GetPlayerDto> serviceResponse = new ServiceResponse<GetPlayerDto>();
            try
            {
                Player player = new Player
                {
                    NickName = newPlayer.NickName,
                    Name = newPlayer.Name,
                    LastName = newPlayer.LastName,
                    Race = await _context.Race.FirstOrDefaultAsync(c => c.RaceID == newPlayer.RaceID),
                    Country = await _context.Country.FirstOrDefaultAsync(c => c.CountryID == newPlayer.CountryID),
                    Age = newPlayer.Age
                };
                //await _context.Player.AddAsync(_mapper.Map<Player>(newPlayer));
                await _context.Player.AddAsync(player);
                await _context.SaveChangesAsync();
                //serviceResponse.Data = _mapper.Map<GetPlayerDto>(newPlayer);
                serviceResponse.Data = new GetPlayerDto();
                serviceResponse.Data.CountryID = player.Country.CountryID;
                serviceResponse.Data.PlayerID = player.PlayerID;
                serviceResponse.Data.RaceID = player.Race.RaceID;
                serviceResponse.Data.NickName = player.NickName;
                serviceResponse.Data.Name = player.Name;
                serviceResponse.Data.LastName = player.LastName;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPlayerDto>> UpdatePlayer(UpdatePlayerDto updatePlayer)
        {
            ServiceResponse<GetPlayerDto> serviceResponse = new ServiceResponse<GetPlayerDto>();
            try
            {
                Player player = await _context.Player.FirstOrDefaultAsync(c => c.PlayerID == updatePlayer.PlayerID);
                player.Country = await _context.Country.FirstOrDefaultAsync(c => c.CountryID == updatePlayer.CountryID);
                player.Race = await _context.Race.FirstOrDefaultAsync(c => c.RaceID == updatePlayer.RaceID);
                player.Name = updatePlayer.Name;
                player.NickName = updatePlayer.NickName;
                player.Age = updatePlayer.Age;
                player.LastName = updatePlayer.LastName;

                _context.Player.Update(player);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetPlayerDto>(player);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPlayerListDto>> DeletePlayer(int playerId)
        {
            ServiceResponse<GetPlayerListDto> serviceResponse = new ServiceResponse<GetPlayerListDto>();
            try
            {
                Player player = await _context.Player.FirstOrDefaultAsync(c => c.PlayerID == playerId);

                _context.Player.Remove(player);
                await _context.SaveChangesAsync();
               // serviceResponse = this.GetAllPlayers().Result;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}