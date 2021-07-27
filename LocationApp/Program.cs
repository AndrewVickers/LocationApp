using System;
using System.Collections.Generic;
using System.Net.Http;
using LocationAppTasks;
using LocationAppTasks.Models;
using LocationAppTasks.Tasks;

namespace LocationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculations calculations = new Calculations();
            Api api = new Api();
            Console.WriteLine("Please make your choice.  Enter either a city name, or enter a distance in miles to search from the centre of London: ");
            var input = Console.ReadLine();
            var radius = 0;
            var userList = new List<User>();

            switch (int.TryParse(input, out radius))
            {
                case true:
                    var response =  api.GetUsers().Result;
                    userList = calculations.GetLondonUsers(response, radius);
                    break;
                default:
                    userList = api.GetUsers(input).Result;
                    break;
            }

            foreach (var user in userList)
            {
                Console.WriteLine($"{user.FirstName} {user.LastName} Distance:{user.Distance} {user.Latitude}, {user.Longitude}");
            }
        }
    }
}
