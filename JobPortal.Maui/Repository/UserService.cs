using JobPortal.Maui.Model;
using Microsoft.Maui.ApplicationModel.Communication;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace JobPortal.Maui.Repository
{
    internal class UserService : IUserRepository
    {
        private string apiUrl = $"{App.apiDevTunnel}/api/User";
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

        public async Task<User> GetUser(int userId)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"{apiUrl}/{userId}";
                    client.BaseAddress = new Uri(url);

                    HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        var user = JsonConvert.DeserializeObject<User>(json);
                        return user;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<User> PostUserJobOfertApplication(int userId, JobOfert jobOfert)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(jobOfert);
                    var requestContent = new StringContent(json, Encoding.UTF8, "application/json");

                    string url = $"{apiUrl}/PostUserJobOfertApplication/{userId}";
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
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<UserJobOfertApplication>> GetUserJobOfertApplications(int userId)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"{apiUrl}/GetUserJobOfertApplications/{userId}";
                    client.BaseAddress = new Uri(url);

                    HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        List<UserJobOfertApplication> userJobOfertApplication = JsonConvert.DeserializeObject<List<UserJobOfertApplication>>(json);
                        return userJobOfertApplication;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task RemoveUserJobOfertApplication(int userId, int jobOfertId)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"{apiUrl}/deleteUserJobOfertApplication/{userId}/{jobOfertId}";
                    client.BaseAddress = new Uri(url);

                    HttpResponseMessage response = await client.DeleteAsync(client.BaseAddress);
                    if (response.IsSuccessStatusCode)
                    {
                        await Shell.Current.DisplayAlert("delete", "delete", "delete");
                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
