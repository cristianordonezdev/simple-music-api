using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using music.Data;
using music.Mappings;
using music.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "music", Version = "v1" });
});
// Configurar el DbContext antes de construir la aplicación
builder.Services.AddDbContext<MusicDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//REGISTERING REPOSITORIES ==========================================
builder.Services.AddScoped<ISong, SongRepository>();
builder.Services.AddScoped<IGenre, SQLGenre>();
// ================================================================


//REGISTERING MAPPING ==========================================
builder.Services.AddAutoMapper(typeof(MainMapping));
// ================================================================


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    // Habilitar middleware de Swagger en el entorno de desarrollo
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API v1");
        c.RoutePrefix = string.Empty; // Hacer que Swagger UI esté disponible en la raíz (opcional)
    });
}
// Configuración de endpoints o middlewares si es necesario
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
