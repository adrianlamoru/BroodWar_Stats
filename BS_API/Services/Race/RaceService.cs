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
    public class RaceService : IRaceService
    {
        
        private BSContext _context;
        private readonly IMapper _mapper;
        
        public RaceService(IMapper mapper, BSContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<GetListRaceDto>> GetAll()
        {
            ServiceResponse<GetListRaceDto> serviceResponse = new ServiceResponse<GetListRaceDto>();
            
            try{
                
                List<Race> raceList = await _context.Race.ToListAsync();
                GetListRaceDto  getListRaceDto   = new  GetListRaceDto();
                getListRaceDto.getRacesDtos =   raceList.Select(c => _mapper.Map<GetRaceDto>(c)).ToArray();
                serviceResponse.Data = getListRaceDto;
                
                }
            
            catch(Exception ex){
               serviceResponse.Message = ex.Message;
               serviceResponse.Success = false;
            }
            return serviceResponse;
        }

       

       
    }
}