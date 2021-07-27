using LocationAppTasks.Models;
using LocationAppTasks.Tasks;
using System.Collections.Generic;
using Xunit;

namespace LocationAppTests
{
    public class CalculationTasksShould
    {
        private readonly ICalculations _sut;
        private readonly IList<User> _userList;
        private readonly User _actualLondonUser;
        private readonly User _registeredLondonUser;

        public CalculationTasksShould()
        {
            _sut = new Calculations();
            _registeredLondonUser =
                new User()
                {
                    Email = "smapstonei9@bandcamp.com",
                    FirstName = "Stephen",
                    LastName = "Mapstone",
                    IPAddress = "187.79.141.124",
                    Latitude = -8.1844859,
                    Longitude = 113.6680747
                };
            _actualLondonUser =
                new User()
                {
                    Email = "hlynd8x@merriam-webster.com",
                    FirstName = "Hugo",
                    LastName = "Lynd",
                    IPAddress = "109.0.153.166",
                    Latitude = 51.6710832,
                    Longitude = 0.8078532
                };

            _userList = new List<User>
            {
                new User()
                {
                    Email = "mshieldon0@squidoo.com",
                    FirstName = "Maurise",
                    LastName = "Shieldon",
                    IPAddress = "192.57.232.111",
                    Latitude = 34.003135,
                    Longitude = -117.7228641
                },
                new User()
                {
                    Email = "bhalgarth1@timesonline.co.uk",
                    FirstName = "Bendix",
                    LastName = "Halgarth",
                    IPAddress = "4.185.73.82",
                    Latitude = -2.9623869,
                    Longitude = 104.7399789
                },
                new User()
                {
                    Email = "msouthall2@ihg.com",
                    FirstName = "Meghan",
                    LastName = "Southall",
                    IPAddress = "21.243.184.215",
                    Latitude = 15.45033,
                    Longitude = 44.12768
                },
                _registeredLondonUser,
                _actualLondonUser
            };

        }

        [Fact]
        public void ReturnUsersWithinSpecifiedRadius()
        {
            var radius = 50;
            var result = _sut.GetLondonUsers(_userList, radius);

            Assert.Single(result);
            Assert.Contains(_actualLondonUser, result);
            Assert.DoesNotContain(_registeredLondonUser, result);
        }
    }
}
