using JobPortal.Maui.Model;
using Microsoft.Maui.ApplicationModel.Communication;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace JobPortal.Maui.Repository
{
    internal class UserService : IUserRepository
    {
        private string apiUrl = "https://localhost:7260/api/User";
        public async Task<User> Login(string email, string password)
        {
            try
            {
                var client = new HttpClient();
                string url = $"{apiUrl}/Login/{email}/{password}";
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
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<User> Register(User user)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var jsonUser = JsonConvert.SerializeObject(user);
                    var requestContent = new StringContent(jsonUser, Encoding.UTF8, "application/json");

                    string url = $"{apiUrl}";
                    client.BaseAddress = new Uri(url);
                    var response = await client.PostAsync(client.BaseAddress, requestContent);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = response.Content.ReadAsStringAsync().Result;
                        User fetchedUser = JsonConvert.DeserializeObject<User>(responseContent);
                        return await Task.FromResult(fetchedUser);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> CheckIfEmailIsFree(string email)
        {
            try
            {
                using(HttpClient client = new HttpClient())
                {
                    string url = $"{apiUrl}/IsUserEmailFree/{email}";
                    client.BaseAddress = new Uri(url);

                    HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        bool userExist = JsonConvert.DeserializeObject<bool>(json);
                        return userExist;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> CheckIfPhoneIsFree(string phone)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"{apiUrl}/IsUserPhoneFree/{phone}";
                    client.BaseAddress = new Uri(url);

                    HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        bool userExist = JsonConvert.DeserializeObject<bool>(json);
                        return userExist;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<User> UpdateUser(int id, User user)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var jsonUser = JsonConvert.SerializeObject(user);
                    var requestContent = new StringContent(jsonUser, Encoding.UTF8, "application/json");

                    string url = $"{apiUrl}/{id}";
                    client.BaseAddress = new Uri(url);
                    var response = await client.PutAsync(client.BaseAddress, requestContent);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = response.Content.ReadAsStringAsync().Result;
                        User fetchedUser = JsonConvert.DeserializeObject<User>(responseContent);
                        return await Task.FromResult(fetchedUser);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
