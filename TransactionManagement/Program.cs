using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using TransactionManagement.Core.Repositories.Interfaces;
using TransactionManagement.Core.Services.Implementations;
using TransactionManagement.Core.Services.Interfaces;
using TransactionManagement.Infrastructure.Data;
using TransactionManagement.Infrastructure.Data.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);

//if (builder.Environment.IsProduction())
//{
builder.Configuration.AddAzureKeyVault(
    new Uri($"https://{builder.Configuration["KeyVaultName"]}.vault.azure.net/"),
    new DefaultAzureCredential(new DefaultAzureCredentialOptions()));
//}

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<ITransactionService, TransactionService>();

string? connectionString = builder.Configuration.GetConnectionString(nameof(AppDbContext));
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

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
