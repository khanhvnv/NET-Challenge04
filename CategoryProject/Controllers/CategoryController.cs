using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CategoryProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("CategoryApi");
            var response = await client.GetAsync("/categories");
            if (!response.IsSuccessStatusCode)
            {
                // Handle error (optional)
                return View(new List<string>());
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var categories = JsonSerializer.Deserialize<List<string>>(responseContent);

            return View(categories);
        }
    }
}
