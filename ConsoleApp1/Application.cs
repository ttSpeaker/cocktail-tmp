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
            _consoleService.Categories();
            _consoleService.Ingredients();
        }
    }
}
