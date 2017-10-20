using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace HelloWorldConsoleApp
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static string _apiAddress = ConfigurationManager.AppSettings["HelloWorld_WebAPI"];

        static void Main(string[] args)
        {
            PrintHelloWorld(); //Print hello world to the console screen via web api.
            //WriteToSystem("Hello World"); //Future implementation.           
        }

        /// <summary>
        /// Runs the get hello world from the web api.
        /// </summary>
        static void PrintHelloWorld()
        {
            RunAsyncGet().Wait();
        }

        /// <summary>
        /// Future implementation to insert text through the web api.
        /// </summary>
        static void WriteToSystem(string _value)
        {
            RunAsyncPost(_value).Wait();
        }

        static async Task RunAsyncGet()
        {
            Console.WriteLine("Making API Call...");

            //Getting our api address string from the config file.
            
            using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
            {
                //This only works on local machines, needs to be set up in a web server.
                client.BaseAddress = new Uri(_apiAddress); 

                //Getting our hello world result from the web api and checking for success status.
                HttpResponseMessage response = client.GetAsync("api/HelloWorld").Result;
                response.EnsureSuccessStatusCode();
                string result = response.Content.ReadAsStringAsync().Result;

                //Printing the hello world on the screen.
                Console.WriteLine("Result: " + result);
            }
            Console.ReadLine();
        }

        static async Task RunAsyncPost(string _val)
        {
            using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
            {
                Console.WriteLine("Writing to screen...");

                using (var client1 = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
                {
                    //This only works on local machines, needs to be set up in a web server.
                    client1.BaseAddress = new Uri(_apiAddress);
                    HttpContent c = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(_val));
                    c.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    //Getting our hello world result from the web api and checking for success status.
                    HttpResponseMessage response = client1.PostAsync("api/HelloWorld/values", c).Result;
                    response.EnsureSuccessStatusCode();
                    string result = response.Content.ReadAsStringAsync().Result;
                    //Printing the hello world on the screen.
                    Console.WriteLine("Result: " + _val + " posted successfuly");
                }
                Console.ReadLine();
            }
        }
    }
}
