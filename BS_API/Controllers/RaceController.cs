using System.Threading.Tasks;
using BS.Dtos;
using BS.Services;
using Microsoft.AspNetCore.Mvc;

namespace BS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RaceController : ControllerBase
    {
        private readonly IRaceService _raceService;

        public RaceController(IRaceService raceService)
        {
            _raceService = raceService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _raceService.GetAll());
        }
    }
}