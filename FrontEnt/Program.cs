using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner (se necessário)
builder.Services.AddRazorPages();

var app = builder.Build();

// Habilita o uso de arquivos estáticos
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Define o endpoint padrão para servir a index.html
app.MapGet("/", () => Results.Redirect("/index.html"));

app.Run();
