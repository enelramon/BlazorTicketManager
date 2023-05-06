using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Radzen;
using TicketManager.BLL;
using TicketManager.DAL;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();

    //obtenemos el ConStr para usarlo en el contexto
    var ConStr = builder.Configuration.GetConnectionString("ConStr");

    //agregamos el contexto al builder con el ConStr
    builder.Services.AddDbContext<TicketContext>(Options => Options.UseSqlite(ConStr));

    builder.Services.AddScoped<SistemasBLL>();

    builder.Services.AddScoped<NotificationService>();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
