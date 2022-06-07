using Mango.Web.Models;
using Mango.Web.Services.IServices;

namespace Mango.Web.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public Task<T> CreateProductAsync<T>(ProductDto productDto)
        {
            return SendAsync<T>(new ApiRequest() { ApiType = SD.ApiType.POST, Data = productDto, Url = SD.ProductApiBase + "/api/products", AccessToken = "" });
        }

        public Task<T> DeleteProductAsync<T>(int id)
        {
            return  SendAsync<T>(new ApiRequest() { ApiType = SD.ApiType.DELETE, Data = id, Url = SD.ProductApiBase + "/api/products", AccessToken = "" });
        }

        public Task<T> GetAllProductsAsync<T>()
        {
            return SendAsync<T>(new ApiRequest() { ApiType = SD.ApiType.GET, Url = SD.ProductApiBase + "/api/products/", AccessToken = "" });
        }

        public Task<T> GetProductByIdAsync<T>(int id)
        {
            return SendAsync<T>(new ApiRequest() { ApiType = SD.ApiType.GET, Url = SD.ProductApiBase + "/api/products/" + id, AccessToken = "" });
        }

        public Task<T> UpdateProductAsync<T>(ProductDto productDto)
        {
            return SendAsync<T>(new ApiRequest() { ApiType = SD.ApiType.PUT, Data = productDto, Url = SD.ProductApiBase + "/api/products/", AccessToken = "" });
        }
    }
}
