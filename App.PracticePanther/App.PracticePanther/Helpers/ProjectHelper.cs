using App.PracticePanther.Models;
using App.PracticePanther.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.PracticePanther.Helpers
{
    internal class ProjectHelper
    {
        private ProjectServices projectService = new ProjectServices();
        private ClientServices clientService;

        public ProjectHelper(ClientServices csrvc)
        {
            clientService = csrvc;
        }
        public void CreateProject(Project? selectedProject = null)
        {
            Console.WriteLine("What is the id of the project?");
            var id = Console.ReadLine();
            Console.WriteLine("What is the name of the project?");
            var name = Console.ReadLine();
            Console.WriteLine("What is the Open Date of the project? (Insert in 'MM/DD/YYYY' format)");
            var openDate = Console.ReadLine();
            DateTime od;
            while (!DateTime.TryParseExact(openDate, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out od))
            {
                Console.WriteLine("Invalid date, please retry");
                openDate = Console.ReadLine();
            }
            Console.WriteLine("What is the Closed Date of the project? (Insert in 'MM/DD/YYYY' format)");
            var closedDate = Console.ReadLine();
            DateTime cd;
            while (!DateTime.TryParseExact(closedDate, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out cd))
            {
                Console.WriteLine("Invalid date, please retry");
                closedDate = Console.ReadLine();
            }
            Console.WriteLine("Is the project active? (T or F)");
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
            Console.WriteLine("What is the short name for the project?");
            var shortName = Console.ReadLine();
            Console.WriteLine("What is the long name for the project?");
            var longName = Console.ReadLine();
            Console.WriteLine("List the ID of the client to attach them to this project");
            clientService.Clients.ForEach(Console.WriteLine);
            var select = Console.ReadLine();
            var selectId = int.Parse(select);
            var selectedClient = clientService.Clients.FirstOrDefault(c => c.Id == selectId);
            bool isCreate = false;
            if (selectedClient != null)
            {
                if (selectedProject == null)
                {
                    isCreate = true;
                    selectedProject = new Project();
                }
                selectedProject.ClientId = selectedClient.Id;
            }

            
            

            selectedProject.Id = int.Parse(id ?? "0");
            selectedProject.Name = name ?? string.Empty;
            selectedProject.OpenDate = od;
            selectedProject.CloseDate = cd;
            selectedProject.IsActive = a;
            selectedProject.ShortName = shortName ?? string.Empty;
            selectedProject.LongName = longName ?? string.Empty;

            if (isCreate)
            {
                projectService.Add(selectedProject);
            }
        }

        public void Read()
        {
            Console.WriteLine("Project List");
            projectService.Projects.ForEach(Console.WriteLine);
        }

        public void UpdateProject()
        {
            Console.WriteLine("Select a project to update:");
            Read();

            var selectProject = Console.ReadLine();

            if (int.TryParse(selectProject, out int selectInt))
            {
                var selectedProject = projectService.Projects.FirstOrDefault(s => s.Id == selectInt);
                if (selectedProject != null)
                {
                    CreateProject(selectedProject);
                }
            }
        }

        public void DeleteProject()
        {
            Console.WriteLine("Select a project to delete:");
            Read();

            var selectProject = Console.ReadLine();

            if (int.TryParse(selectProject, out int selectInt))
            {
                var selectedProject = projectService.Projects.FirstOrDefault(s => s.Id == selectInt);
                if (selectedProject != null)
                {
                    projectService.Delete(selectedProject);
                }
            }
        }
    }
}
