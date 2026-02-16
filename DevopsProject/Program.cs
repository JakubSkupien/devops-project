var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// GET /
app.MapGet("/", () => Results.Ok(new
{
    message = "Hello DevOps!",
    utc = DateTime.UtcNow
}));

app.Run();
