using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Standart ASP.NET Core servislerini ekliyoruz
builder.Services.AddControllersWithViews();

// Autofac ile Dependency Injection kullanmak için aşağıdaki satırı ekliyoruz
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()) // Autofac için factory kullanıyoruz
	.ConfigureContainer<ContainerBuilder>(containerBuilder =>
	{
		// Burada Autofac üzerinden servislerinizi kaydediyorsunuz
		containerBuilder.RegisterModule(new AutofacBusinessModule());  // Kendi Autofac module'nüzü buraya ekleyin
	});

// Veritabanı bağlantısı için connection string'i kullanarak DbContext'i yapılandırıyoruz
var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<BitirmeDbContext>(options =>
	options.UseSqlServer(connectionString));

var app = builder.Build();

// HTTP istekleri için pipeline'ı yapılandırıyoruz
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();


// Varsayılan route'u ayarlıyoruz
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Register}/{id?}");


app.Run();
