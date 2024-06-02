using MongoDB.Driver;
using NN.Digi.Store.Domain;

namespace NN.Digi.Store.Infrastructure.Mongo;

public static class Extensions
{
    public static IServiceCollection AddMongo(this IServiceCollection services, ApplicationSetting setting)
    {
        var mongoSetting = setting.MongoConnection;
        string url;
        if (string.IsNullOrEmpty(setting.MongoConnection.UserName) || string.IsNullOrEmpty(setting.MongoConnection.Password))
        {
            //mongodb://localhost:27017
            url = $"mongodb://{mongoSetting.Host}:{mongoSetting.Port}";
        }
        else
        {
            url = $"mongodb://{mongoSetting.UserName}:{mongoSetting.Password}{mongoSetting.Host}:{mongoSetting.Port}";
        }

        var mongoClient = new MongoClient(url);
        var mongoDatabase = mongoClient.GetDatabase(mongoSetting.DatabaseName);
        services.AddScoped(provider => mongoDatabase);
        return services;
    }
}
