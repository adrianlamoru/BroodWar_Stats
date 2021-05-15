using System.Threading.Tasks;
using BS.Dtos;
using BS.Services;
using Microsoft.AspNetCore.Mvc;

namespace BS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;

        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _playerService.GetAllPlayers());
        }

        [HttpPost]
        public async Task<IActionResult> NewPlayer(AddPlayerDto newPlayer)
        {
            return Ok(await _playerService.NewPlayer(newPlayer));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(GetPlayerByIdDto id)
        {
            return Ok( await _playerService.GetPlayerById(id));
        }

    }
}