using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.PracticePanther.Models
{
    public class Client
    {
        public int Id { get; set; }

        public DateTime OpenDate { get; set; }

        public DateTime CloseDate { get; set; }

        public bool IsActive { get; set; }

        public string Name { get; set; }

        public string Notes { get; set; }

        public Client()
        {
            Name = string.Empty;
            Notes = string.Empty;
        }

        public override string ToString()
        {
            return $"ID: {Id}\tName: {Name}\tOpen Date: {OpenDate}\tClosed Date: {CloseDate}\tCase Active? {IsActive}\tNotes: {Notes}";
        }
    }
}

