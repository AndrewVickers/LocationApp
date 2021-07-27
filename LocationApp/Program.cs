using System;
using System.Collections.Generic;
using System.Net.Http;
using LocationAppTasks;
using LocationAppTasks.Models;

namespace LocationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            LocationAppTasks.Calculations calculations = new Calculations();
            APITasks apiTasks = new APITasks();
            Console.WriteLine("Please make your choice.  Enter either a city name, or enter a distance in miles to search from the centre of London: ");
            var input = Console.ReadLine();
            var radius = 0;
            var userList = new List<User>();

            switch (int.TryParse(input, out radius))
            {
                case true:
                    var response =  apiTasks.GetUsers().Result;
                    userList = calculations.GetLondonUsers(response, radius);
                    break;
                default:
                    userList = apiTasks.GetUsers(input).Result;
                    break;
            }

            foreach (var user in userList)
            {
                Console.WriteLine($"{user.FirstName} {user.LastName} {user.Latitude}, {user.Longitude}");
            }
        }
    }
}
