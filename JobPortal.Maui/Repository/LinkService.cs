using JobPortal.Maui.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Maui.Repository
{
    public class LinkService : ILinkRepository
    {
        private string apiUrl = $"{App.apiDevTunnel}/api/Link";
        public async Task<Link> AddLink(int userId, Link link)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(link);
                    var requestContent = new StringContent(json, Encoding.UTF8, "application/json");

                    string url = $"{apiUrl}/{userId}";
                    client.BaseAddress = new Uri(url);
                    var response = await client.PostAsync(client.BaseAddress, requestContent);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = response.Content.ReadAsStringAsync().Result;
                        Link result = JsonConvert.DeserializeObject<Link>(responseContent);
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

        public async Task DeleteLink(int linkId)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"{apiUrl}/{linkId}";
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

        public async Task<List<Link>> GetLinks(int userId)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"{apiUrl}/GetLinksForUser/{userId}";
                    client.BaseAddress = new Uri(url);

                    HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        List<Link> links = JsonConvert.DeserializeObject<List<Link>>(json);
                        return links;
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
