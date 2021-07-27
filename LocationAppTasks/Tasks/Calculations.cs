using System.Collections.Generic;
using Geolocation;
using LocationAppTasks.Models;

namespace LocationAppTasks.Tasks
{
    public interface ICalculations
    {
        List<User> GetLondonUsers(IList<User> users, int radius);
    }

    public class Calculations : ICalculations
    {
        public List<User> GetLondonUsers(IList<User> users, int radius)
        {
            List<User> qualifyingUsers = new List<User>();

            Coordinate CentreOfLondon = new Coordinate(51.509865, -0.118092);

            //var users = JsonConvert.DeserializeObject<List<User>>(responseBody);

            foreach (var user in users)
            {
                Coordinate userLocation = new Coordinate(user.Latitude, user.Longitude);
                double distance = GeoCalculator.GetDistance(CentreOfLondon, userLocation, 1);
                user.Distance = distance;
                if (distance <= radius)
                {
                    qualifyingUsers.Add(user);
                }
            }

            return qualifyingUsers;
        }
    }
}
