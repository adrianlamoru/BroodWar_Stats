using System.Threading.Tasks;
using BS.Dtos;
using BS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BS.API.Helpers;

namespace BS.Controllers
{
    //[Authorize(Roles = "Player")]
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery]PlayerParams param)
        {
            return Ok(await _playerService.GetAllPlayers(param));
        }

        [HttpPost]
        public async Task<IActionResult> NewPlayer(AddPlayerDto newPlayer)
        {
            return Ok(await _playerService.NewPlayer(newPlayer).ConfigureAwait(false)); // .ConfigureAwait(false) optional just for no to show linter error
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _playerService.GetPlayerById(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponse<GetPlayerListDto> response = await _playerService.DeletePlayer(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePLayer(UpdatePlayerDto id)
        {
            return Ok(await _playerService.UpdatePlayer(id));
        }
    }
}