using System.Threading.Tasks;
using BS.Dtos;
using BS.Services;
using Microsoft.AspNetCore.Mvc;

namespace BS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;

        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _countryService.GetAll());
        }

        

    }
}