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
       
        public async void Run()
        {
            //Console.WriteLine("Load Categories");
            //await _consoleService.Categories();
            //Console.WriteLine("Done Categories");

            //Console.WriteLine("Load Ingredients");
            //await _consoleService.Ingredients();
            //Console.WriteLine("Done Ingredients");

            Console.WriteLine("run get cocktails");
            await _consoleService.Cocktails();
        }
    }
}
