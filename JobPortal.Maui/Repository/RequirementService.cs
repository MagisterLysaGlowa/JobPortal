using JobPortal.Maui.Model;
using Newtonsoft.Json;
using System.Text;

namespace JobPortal.Maui.Repository
{
    public class RequirementService : IRequirementRepository
    {
        private string apiUrl = "https://localhost:7260/api/Requirement";
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
    }
}
