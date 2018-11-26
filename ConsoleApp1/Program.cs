
using ESpace;
using Microsoft.Rest;
using System;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var client = new ESpaceClient(new Uri("https://app.espace.cool"), new BasicAuthenticationCredentials());

            var result = client.EventsList.List(apiKey: "b122c266-b5db-4ceb-ae41-0370e6457417-12985", version: "v2");



            Console.ReadKey();
        }
    }
}
