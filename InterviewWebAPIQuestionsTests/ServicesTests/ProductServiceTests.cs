using InterviewWebAPIQuestions.Models;
using InterviewWebAPIQuestions.Services;

namespace InterviewWebAPIQuestionsTests.ServicesTests
{
    public class ProductServiceTests
    {
        // sut --> system under test

        private readonly IProductService _sut;
        public ProductServiceTests()
        {
            _sut = new ProductService();
        }

        [Fact]
        public async Task Should_Return_Products_Async()
        {
            // act
            var response = await _sut.GetProductsAsync();
            
            Assert.NotNull(response);
            Assert.IsType<List<Product>>(response);
        }
    }
}
