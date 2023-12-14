using JobPortal.Maui.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Maui.Repository
{
    public class CarrierService : ICarrierRepository
    {
        private string apiUrl = $"{App.apiDevTunnel}/api/Carrier";
        public async Task<Carrier> AddCarrier(Carrier carrier)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(carrier);
                    var requestContent = new StringContent(json, Encoding.UTF8, "application/json");

                    string url = $"{apiUrl}";
                    client.BaseAddress = new Uri(url);
                    var response = await client.PostAsync(client.BaseAddress, requestContent);
                    
                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = response.Content.ReadAsStringAsync().Result;
                        Carrier result = JsonConvert.DeserializeObject<Carrier>(responseContent);
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

        public async Task DeleteCarrier(int carrierId)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"{apiUrl}/{carrierId}";
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

        public async Task<Carrier> GetCarrierByUserId(int userId)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"{apiUrl}/GetCarrierByUserId/{userId}";
                    client.BaseAddress = new Uri(url);

                    HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        Carrier carrier = JsonConvert.DeserializeObject<Carrier>(json);
                        return carrier;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Carrier> UpdateCarrier(int carrierId, Carrier carrier)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(carrier);
                    var requestContent = new StringContent(json, Encoding.UTF8, "application/json");

                    string url = $"{apiUrl}/{carrierId}";
                    client.BaseAddress = new Uri(url);
                    var response = await client.PutAsync(client.BaseAddress, requestContent);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = response.Content.ReadAsStringAsync().Result;
                        Carrier result = JsonConvert.DeserializeObject<Carrier>(responseContent);
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
