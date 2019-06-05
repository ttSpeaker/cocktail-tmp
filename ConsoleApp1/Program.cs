using System;
using System.Collections.Generic;
using ApiClientConsoleApp;
using Autofac;
using Cocktails.WebApi.Resources;


namespace ConsoleApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            ApiHelper.InitializeClient();
            var container = ContainerConfig.Configure();
            
            using(var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.Run();
            }

            Console.ReadKey();  
        }
    }
} 