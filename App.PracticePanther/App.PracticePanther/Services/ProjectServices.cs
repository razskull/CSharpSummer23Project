using App.PracticePanther.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.PracticePanther.Services
{
    public class ProjectServices
    {
        public List<Project> projectList = new List<Project>();
        

        public void Add(Project project)
        {
            projectList.Add(project);
        }

        public List<Project> Projects
        {
            get
            {
                return projectList;
            }
        }

        public void Delete(Project project)
        {
            projectList.Remove(project);
        }
    }
}
