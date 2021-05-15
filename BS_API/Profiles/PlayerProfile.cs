using AutoMapper;
using BS.Dtos;
using BS.Models;

namespace BS.Profiles
{
    public class PlayerProfile: Profile
    {
        public PlayerProfile()
        {
            CreateMap<Player, GetPlayerDto>();
            CreateMap<AddPlayerDto, Player>();
            CreateMap<GetPlayerDto, UpdatePlayerDto>();
        }
    }
}