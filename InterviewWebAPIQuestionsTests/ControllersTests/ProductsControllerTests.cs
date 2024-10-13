using MediatR;
using Moq;
using InterviewWebAPIQuestions.Controllers;
using InterviewWebAPIQuestions.Queries;
using InterviewWebAPIQuestions.Models;
using Microsoft.AspNetCore.Mvc;

namespace InterviewWebAPIQuestionsTests.ControllersTests
{
    public class ProductsControllerFixture
    {
        public Mock<IMediator> Mediator { get; }
        public ProductsController Sut { get; }
        public ProductsControllerFixture()
        {
            Mediator =  new Mock<IMediator>();
            Sut = new ProductsController(Mediator.Object);
        }
    }
    public class ProductsControllerTests : IClassFixture<ProductsControllerFixture>
    {
        private readonly ProductsControllerFixture _fixture;

        public ProductsControllerTests(ProductsControllerFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task GetProducts_Should_Return_OK_WithProduct()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1" },
                new Product { Id = 2, Name = "Product 2" }
            };

            _fixture.Mediator
                .Setup(m => m.Send(It.IsAny<GetProductQuery>(), default))
                .ReturnsAsync(products);

            // Act
            var response = await _fixture.Sut.GetProducts();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(response); // Check if response is OkObjectResult
            Assert.Equal(200, okResult.StatusCode); // Check if status code is 200 OK

            var returnedProducts = Assert.IsType<List<Product>>(okResult.Value); // Check if the value is a List<Product>
            Assert.Equal(2, returnedProducts.Count); // Verify the count of products returned
        }
    }
}
