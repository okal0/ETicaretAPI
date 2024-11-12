using ETicaretAPI.Application.Features.Commands.AppUser.CreateUser;
using ETicaretAPI.Application.Features.Commands.AppUser.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class UsersController : ControllerBase
    {
        readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserRequest)
        {
            CreateUserCommandResponse response = await _mediator.Send(createUserRequest);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginUserCommandRequest loginUserRequest)
        {
            LoginUserCommandResponse response = await _mediator.Send(loginUserRequest);
            return Ok(response);
        }
    }
}
