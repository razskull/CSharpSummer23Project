using App.PracticePanther.Models;
using App.PracticePanther.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace App.PracticePanther.Helpers
{
    internal class ClientHelper
    {
        private ClientServices clientService = new ClientServices();
        public void CreateClient(Client? selectedClient = null)
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

            bool isCreate = false;
            if(selectedClient == null)
            {
                isCreate = true;
                selectedClient = new Client();
            }

            selectedClient.Id = int.Parse(id ?? "0");
            selectedClient.Name = name ?? string.Empty;
            selectedClient.OpenDate = od;
            selectedClient.CloseDate = cd;
            selectedClient.IsActive = a;
            selectedClient.Notes = notes ?? string.Empty;

            if (isCreate)
            {
                clientService.Add(selectedClient);
            }
        }

        public void Read()
        {
            Console.WriteLine("Client List");
            clientService.Clients.ForEach(Console.WriteLine);   
        }

        public void UpdateClients()
        {
            Console.WriteLine("Select a client to update:");
            Read();

            var selectClient = Console.ReadLine();

            if(int.TryParse(selectClient, out int selectInt))
            {
                var selectedClient = clientService.Clients.FirstOrDefault(s => s.Id == selectInt);
                if(selectedClient != null)
                {
                    CreateClient(selectedClient);
                }
            }
        }

        public void DeleteClient()
        {
            Console.WriteLine("Select a client to delete:");
            Read();

            var selectClient = Console.ReadLine();

            if (int.TryParse(selectClient, out int selectInt))
            {
                var selectedClient = clientService.Clients.FirstOrDefault(s => s.Id == selectInt);
                if (selectedClient != null)
                {
                    clientService.Delete(selectedClient);
                }
            }
        }
    }
}
