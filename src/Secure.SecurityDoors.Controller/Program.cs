using Microsoft.Extensions.DependencyInjection;
using Secure.SecurityDoors.Controller.Interfaces;
using Secure.SecurityDoors.Controller.Resources;
using Secure.SecurityDoors.Controller.Services;
using Secure.SecurityDoors.Shared.Contracts.Requests;
using System;

namespace Secure.SecurityDoors.Controller
{
    class Program
    {
        static void Main(string[] args)
        {
            var requestService = GetServiceProvider()
                .GetRequiredService<IRequestService>();

            var url = ConsoleInput("url"); // "https://localhost:5003/api";
            var segment = ConsoleInput("segment"); // "passage";
            var doorReaderSerialNumber = ConsoleInput("door reader serial number");

            while (true)
            {
                Console.WriteLine();

                var request = new PassageRequest
                {
                    CardUniqueNumber = ConsoleInput("card unique number"),
                    DoorReaderSerialNumber = doorReaderSerialNumber,
                };

                var message = requestService
                    .SendAsync(
                        request,
                        url,
                        new string[] { segment })
                    .GetAwaiter()
                    .GetResult();

                Console.WriteLine(message);

                if (!Question())
                {
                    return;
                }
            }
        }

        private static ServiceProvider GetServiceProvider() =>
            new ServiceCollection()
                .AddScoped<IRequestService, RequestService>()
                .BuildServiceProvider();

        private static string ConsoleInput(string type)
        {
            Console.Write(string.Format(MessageResource.QuestionEnter, type));
            return Console.ReadLine();
        }

        private static bool Question()
        {
            const string actionСancellation = "n";

            Console.Write(MessageResource.QuestionContinue);
            var userInput = Console.ReadLine();
            return !string.IsNullOrWhiteSpace(userInput) && userInput.ToLower() != actionСancellation;
        }
    }
}
