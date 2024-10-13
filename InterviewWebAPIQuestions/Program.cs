using InterviewWebAPIQuestions;
using InterviewWebAPIQuestions.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddSingleton<CosmosDbService>();

builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(typeof(Program).Assembly));

builder.Services.AddHttpContextAccessor();

var serviceProvider = builder.Services.BuildServiceProvider();
var httpContext = serviceProvider.GetService<IHttpContextAccessor>();
//httpContext.Connection

builder.Services.AddRateLimiter(options =>
{
    // Define a global rate limiter with queuing
    options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>
        (
        context => RateLimitPartition.GetFixedWindowLimiter(partitionKey: context.Connection.RemoteIpAddress?.ToString() ?? "anonymous",  
        factory: _ => new FixedWindowRateLimiterOptions
        {
            PermitLimit = 5,
            // Max 5 requests
            Window = TimeSpan.FromMinutes(1),
            // Per minute
            QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
            // FIFO queue
            QueueLimit = 0
            // Queue 3 additional requests after the limit is reached
        }));
            // Optional: Set rejection status code for when the queue limit is exceeded
            options.RejectionStatusCode = 429;
        });
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseRateLimiter();

app.UseAuthorization();

app.MapGet("/getip", async (HttpContext) =>
{
    var httpcontext = HttpContext.Connection.RemoteIpAddress;
    await Task.Delay(1);
});
app.MapControllers();

app.Run();
