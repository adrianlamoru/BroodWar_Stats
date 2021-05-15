using AutoMapper;
using BS.Dtos;
using BS.Models;

namespace BS.Profiles
{
    public class CountryProfile: Profile
    {
        public CountryProfile()
        {
            CreateMap<GetCountryDto,Country>();
            CreateMap<Country,GetCountryDto>();
        }
    }
}