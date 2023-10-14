using blazorApp.Services;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace blazorApp.Extensions
{
    public static class StartUp
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7213/") });
            services.TryAddScoped<APIService, APIService>();

            services.AddScoped(sp => new HubConnectionBuilder()
                .WithUrl("https://localhost:7213/signalhub")
                .Build());
            services.TryAddScoped<SignalRService, SignalRService>();

            return services;
        }

        //    public static Task addHubConnection()
        //{
        //    var connection = new HubConnectionBuilder()
        //        .WithUrl("https://localhost:7213/signalhub")
        //        .Build();

        //    connection.On<string>("newCar", (message) =>
        //    {
        //        System.Console.WriteLine(message);
        //    });
                
        //     return connection.StartAsync().WaitAsync(CancellationToken.None);
        //}
    }
}
