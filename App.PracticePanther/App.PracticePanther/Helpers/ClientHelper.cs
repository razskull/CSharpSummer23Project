using App.PracticePanther.Models;
using App.PracticePanther.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.PracticePanther.Helpers
{
    internal class ClientHelper
    {
        private ClientServices clientService = new ClientServices();
        public void CreateClient()
        {
            Console.WriteLine("What is the id of the client?");
            var id = Console.ReadLine();
            Console.WriteLine("What is the name of the client?");
            var name = Console.ReadLine();
            Console.WriteLine("What is the Open Date of the client?");
            var openDate = Console.ReadLine();
            DateTime od;
            while (!DateTime.TryParseExact(openDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out od))
            {
                Console.WriteLine("Invalid date, please retry");
                openDate = Console.ReadLine();
            }
            Console.WriteLine("What is the Closed Date of the client?");
            var closedDate = Console.ReadLine();
            DateTime cd;
            while (!DateTime.TryParseExact(closedDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out cd))
            {
                Console.WriteLine("Invalid date, please retry");
                closedDate = Console.ReadLine();
            }
            Console.WriteLine("Is the client active? (T or F)");
            var active = Console.ReadLine();
            bool a;
            if (active == "T")
            {
                a = true;
            }
            else
            {
                a = false;
            }
            Console.WriteLine("Any notes for this client?");
            var notes = Console.ReadLine();

            var client = new Client
            {
                Id = int.Parse(id ?? "0"),
                Name = name ?? string.Empty,
                OpenDate = od,
                CloseDate = cd,
                IsActive = a,
                Notes = notes ?? string.Empty
            };

            clientService.Add(client);
        }

        public void Read()
        {
            Console.WriteLine("Client List");
            clientService.Clients.ForEach(Console.WriteLine);   
        }
    }
}
