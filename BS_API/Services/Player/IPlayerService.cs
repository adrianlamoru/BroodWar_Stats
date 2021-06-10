using System.Collections.Generic;
using System.Threading.Tasks;
using BS.Dtos;
using BS.Models;
using BS.Services;

namespace BS.Services
{
    public interface IPlayerService
    {
         Task<ServiceResponse<GetPlayerListDto>> GetAllPlayers();
         Task<ServiceResponse<GetPlayerDto>> GetPlayerById(int id);
         Task<ServiceResponse<GetPlayerDto>> NewPlayer (AddPlayerDto newPlayer);
         Task<ServiceResponse<GetPlayerDto>> UpdatePlayer(UpdatePlayerDto updatePlayer);
         Task<ServiceResponse<GetPlayerListDto>> DeletePlayer(int playerId);
    }
}