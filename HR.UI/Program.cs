using HR.Entities.EnvironmentConfigurations.Implementation;
using HR.Entities.EnvironmentConfigurations.Interface;
using HR.UI.Consumer.Implementations;
using HR.UI.Consumer.Interfaces;
using HR.UI.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();

// Register Services
builder.Services.AddScoped<IVacancyConsumer, VacancyConsumer>();
builder.Services.AddScoped<ICandicateConsumer, CandicateConsumer>();

builder.Services.AddScoped<ITokenManager, TokenManager>();
builder.Services.AddHttpClient();
// Variables
builder.Services.AddSingleton<IHRConfigurations>(builder.Configuration.GetSection("HRConfigurations").Get<HRConfigurations>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
