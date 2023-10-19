using JobPortal.Maui.Model;
using Newtonsoft.Json;

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
    }
}
