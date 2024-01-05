using JobPortal.Maui.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Maui.Repository
{
    public class CategoryService : ICategoryRepository
    {
        private string apiUrl = $"{App.apiDevTunnel}/api/Category";
        public async Task<Category> AddCategory(int jobOfertId, Category category)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(category);
                    var requestContent = new StringContent(json, Encoding.UTF8, "application/json");

                    string url = $"{apiUrl}/{jobOfertId}";
                    client.BaseAddress = new Uri(url);
                    var response = await client.PostAsync(client.BaseAddress, requestContent);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = response.Content.ReadAsStringAsync().Result;
                        Category result = JsonConvert.DeserializeObject<Category>(responseContent);
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

        public async Task<List<Category>> GetCategories()
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
                        List<Category> educations = JsonConvert.DeserializeObject<List<Category>>(json);
                        return educations;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Category>> GetCategories(int jobOfertId)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"{apiUrl}/GetCategoriesForJobOfert/{jobOfertId}";
                    client.BaseAddress = new Uri(url);

                    HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(json);
                        return categories;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<string>> GetCategoriesAsString()
        {
            var categories = await GetCategories();
            List<string> categoriesAsString = new List<string>();
            foreach (var category in categories)
            {
                categoriesAsString.Add(category.CategoryName);
            }
            return categoriesAsString;
        }
    }
}
