using Microsoft.EntityFrameworkCore;
using ProdManager.Data;
using ProdManager.Repositories;
using ProdManager.Repositories.Interface;

var builder = WebApplication.CreateBuilder(args);
var corsPolicy = "_myAllowSpecificOrigins";
builder.Services
    .AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });

builder.Services.AddDbContext<ProdManagerDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicy,
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

var app = builder.Build();

app.UseCors(corsPolicy);
app.MapControllers();
app.Run();