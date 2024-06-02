using MongoDB.Driver;
using NN.Digi.Store.Domain.Constants;
using NN.Digi.Store.Domain.Repository;
using NN.Digi.Store.Infrastructure.Mongo.Collections;

namespace NN.Digi.Store.Infrastructure.Repository;

public class UserRepository(IMongoDatabase mongoDatabase) : IUserRepository
{
    public async Task CreateAsync(UserCollection doc, CancellationToken cancellationToken = default)
    {
        await mongoDatabase.GetCollection<UserCollection>(CollectionName.UserCollectionName)
            .InsertOneAsync(doc, cancellationToken: cancellationToken);
    }
}
