using JobPortal.Maui.Model;
using Microsoft.Maui.ApplicationModel.Communication;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace JobPortal.Maui.Repository
{
    internal class UserService : IUserRepository
    {
        public async Task<User> Login(string email, string password)
        {
            var client = new HttpClient();
            string url = $"https://localhost:7260/api/User/Login/{email}/{password}";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                User user = JsonConvert.DeserializeObject<User>(content);   
                return await Task.FromResult(user);
            }
            return null!;
        }

        public async Task<int> Register(User user)
        {
            try
            {
                var jsonUser = JsonConvert.SerializeObject(user);
                var content = new StringContent(jsonUser, Encoding.UTF8, "application/json");

                var client = new HttpClient();
                string url = $"https://localhost:7260/api/User";
                client.BaseAddress = new Uri(url);
                var response = await client.PostAsync(client.BaseAddress, content);

                if (response.IsSuccessStatusCode)
                {
                    await Shell.Current.DisplayAlert("ADD", "user has been aded sucesfully!", "OK");
                }
            }
            catch(Exception ex)
            {

            }
            return 1;
        }
    }
}
