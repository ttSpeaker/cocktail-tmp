using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClientConsoleApp
{
    public class Application : IApplication
    {
        private IConsoleService _consoleService;

        public Application(IConsoleService consoleService)
        {
            _consoleService = consoleService;
        }
       
        public void Run()
        {
            //Console.WriteLine("Load Categories");
            //_consoleService.Categories();
            //Console.WriteLine("Done Categories");

            //Console.WriteLine("Load Ingredients");
            //_consoleService.Ingredients();
            //Console.WriteLine("Done Ingredients");

            Console.WriteLine("Run Get Cocktails");
            _consoleService.Cocktails();
        }
    }
}
