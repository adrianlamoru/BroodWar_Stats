using System.Collections.Generic;
using System.Threading.Tasks;
using BS.Dtos;
using BS.Models;
using BS.Services;

namespace BS.Services
{
    public interface IRaceService
    {       
        Task<ServiceResponse<GetListRaceDto>> GetAll();
         
    }
}