using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Adiciona servi�os ao cont�iner (se necess�rio)
builder.Services.AddRazorPages();

var app = builder.Build();

// Habilita o uso de arquivos est�ticos
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Define o endpoint padr�o para servir a index.html
app.MapGet("/", () => Results.Redirect("/index.html"));

app.Run();
