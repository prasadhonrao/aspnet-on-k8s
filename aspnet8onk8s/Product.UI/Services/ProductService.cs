using System.Text.Json;

namespace Product.UI.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient client;
        public ProductService(HttpClient httpClient)
        {
            this.client = httpClient;
        }

        public IEnumerable<ProductModel> GetProducts()
        {
            var response = client.GetAsync("/api/products").Result;
            var content = response.Content.ReadAsStringAsync().Result;
            var products = JsonSerializer.Deserialize<IEnumerable<ProductModel>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return products;
        }
    }
}
