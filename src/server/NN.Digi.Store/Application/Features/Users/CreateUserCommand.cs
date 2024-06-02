using MediatR;
using NN.Digi.Store.Application.Dto.Users;

namespace NN.Digi.Store.Application.Features.Users;

public class CreateUserCommand(CreateUserDto userDto) : IRequest
{
    public CreateUserDto Dto => userDto;
}
