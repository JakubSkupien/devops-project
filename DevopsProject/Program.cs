var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// GET /
app.MapGet("/", () => Results.Ok(new
{
    message = "Hello DevOps!",
    utc = DateTime.UtcNow
}));

// GET /products
app.MapGet("/products", () => Results.Ok(new[]
{
    new { id = 1, name = "Keyboard", price = 199.99 },
    new { id = 2, name = "Mouse", price = 79.99 },
    new { id = 3, name = "Monitor", price = 899.00 }
}));

app.Run();
