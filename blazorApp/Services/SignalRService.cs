using Microsoft.AspNetCore.SignalR.Client;

namespace blazorApp.Services
{
    public class SignalRService
    {
        private readonly HubConnection hubConnection;

        public EventHandler<string> messageRecived;

        public SignalRService(HubConnection hubConnection)
        {
            this.hubConnection = hubConnection;

            this.hubConnection.On<string>("newCar", (message) =>
            {
                messageRecived?.Invoke(this, message);
            });

            this.hubConnection.On<string>("Send", (message) =>
            {
                messageRecived?.Invoke(this, message);
            });

            this.hubConnection.StartAsync().WaitAsync(CancellationToken.None);
        }

        public async Task SendMessage(string message)
        {
            this.hubConnection.SendCoreAsync("SendAll", new[] { message });
        }
    }
}
