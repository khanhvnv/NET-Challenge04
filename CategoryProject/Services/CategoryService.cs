using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CategoryProject.Models;

namespace CategoryProject.Services
{
    public class CategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new System.Uri("http://localhost:5225/");
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            var categories = await _httpClient.GetFromJsonAsync<List<Category>>("categories");
            return categories ?? new List<Category>();
        }
    }
}
