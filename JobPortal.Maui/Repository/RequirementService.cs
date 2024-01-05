using JobPortal.Maui.Model;
using Newtonsoft.Json;
using System.Text;

namespace JobPortal.Maui.Repository
{
    public class RequirementService : IRequirementRepository
    {
        private string apiUrl = $"{App.apiDevTunnel}/api/Requirement";

        public async Task AddAllRequirements(int jobOfertId, List<Requirement> requirements)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(requirements);
                    var requestContent = new StringContent(json, Encoding.UTF8, "application/json");

                    string url = $"{apiUrl}/AddAllRequirements/{jobOfertId}";
                    client.BaseAddress = new Uri(url);
                    var response = await client.PostAsync(client.BaseAddress, requestContent);
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        public async Task<Requirement> AddRequirement(int jobOfertId, Requirement requirement)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(requirement);
                    var requestContent = new StringContent(json, Encoding.UTF8, "application/json");

                    string url = $"{apiUrl}/{jobOfertId}";
                    client.BaseAddress = new Uri(url);
                    var response = await client.PostAsync(client.BaseAddress, requestContent);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = response.Content.ReadAsStringAsync().Result;
                        Requirement result = JsonConvert.DeserializeObject<Requirement>(responseContent);
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

        public async Task DeleteRequirement(int requirementId)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"{apiUrl}/{requirementId}";
                    client.BaseAddress = new Uri(url);

                    HttpResponseMessage response = await client.DeleteAsync(client.BaseAddress);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public async Task DeleteRequirementsByJobOfert(int jobOfertId)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"{apiUrl}/DeleteRequirementByJobOfert/{jobOfertId}";
                    client.BaseAddress = new Uri(url);

                    HttpResponseMessage response = await client.DeleteAsync(client.BaseAddress);
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        public async Task<List<Requirement>> GetRequirements(int jobOfertId)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"{apiUrl}/GetRequirementsForUser/{jobOfertId}";
                    client.BaseAddress = new Uri(url);

                    HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        List<Requirement> requirements = JsonConvert.DeserializeObject<List<Requirement>>(json);
                        return requirements;
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
