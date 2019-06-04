using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class SeedDb
    {
        private static readonly HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
             ProcessCategories().Wait();


            Console.ReadKey();
        }
        private static async Task ProcessCategories()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(
            //new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            //client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var stringTask = client.GetStringAsync("https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");

            var msg = await stringTask;
            Console.Write(msg);
        }
    }
}
