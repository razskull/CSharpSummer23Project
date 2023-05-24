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
            var clientHelper = new ClientHelper();
            bool cont = true;

            while (cont)
            {
                Console.WriteLine("Choose an Action:");
                Console.WriteLine("1. Add Client");
                Console.WriteLine("2. Print List");
                Console.WriteLine("3. Exit");
                var input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                {

                    if (result == 1)
                    {
                        clientHelper.CreateClient();
                    }else if(result == 2)
                    {
                        clientHelper.Read();
                    }else if( result == 3)
                    {
                        cont = false;
                    }
                }
            }
            
        }
    }
}

