using App.PracticePanther.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.PracticePanther.Services
{
    public class ClientServices
    {
        public List<Client> clientList = new List<Client>();

        public void Add(Client client)
        {
            clientList.Add(client);
        }
    }
}
