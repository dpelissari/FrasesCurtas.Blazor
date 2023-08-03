using FrasesCurtas.Autenticacao;
using FrasesCurtas.Componentes;
using FrasesCurtas.Data;
using FrasesCurtas.Interfaces;
using FrasesCurtas.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// conection string
var connectionString = builder.Configuration.GetConnectionString("Frases") ?? "Data Source=FrasesCurtas.db";

// Add services to the container.
builder.Services.AddAuthenticationCore();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, ProvedorAutenticacao>();
builder.Services.AddSingleton<ContaUsuarioService>();
builder.Services.AddHttpClient();

// salvando em memoria
//builder.Services.AddDbContext<AplicacaoDbContexto>(options => options.UseInMemoryDatabase("FrasesDb"));

// salvando no sqlite
builder.Services.AddSqlite<AplicacaoDbContexto>(connectionString);

// configurando a injeção de dependencia dos nossos serviços
builder.Services.AddScoped<IFraseService, FraseService>();
builder.Services.AddScoped<IAutorService, AutorService>();
builder.Services.AddScoped<ICategoriaFraseService, CategoriaFraseService>();
builder.Services.AddScoped<ICategoriaFraseService, CategoriaFraseService>();

// adiciona relações de interoperabilidade
builder.Services.AddScoped<RedimensionarJsInterop>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();