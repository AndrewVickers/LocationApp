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
        Task<List<User>> GetUsers();
        Task<List<User>> GetUsers(string city);
    }

    public class Api : IApi
    {
        public async Task<List<User>> GetUsers()
        { 
            var Url = "https://bpdts-test-app.herokuapp.com/users";

            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetStringAsync(new Uri(Url)).Result;

                return JsonConvert.DeserializeObject<List<User>>(response);
            }
        }

        public async Task<List<User>> GetUsers(string city)
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
