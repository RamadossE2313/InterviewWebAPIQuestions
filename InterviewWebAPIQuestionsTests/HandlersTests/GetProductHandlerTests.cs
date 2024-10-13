using InterviewWebAPIQuestions.Handlers;
using InterviewWebAPIQuestions.Models;
using InterviewWebAPIQuestions.Queries;
using InterviewWebAPIQuestions.Services;
using Moq;

namespace InterviewWebAPIQuestionsTests.HandlersTests
{
    public class GetProductHandlerFixture
    {
        public Mock<IProductService> ProductService { get;}
        public GetProductHandler Sut { get;}

        public GetProductHandlerFixture()
        {
            ProductService = new Mock<IProductService>();
            Sut = new GetProductHandler(ProductService.Object);
        }
    }

    public class GetProductHandlerTests : IClassFixture<GetProductHandlerFixture>
    {
        private readonly GetProductHandlerFixture _fixture;
        public GetProductHandlerTests(GetProductHandlerFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Handle_Method_Should_Return_Response()
        {
            // Arrange
            var request = new GetProductQuery();

            _fixture.ProductService.Setup(product => product.GetProductsAsync())
                .ReturnsAsync(new List<Product>()
                {
                    new Product()
                    {
                        Id = 1,
                        Name = "test"
                    }
                });

            // Act
            var response = await _fixture.Sut.Handle(request, CancellationToken.None);

            // Assert

            Assert.NotNull(response);
            Assert.Equal(1, response.Count());
        }

        [Fact]
        public async Task Handle_Method_Should_Return_EmptyList_Response()
        {
            // Arrange
            var request = new GetProductQuery();

            _fixture.ProductService.Setup(product => product.GetProductsAsync())
                .ReturnsAsync(new List<Product>());

            // Act
            var response = await _fixture.Sut.Handle(request, CancellationToken.None);

            // Assert

            Assert.NotNull(response);
            Assert.Equal(0, response.Count());
        }
    }
}
