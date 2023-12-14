using JobPortal.Maui.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Maui.Repository
{
    public class ExperienceService : IExperienceRepository
    {
        private string apiUrl = $"{App.apiDevTunnel}/api/Experience";
        public async Task<Experience> AddExperience(int userId, Experience experience)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(experience);
                    var requestContent = new StringContent(json, Encoding.UTF8, "application/json");

                    string url = $"{apiUrl}/{userId}";
                    client.BaseAddress = new Uri(url);
                    var response = await client.PostAsync(client.BaseAddress, requestContent);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = response.Content.ReadAsStringAsync().Result;
                        Experience result = JsonConvert.DeserializeObject<Experience>(responseContent);
                        return await Task.FromResult(result);
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

        public async Task DeleteExperience(int experienceId)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"{apiUrl}/{experienceId}";
                    client.BaseAddress = new Uri(url);

                    HttpResponseMessage response = await client.DeleteAsync(client.BaseAddress);
                    if (response.IsSuccessStatusCode)
                    {
                        //await Shell.Current.DisplayAlert("DELETE", "DELETE", "DELETE");
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public async Task<List<Experience>> GetExperiences(int userId)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"{apiUrl}/GetExperiencesForUser/{userId}";
                    client.BaseAddress = new Uri(url);

                    HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        List<Experience> experiences = JsonConvert.DeserializeObject<List<Experience>>(json);
                        return experiences;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
