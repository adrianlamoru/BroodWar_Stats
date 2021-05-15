using AutoMapper;
using BS.Dtos;
using BS.Models;

namespace BS.Profiles
{
    public class RaceProfile: Profile
    {
        public RaceProfile()
        {
            CreateMap<GetRaceDto,Race>();
            CreateMap<Race,GetRaceDto>();
        }
    }
}