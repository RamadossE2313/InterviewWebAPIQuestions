using InterviewWebAPIQuestions.Controllers;
using InterviewWebAPIQuestions.Models;
using InterviewWebAPIQuestions.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

[Binding]
public class ProductsControllerSteps
{
    private readonly IMediator _mediator;
    private ProductsController _controller;
    private ActionResult _result;
    private Mock<IMediator> _mediatorMock;

    public ProductsControllerSteps()
    {
        _mediatorMock = new Mock<IMediator>();
        _controller = new ProductsController(_mediatorMock.Object);
    }

    [Given(@"I have a valid request to retrieve products")]
    public void GivenIHaveAValidRequestToRetrieveProducts()
    {
        _mediatorMock
            .Setup(m => m.Send(It.IsAny<GetProductQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Name = "test"
                }
            });
    }

    [Given(@"no products are available")]
    public void GivenNoProductsAreAvailable()
    {
        _mediatorMock
            .Setup(m => m.Send(It.IsAny<GetProductQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Product>());
    }

    [Given(@"an error occurs while retrieving products")]
    public void GivenAnErrorOccursWhileRetrievingProducts()
    {
        _mediatorMock
            .Setup(m => m.Send(It.IsAny<GetProductQuery>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception("Error retrieving products"));
    }

    [When(@"I call the GetProducts API")]
    public async Task WhenICallTheGetProductsAPI()
    {
        _result = await _controller.GetProducts();
    }

    [Then(@"I should receive a successful response")]
    public void ThenIShouldReceiveASuccessfulResponse()
    {
        Assert.IsType<OkObjectResult>(_result);
    }

    [Then(@"the response should contain a list of products")]
    public void ThenTheResponseShouldContainAListOfProducts()
    {
        var okResult = _result as OkObjectResult;
        Assert.IsType<List<Product>>(okResult.Value);
        Assert.NotEmpty((List<Product>)okResult.Value);
    }

    [Then(@"the response should contain an empty list")]
    public void ThenTheResponseShouldContainAnEmptyList()
    {
        var okResult = _result as OkObjectResult;
        var products = okResult.Value as List<Product>;
        Assert.NotNull(products);
        Assert.Empty(products);
    }

    [Then(@"I should receive an error response")]
    public void ThenIShouldReceiveAnErrorResponse()
    {
        Assert.IsType<ObjectResult>(_result);
        var objectResult = _result as ObjectResult;
        Assert.Equal(500, objectResult.StatusCode);
    }
}
