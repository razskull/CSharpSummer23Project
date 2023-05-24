using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.PracticePanther.Models
{
    public class Project
    {
        public int Id { get; set; }

        public DateTime OpenDate { get; set; }

        public DateTime CloseDate { get; set; }

        public bool IsActive { get; set; }

        public string ShortName { get; set; }

        public string LongName { get; set; }

        public string Name { get; set; }

        public int ClientId { get; set; }

        public Project()
        {
            Name = string.Empty;
            ShortName = string.Empty;
            LongName = string.Empty;
        }

    }
}