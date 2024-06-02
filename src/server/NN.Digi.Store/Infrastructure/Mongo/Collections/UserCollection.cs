using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NN.Digi.Store.Infrastructure.Mongo.Collections;

public class UserCollection
{
    [BsonId]
    public ObjectId Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string? Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
