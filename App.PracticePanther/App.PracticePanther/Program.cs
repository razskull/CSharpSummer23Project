﻿using System;
using App.PracticePanther.Models;
using App.PracticePanther.Helpers;
using App.PracticePanther.Services;

namespace App.PracticePanther// Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var clientSvrc = new ClientServices();
            var clientHelper = new ClientHelper(clientSvrc);
            var projectHelper = new ProjectHelper(clientSvrc);
            bool cont = true;

            while (cont)
            {
                Console.WriteLine("Choose an Action:");
                Console.WriteLine("1. Add Client");
                Console.WriteLine("2. Print Client List");
                Console.WriteLine("3. Update Client List");
                Console.WriteLine("4. Delete Client");
                Console.WriteLine("5. Add Project");
                Console.WriteLine("6. Print Project List");
                Console.WriteLine("7. Update Project List");
                Console.WriteLine("8. Delete Project");
                Console.WriteLine("9. Exit");
                var input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                {

                    if (result == 1)
                    {
                        clientHelper.CreateClient();
                    }
                    else if (result == 2)
                    {
                        clientHelper.Read();
                    }
                    else if (result == 3)
                    {
                        clientHelper.UpdateClients();
                    }
                    else if (result == 4)
                    {
                        clientHelper.DeleteClient();
                    }
                    else if (result == 5)
                    {
                        projectHelper.CreateProject();
                    }
                    else if (result == 6)
                    {
                        projectHelper.Read();
                    }
                    else if (result == 7)
                    {
                        projectHelper.UpdateProject();
                    }
                    else if (result == 8)
                    {
                        projectHelper.DeleteProject();
                    }
                    else if (result == 9)
                    {
                        cont = false;
                    }
                }
            }
            
        }
    }
}

