using ProdManager.Data;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner
builder.Services
    .AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        // Suprime o filtro de estado de modelo inválido
        options.SuppressModelStateInvalidFilter = true;
    });

// Configura o DbContext com a string de conexão
builder.Services.AddDbContext<ProdManagerDbContext>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader();
    });
});

var app = builder.Build();

// Mapeia os controladores
app.MapControllers();

// Executa o aplicativo
app.Run();