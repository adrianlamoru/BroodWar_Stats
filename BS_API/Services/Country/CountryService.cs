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
    public class CountryService : ICountryService
    {
        private readonly BSContext _context;
        private readonly IMapper _mapper;

        public CountryService(IMapper mapper, BSContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<GetCountryDto>> GetCountryById(GetCountryByIdDto id)
        {
            ServiceResponse<GetCountryDto> serviceResponse = new ServiceResponse<GetCountryDto>();

            try
            {
                Country country = await _context.Country.FirstOrDefaultAsync(c => c.CountryID == id.CountryID);
                serviceResponse.Data = _mapper.Map<GetCountryDto>(country);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetListCountryDto>> GetAll()
        {
            ServiceResponse<GetListCountryDto> serviceResponse = new ServiceResponse<GetListCountryDto>();

            try
            {
                List<Country> countryList = await _context.Country.ToListAsync();
                GetListCountryDto getListCountryDto = new GetListCountryDto();
                getListCountryDto.CountriesDto = countryList.Select(c => _mapper.Map<GetCountryDto>(c))
                                                                    .ToArray();
                serviceResponse.Data = getListCountryDto;
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }
    }
}