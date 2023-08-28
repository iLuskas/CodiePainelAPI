using Codie.Painel.Application.Dtos;
using Codie.Painel.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Coddie.Painel.API.Controllers
{
    [Route("api/[controller]"), ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost, AllowAnonymous]
        public async Task<ActionResult> PostAsync([FromForm] LoginDTO loginDTO)
        {
            var result = await _userService.GetTokenByLoginAndPasswordAsync(loginDTO);

            if (result.IsSuccess)
                return Ok(result.Data);

            return BadRequest(result);
        }
    }
}
