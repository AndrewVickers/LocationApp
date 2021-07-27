using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using LocationAppTasks.Models;
using Newtonsoft.Json;

namespace LocationAppTasks.Tasks
{
    public interface IApi
    {
        IList<User> getUserList(string input);
        Task<IList<User>> GetUsers();
        Task<IList<User>> GetUsers(string city);
    }

    public class Api : IApi
    {
        private readonly ICalculations _calculations = new Calculations();

        public IList<User> getUserList(string input)
        {
            switch (int.TryParse(input, out var radius))
            {
                case true:
                    var response = GetUsers().Result;
                    return _calculations.GetLondonUsers(response, radius);
                default:
                    return GetUsers(input).Result;
            }
        }

        public async Task<IList<User>> GetUsers()
        { 
            var Url = "https://bpdts-test-app.herokuapp.com/users";

            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetStringAsync(new Uri(Url)).Result;

                return JsonConvert.DeserializeObject<List<User>>(response);
            }
        }

        public async Task<IList<User>> GetUsers(string city)
        {
            var Url = $"https://bpdts-test-app.herokuapp.com/city/{city}/users";

            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetStringAsync(new Uri(Url)).Result;

                return JsonConvert.DeserializeObject<List<User>>(response);
            }
        }
    }
}
