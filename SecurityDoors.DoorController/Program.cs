using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.BusinessLogicLayer.Implementations;
using SecurityDoors.BusinessLogicLayer.Interfaces;
using SecurityDoors.DataAccessLayer.Models;

namespace SecurityDoors.DoorController
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Продумать возможность поделения контроллера на моделирование и реальную ситуацию

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

            Console.WriteLine("Welcom to the door controller application!\n");

            Console.Write("Please enter IP Address: ");
            var ipAddress = Console.ReadLine();

            Console.Write("Please port number: ");
            var valuePort = Console.ReadLine();
            Int32.TryParse(valuePort, out int port); // TODO: Реализовать проверку на диапазон и если значение не цифра

            var GUID = Guid.NewGuid().ToString();
            Console.WriteLine($"Secret key to work with door controller: {GUID}\n"); // TODO: Реализовать проверку на GUID при приёме сообщения
            Console.Write("All configurations successfully loaded! Waiting for a connection... \n\n");

            TcpListener server = null;

            try
            {
                IPAddress localAddr = IPAddress.Parse(ipAddress);
                server = new TcpListener(localAddr, port);
                server.Start();

                var bytes = new Byte[256];
                string data = null;

                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();

                    data = null;
                    var stream = client.GetStream();

                    int i;

                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        data = Encoding.ASCII.GetString(bytes, 0, i);

                        var words = data.Split('$'); // Разделительный символ
                        var card = words[0];
                        var door = words[1];

                        #region Эмуляция дверного контроллера

                        // TODO: Рефакторинг и в отдельный метод / класс.

                        Console.Write(string.Format("| {0,15} |", card) +
                              string.Format(" {0,10} |", door));

                        var result = mainController.ControllerАctuation(card, door);

                        if (result.Item2)
                        {
                            var resultString = "OPERATION SUCCEEDED";
                            Console.Write(string.Format("{0,25}", result.Item1) +
                                          string.Format("| {0,20} |", resultString));
                        }
                        else
                        {
                            var resultString = "OPERATION ERROR";
                            Console.Write(string.Format("{0,25}", result.Item1) +
                                          string.Format("| {0,20} |", resultString));
                        }

                        Console.WriteLine();

                        #endregion

                        data = "200 OK";

                        var msg = Encoding.ASCII.GetBytes(data);
                        stream.Write(msg, 0, msg.Length);
                    }

                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine($"SocketException: {e}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
            }
            finally
            {
                if (server != null)
                {
                    server.Stop();
                }      
            }

            Console.ReadLine();
        }
    }
}
