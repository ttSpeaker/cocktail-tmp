using System.Net.Http;
using System.Net.Http.Headers;

namespace ConsoleApp
{
    public static class ApiHelper
    {
        public static HttpClient HttpClient { get; set; }

        public static void InitializeClient()
        {
            HttpClient = new HttpClient();
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
