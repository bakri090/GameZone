using GameZone.Data;
using Microsoft.EntityFrameworkCore;

namespace GameZone
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			var connect = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("sorry no database");
			builder.Services.AddDbContext<ApplicationDbContext>(op =>
			op.UseSqlServer(connect));
			builder.Services.AddScoped<IDevicesService,DevicesService>();
			builder.Services.AddScoped<ICategoriesService,CategoriesService>();
			builder.Services.AddScoped<IGamesService, GamesService>();
			// Add services to the container.
			builder.Services.AddControllersWithViews();
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
		}
	}
}
