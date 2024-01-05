using JobPortal.Maui.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Maui.Repository
{
    public class BenefitService : IBenefitRepository
    {
        private string apiUrl = $"{App.apiDevTunnel}/api/Benefit";
        public async Task<Benefit> AddBenefit(int jobOfertId, Benefit benefit)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(benefit);
                    var requestContent = new StringContent(json, Encoding.UTF8, "application/json");

                    string url = $"{apiUrl}/{jobOfertId}";
                    client.BaseAddress = new Uri(url);
                    var response = await client.PostAsync(client.BaseAddress, requestContent);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = response.Content.ReadAsStringAsync().Result;
                        Benefit result = JsonConvert.DeserializeObject<Benefit>(responseContent);
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

        public async Task DeleteBenefitsByJobOfert(int jobOfertId)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"{apiUrl}/DeleteBenefitByJobOfert/{jobOfertId}";
                    client.BaseAddress = new Uri(url);

                    HttpResponseMessage response = await client.DeleteAsync(client.BaseAddress);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<List<Benefit>> GetBenefits(int jobOfertId)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"{apiUrl}/GetBenefitsForUser/{jobOfertId}";
                    client.BaseAddress = new Uri(url);

                    HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        List<Benefit> benefits = JsonConvert.DeserializeObject<List<Benefit>>(json);
                        return benefits;
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
