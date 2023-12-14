using JobPortal.Maui.Model;
using JobPortal.Maui.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Maui.Repository
{
    public class JobOfertService : IJobOfertRepository
    {
        private string apiUrl = $"{App.apiDevTunnel}/api/JobOfert";
        public async Task<JobOfert> AddJobOfert(int userId,JobOfert jobOfert)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(jobOfert);
                    var requestContent = new StringContent(json, Encoding.UTF8, "application/json");

                    string url = $"{apiUrl}/{userId}";
                    client.BaseAddress = new Uri(url);
                    var response = await client.PostAsync(client.BaseAddress, requestContent);
                    await Shell.Current.DisplayAlert("dziala", $"dziala {response.RequestMessage}", "dziala");
                    if (response.IsSuccessStatusCode)
                    {
                        await Shell.Current.DisplayAlert("esa", "esa", "esa");
                        string responseContent = response.Content.ReadAsStringAsync().Result;
                        JobOfert result = JsonConvert.DeserializeObject<JobOfert>(responseContent);
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

        public async Task<List<JobOfert>> GetAllJobOferts()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"{apiUrl}";
                    client.BaseAddress = new Uri(url);

                    HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        List<JobOfert> jobOferts = JsonConvert.DeserializeObject<List<JobOfert>>(json);
                        return jobOferts;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<JobOfert>> GetAllJobOfertsWithCategories()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"{apiUrl}/GetJobOfertWithCategories";
                    client.BaseAddress = new Uri(url);

                    HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        List<JobOfert> jobOferts = JsonConvert.DeserializeObject<List<JobOfert>>(json);
                        return jobOferts;
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
