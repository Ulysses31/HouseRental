using CleanArchitecture.Infrastructure.Identity;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI
{
	/// <summary>
	/// Program class
	/// </summary>
	public class Program
	{
		/// <summary>
		/// Defines the entry point of the application.
		/// </summary>
		/// <param name="args">The arguments.</param>
		public static async Task Main(string[] args)
		{
			var host = CreateHostBuilder(args).Build();

			using (var scope = host.Services.CreateScope())
			{
				var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
				var services = scope.ServiceProvider;
				var ip = new IpAddressService();

				Log.Logger = new LoggerConfiguration()
						 .Enrich.WithProperty("OSVersion", Environment.OSVersion)
						 .Enrich.WithProperty("ServerName", System.Net.Dns.GetHostName())
						 .Enrich.WithProperty("UserName", Environment.UserName)
						 .Enrich.WithProperty("UserDomainName", Environment.UserDomainName)
						 .Enrich.WithProperty("Address", ip.GetHostIpAddress())
						 .ReadFrom.Configuration(configuration)
						 .CreateLogger();

				Log.Information("Starting up...");

				try
				{
					var context = services.GetRequiredService<ApplicationDbContext>();

					if (context.Database.IsSqlServer())
					{
						Log.Information("Database is Sql Server, starting migration...");
						context.Database.Migrate(); // EnsureCreated
					}

					var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
					var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

					await ApplicationDbContextSeed.SeedDefaultUserAsync(userManager, roleManager);
					await ApplicationDbContextSeed.SeedSampleDataAsync(context);
				}
				catch (Exception ex)
				{
					Log.Fatal(ex, "An error occurred while migrating or seeding the database.");
					//throw;
				}
			}

			await host.RunAsync();
		}

		/// <summary>
		/// Creates the host builder.
		/// </summary>
		/// <param name="args">The arguments.</param>
		/// <returns>IHostBuilder</returns>
		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.UseSystemd()
				.UseSerilog()
				.ConfigureAppConfiguration((buildCtx, config) =>
				{
					config.AddJsonFile(
						$"appsettings.{buildCtx.HostingEnvironment.EnvironmentName}.{Environment.MachineName}.json",
						optional: true,
						reloadOnChange: false
					);
				})
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.ConfigureKestrel(serverOptions =>
					{
						serverOptions.AllowSynchronousIO = true;
					})
					.UseUrls("http://0.0.0.0:5000")
					.UseStartup<Startup>();
				});
	}
}