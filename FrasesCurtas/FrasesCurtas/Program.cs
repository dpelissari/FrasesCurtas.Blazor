using FrasesCurtas.Data;
using FrasesCurtas.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// conection string
var connectionString = builder.Configuration.GetConnectionString("Frases") ?? "Data Source=FrasesCurtas.db";

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// salvando em memoria
//builder.Services.AddDbContext<AplicacaoDbContexto>(options => options.UseInMemoryDatabase("FrasesDb"));

// salvando no sqlite
builder.Services.AddSqlite<AplicacaoDbContexto>(connectionString);

// configurando a injeção de dependencia do nosso serviço
builder.Services.AddScoped<IFraseService, FraseService>();


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
