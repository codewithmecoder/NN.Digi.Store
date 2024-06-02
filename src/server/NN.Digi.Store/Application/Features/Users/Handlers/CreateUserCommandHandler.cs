using MediatR;
using MongoDB.Bson;
using NN.Digi.Store.Domain.Repository;
using NN.Digi.Store.Infrastructure.Mongo.Collections;

namespace NN.Digi.Store.Application.Features.Users.Handlers;

public class CreateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<CreateUserCommand>
{
    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var r = request.Dto;

        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(r.Password);

        await userRepository.CreateAsync(new UserCollection
        {
            CreatedAt = DateTime.UtcNow,
            Email = r.Email,
            Id = ObjectId.GenerateNewId(),
            Name = "",
            Password = hashedPassword,
            UpdatedAt = DateTime.UtcNow,
        }, cancellationToken);
    }
}
