using NN.Digi.Store.Infrastructure.Mongo.Collections;

namespace NN.Digi.Store.Domain.Repository;

public interface IUserRepository : IRepository
{
    Task CreateAsync(UserCollection doc, CancellationToken cancellationToken = default);
}
