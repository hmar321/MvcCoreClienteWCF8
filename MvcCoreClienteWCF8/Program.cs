using MvcCoreClienteWCF8.Helpers;
using MvcCoreClienteWCF8.Repositories;
using MvcCoreClienteWCF8.Services;
using ServiceReferenceCatastro;
using ServiceReferenceMetodosVarios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ServiceCountries>();
builder.Services.AddTransient<ServiceConversor>();
builder.Services.AddTransient<ServiceCatastro>();
builder.Services.AddTransient<ServiceMetodosVarios>();
builder.Services.AddTransient<RepositoryCliente>();
builder.Services.AddTransient<HelperPathProvider>();
builder.Services.AddTransient<CallejerodelasedeelectrónicadelcatastroSoapClient>();
builder.Services.AddTransient<MetodosVariosContractClient>();

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
