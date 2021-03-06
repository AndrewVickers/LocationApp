using System.Collections.Generic;
using System.Threading.Tasks;
using LocationAppTasks.Models;
using LocationAppTasks.Tasks;
using Moq;
using Xunit;

namespace LocationAppTests
{
    public class APITasksShould
    {
        private readonly IApi _sut;
        private readonly IList<User> _userList;
        private readonly User _actualLondonUser;
        private readonly User _registeredLondonUser;

        public APITasksShould()
        {
            _sut = new Api();
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

        /// <summary>
        /// Sanity check that it returns something. If test fails then data on remote system is to blame
        /// </summary>
        [Fact]
        public void CallCityAPIWhenValidCityIsSpecified()
        {
            var city = "London";
            var response = _sut.GetUsers(city);

            Assert.NotEmpty(response.Result);

        }

        /// <summary>
        /// Sanity check that it returns something. If test fails then data on remote system is to blame
        /// </summary>
        [Fact]
        public void ReturnAListOfUsersWhenNoCityIsSpecified()
        {
            var city = "London";
            var response = _sut.GetUsers();

            Assert.NotEmpty(response.Result);

        }

        /// <summary>
        /// Sanity check that it returns something. If test fails then data on remote system is to blame
        /// </summary>
        [Fact]
        public void CallUsersAPIWhenInvalidCityIsSpecified()
        {
            var city = "city x";
            var response = _sut.GetUsers(city);

            Assert.Empty(response.Result);
        }
    }
}
