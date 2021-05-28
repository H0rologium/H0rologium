using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Discord;
using Discord.WebSocket;
using Discord.Commands;
using System.IO;

namespace RemoteHostManager
{
    class Program
    {

        // There is no need to implement IDisposable like before as we are
        // using dependency injection, which handles calling Dispose for us.
        static void Main()
            => new Program().MainAsync().GetAwaiter().GetResult();

        private async Task MainAsync()
        {
            // You should dispose a service provider created using ASP.NET
            // when you are finished using it, at the end of your app's lifetime.
            // If you use another dependency injection framework, you should inspect
            // its documentation for the best way to do this.
            using var services = ConfigureServices();
            var client = services.GetRequiredService<DiscordSocketClient>();
            CommandModule.SetClient(client);
            client.Log += LogAsync;
            services.GetRequiredService<CommandService>().Log += LogAsync;

            // Tokens should be considered secret data and never hard-coded.
            // If you want to use your own token make sure to use a similar text file that only has your token as its text.
            string token = File.ReadAllText("C:\\bot_token.txt");
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
            await client.SetGameAsync(("]help"), null, ActivityType.Watching);
            //You can check the UserStatus enum for all possible values.
            await client.SetStatusAsync(UserStatus.Online);
            // Here we initialize the logic required to register our commands.
            await services.GetRequiredService<CommandHandlingService>().InitializeAsync();
            await Task.Delay(-1);
        }

        private Task LogAsync(LogMessage log)
        {
            Console.WriteLine(log.ToString());

            return Task.CompletedTask;
        }

        private ServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                .AddSingleton<DiscordSocketClient>()
                .AddSingleton<CommandService>()
                .AddSingleton<CommandHandlingService>()
                .AddSingleton<HttpClient>()
                .BuildServiceProvider();
        }

    }
}
