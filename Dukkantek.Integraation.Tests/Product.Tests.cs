using Dukkantek.API;
using Dukkantek.Integraation.Tests.Base;
using Dukkantek.Services.DTOs;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using System.Net;
using Dukkantek.Domain.Shared;
using System.Text;

namespace Dukkantek.Integraation.Tests
{
    public class ProductTests : IClassFixture<BaseTest<Startup>>, IDisposable
    {
        private readonly HttpClient _client;
        public ProductTests(BaseTest<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetProduct_SendValidRequest_ReturnsProductsGroupedByStatus()
        {
            // Act
            var response = await _client.GetAsync("/api/products/status/grouping");

            // Assert
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
            ProductsGroupedByStatusDTO productsGroupedByStatus = JsonConvert.DeserializeObject<ProductsGroupedByStatusDTO>(await response.Content.ReadAsStringAsync());

            productsGroupedByStatus.ShouldNotBeNull();
        }

        [Fact]
        public async Task ChangeProductStatus_SendExistedProduct_StatusChanged()
        {
            int productId = 1;
            ChangeProductStatusDTO changeProductStatus = new ChangeProductStatusDTO() { Status = ProductStatus.Damaged };

            var requestBody = new StringContent(JsonConvert.SerializeObject(changeProductStatus), Encoding.UTF8, "application/json");
            // Act
            var response = await _client.PutAsync($"/api/products/{productId}/status", requestBody);

            // Assert
            response.StatusCode.ShouldBe(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task ChangeProductStatus_SendNotExistedProduct_ReturnsNotFound()
        {
            int productId = 10;
            ChangeProductStatusDTO changeProductStatus = new ChangeProductStatusDTO() { Status = ProductStatus.Damaged };

            var requestBody = new StringContent(JsonConvert.SerializeObject(changeProductStatus), Encoding.UTF8, "application/json");
            // Act
            var response = await _client.PutAsync($"/api/products/{productId}/status", requestBody);

            // Assert
            response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
        }

        public virtual void Dispose()
        {
            _client.Dispose();
        }
    }
}
