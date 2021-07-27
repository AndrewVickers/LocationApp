using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LocationAppTasks;
using Moq;
using Xunit;

namespace LocationAppTests
{
    public class APITasksShould
    {
        private IAPITasks SUT;
        private Mock<HttpClient> _mockHttpClient;

        public APITasksShould()
        {
            SUT = new APITasks();
            _mockHttpClient = new Mock<HttpClient>();
        }

        [Fact]
        public void CallCityAPIWhenCityIsSpecified()
        {
            var city = "city";
            var response = SUT.GetUsers(city);
        }

        [Fact]
        public void CallUsersAPIWhenNoCityIsSpecified()
        {

        }
    }
}
