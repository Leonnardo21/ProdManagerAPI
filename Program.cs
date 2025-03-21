using ProdManager.Data;

var builder = WebApplication.CreateBuilder(args);

// Adiciona servi�os ao cont�iner
builder.Services
    .AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        // Suprime o filtro de estado de modelo inv�lido
        options.SuppressModelStateInvalidFilter = true;
    });

// Configura o DbContext com a string de conex�o
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