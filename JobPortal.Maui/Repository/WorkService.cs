using JobPortal.Maui.Model;
using Microsoft.Maui.ApplicationModel.Communication;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Maui.Repository
{
    public class WorkService : IWorkRepository
    {
        private string apiUrl = $"{App.apiDevTunnel}/api/Work";
        public async Task<Work> AddWork(Work work)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var jsonWork = JsonConvert.SerializeObject(work);
                    var requestContent = new StringContent(jsonWork, Encoding.UTF8, "application/json");

                    string url = $"{apiUrl}";
                    client.BaseAddress = new Uri(url);
                    var response = await client.PostAsync(client.BaseAddress, requestContent);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = response.Content.ReadAsStringAsync().Result;
                        Work fetchedWork = JsonConvert.DeserializeObject<Work>(responseContent);
                        return await Task.FromResult(fetchedWork);
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

        public async Task<Work> UpdateWork(int workId, Work work)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var jsonWork = JsonConvert.SerializeObject(work);
                    var requestContent = new StringContent(jsonWork, Encoding.UTF8, "application/json");

                    string url = $"{apiUrl}/{workId}";
                    client.BaseAddress = new Uri(url);
                    var response = await client.PutAsync(client.BaseAddress, requestContent);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = response.Content.ReadAsStringAsync().Result;
                        Work fetchedWork = JsonConvert.DeserializeObject<Work>(responseContent);
                        return await Task.FromResult(fetchedWork);
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

        public async Task<Work> GetWorkByUserId(int userId)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"{apiUrl}/GetWorkByUserId/{userId}";
                    client.BaseAddress = new Uri(url);

                    HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        Work work = JsonConvert.DeserializeObject<Work>(json);
                        return work;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task DeleteWork(int workId)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"{apiUrl}/{workId}";
                    client.BaseAddress = new Uri(url);

                    HttpResponseMessage response = await client.DeleteAsync(client.BaseAddress);
                    if (response.IsSuccessStatusCode)
                    {
                        await Shell.Current.DisplayAlert("DELETE", "DELETE", "DELETE");
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
