using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using EcommerceProject.ViewModels;
using SharedDto;

namespace EcommerceProject.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly string _baseApiUrl = "https://localhost:7198/api";

        public ProductsController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        /// <summary>
        /// Fetches products optionally filtered by category ID and returns them to the view.
        /// </summary>
        /// <param name="categoryId">Optional category ID to filter products. If null, all products are returned.</param>
        /// <returns>A view with a list of products, filtered by category if specified.</returns>
        public async Task<IActionResult> Index(int? categoryId)
        {
            var requestUrl = $"{_baseApiUrl}/products" + (categoryId.HasValue ? $"?categoryId={categoryId}" : "");

            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<ProductDto>>(jsonResponse);
                return View(products);
            }

            return View(new List<ProductDto>());
        }
    }
}
