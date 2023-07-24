using System.Net.Http.Json;
using TTestFramework.Shared.Models;

namespace TTestFramework.Shared.Clients
{
    public interface IProductClient
    {
        Task<IEnumerable<ProductListModel>> GetProducts();
        Task CreateProduct(CreateProductModel model);
    }

    public class ProductClient : IProductClient
    {
        private readonly HttpClient _httpClient;

        public ProductClient(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(nameof(IProductClient));
        }

        public async Task CreateProduct(CreateProductModel model)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/api/products", model);

            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<ProductListModel>> GetProducts()
        {
            IEnumerable<ProductListModel> response = await _httpClient.GetFromJsonAsync<IEnumerable<ProductListModel>>($"/api/products");

            return response;
        }
    }
}
