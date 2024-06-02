using MediatR;
using Microsoft.AspNetCore.Mvc;
using NN.Digi.Store.Application.Dto.Users;
using NN.Digi.Store.Application.Features.Users;

namespace NN.Digi.Store.Controllers;

public class UserController(IMediator mediator) :  BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userDto)
    {
        await mediator.Send(new CreateUserCommand(userDto));
        return Ok();
    }
}
