using Geolocation;
using LocationAppTasks.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LocationAppTasks
{
    public interface ICalculations
    {
        List<User> GetLondonUsers(List<User> users, int radius);
    }

    public class Calculations : ICalculations
    {
        public List<User> GetLondonUsers(List<User> users, int radius)
        {
            List<User> qualifyingUsers = new List<User>();

            Coordinate CentreOfLondon = new Coordinate(51.509865, -0.118092);

            //var users = JsonConvert.DeserializeObject<List<User>>(responseBody);

            foreach (var user in users)
            {
                Coordinate userLocation = new Coordinate(user.Latitude, user.Longitude);
                double distance = GeoCalculator.GetDistance(CentreOfLondon, userLocation, 1);
                if (distance <= radius)
                {
                    qualifyingUsers.Add(user);
                }
            }

            return qualifyingUsers;
        }
    }
}
