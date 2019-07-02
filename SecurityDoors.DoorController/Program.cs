using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.BusinessLogicLayer.Implementations;
using SecurityDoors.BusinessLogicLayer.Interfaces;
using SecurityDoors.Core.StaticClasses;
using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SecurityDoors.DoorController
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Title = "DoorController Application v1.0";

			var serviceCollection = new ServiceCollection();

			serviceCollection.AddDbContext<ApplicationContext>(options =>
				options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SecurityDoorsApplication;Trusted_Connection=True;MultipleActiveResultSets=true"));

			serviceCollection.AddScoped<ICardRepository, CardRepository>();
			serviceCollection.AddScoped<IDoorRepository, DoorRepository>();
			serviceCollection.AddScoped<IDoorPassingRepository, DoorPassingRepository>();
			serviceCollection.AddScoped<IPersonRepository, PersonRepository>();
			serviceCollection.AddScoped<DataManager>();

			var serviceProvider = serviceCollection.BuildServiceProvider();
			var dataManagerService = serviceProvider.GetService<DataManager>();

			var mainController = new MainController(dataManagerService);

			CLIColor.WriteInfo("Welcome to the door controller application!\n");

			Console.Write("Please enter IP Address: ");
			var ipAddress = Console.ReadLine();

			Console.Write("Please enter port number: ");
			var valuePort = Console.ReadLine();
			Int32.TryParse(valuePort, out int port); // TODO: Реализовать проверку на диапазон и если значение не цифра

			var GUID = Guid.NewGuid().ToString();
			Console.WriteLine($"Secret key to work with door controller: {GUID}\n");
			Console.Write("All configurations successfully loaded! Waiting for a connection... \n\n");

			TcpListener server = null;

			IPAddress localAddr = IPAddress.Parse(ipAddress);
			server = new TcpListener(localAddr, port);
			server.Start();

			byte[] bytes = new byte[256];
			string data = null;

			while (true)
			{
                try
                {
                    TcpClient client = server.AcceptTcpClient();

				data = null;
				var stream = client.GetStream();
				int length = stream.Read(bytes, 0, bytes.Length);

				data = Encoding.UTF8.GetString(bytes, 0 , length);

				var words = data.Split('$'); // Разделительный символ
				var guid_accept = words[0] == GUID;
				var card = words[1];
				var door = words[2];

				if (guid_accept)
				{

					#region Эмуляция дверного контроллера

					// TODO: Рефакторинг и в отдельный метод / класс.

					Console.Write(string.Format("| {0,15} |", card) +
							string.Format(" {0,10} |", door));

					var result = mainController.ControllerАctuationAsync(card, door).Result;

					if (result.Item2)
					{
						var resultString = "OPERATION SUCCEEDED";
						Console.Write(string.Format("{0,25}", result.Item1) +
										string.Format("| {0,20} |", resultString));

						data = "200 OK";
					}
					else
					{
						var resultString = "OPERATION ERROR";
						Console.Write(string.Format("{0,25}", result.Item1) +
										string.Format("| {0,20} |", resultString));

						data = "404 Not Found";
					}

					Console.WriteLine();

					#endregion
				}
				else
				{
					data = "406 Not Acceptable";
				}

				var msg = Encoding.ASCII.GetBytes(data);
				stream.Write(msg, 0, msg.Length);
				client.Close();
                }
                catch (SocketException e)
                {
                    Console.WriteLine($"SocketException: {e}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception: {e.Message}");
                }
            }
		}
	}
}
