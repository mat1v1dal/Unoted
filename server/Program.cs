using Server.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddSingleton<MongoDbContext>();  // Inyección de dependencia para MongoDbContext
builder.Services.AddControllers();               // Registrar controladores
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();                // Registrar Swagger para la documentación de la API

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; // Para que Swagger se ejecute en la raíz de la URL
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();  // Configurar autorización si es necesaria

app.MapControllers();    // Mapear controladores a las rutas correspondientes

app.Run();
