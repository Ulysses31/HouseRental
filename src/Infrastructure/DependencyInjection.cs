using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Infrastructure.Identity;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;

namespace CleanArchitecture.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(
			this IServiceCollection services,
			IConfiguration configuration
		)
		{
			if (configuration.GetValue<bool>("UseInMemoryDatabase"))
			{
				services.AddDbContext<ApplicationDbContext>(options =>
				{
					options.LogTo(
						message => Console.WriteLine(message),
						Microsoft.Extensions.Logging.LogLevel.Information,
						DbContextLoggerOptions.DefaultWithUtcTime
					)
					.LogTo(
						message => Debug.WriteLine(message),
						Microsoft.Extensions.Logging.LogLevel.Information,
						DbContextLoggerOptions.DefaultWithUtcTime
					)
					.ConfigureWarnings(w => w.Throw(RelationalEventId.MultipleCollectionIncludeWarning))
					.UseInMemoryDatabase("SpitogatosDb")
					.EnableDetailedErrors(true)
					.EnableSensitiveDataLogging(true);
				});
			}
			else
			{
				services.AddDbContext<ApplicationDbContext>(options =>
				{
					options.LogTo(
						message => Console.WriteLine(message),
						Microsoft.Extensions.Logging.LogLevel.Information,
						DbContextLoggerOptions.DefaultWithUtcTime
					)
					.LogTo(
						message => Debug.WriteLine(message),
						Microsoft.Extensions.Logging.LogLevel.Information,
						DbContextLoggerOptions.DefaultWithUtcTime
					)
					.ConfigureWarnings(w => w.Throw(RelationalEventId.MultipleCollectionIncludeWarning))
					.UseSqlServer(
						configuration.GetConnectionString("MsSqlConnection"),
						b => {
							b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
							b.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
						}
					)
					.EnableDetailedErrors(true)
					.EnableSensitiveDataLogging(true);
				});
			}

			services.AddScoped<IApplicationDbContext>(
				provider => provider.GetService<ApplicationDbContext>()
			);

			services.AddScoped<IDomainEventService, DomainEventService>();

			services
				.AddDefaultIdentity<ApplicationUser>()
				.AddRoles<IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>();

			services.AddIdentityServer()
				.AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

			services.AddTransient<IDateTime, DateTimeService>();
			services.AddTransient<IIdentityService, IdentityService>();
			//services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();
			services.AddTransient<IpAddressService, IpAddressService>();

			services.AddAuthentication()
				.AddIdentityServerJwt();

			services.AddAuthorization(options =>
			{
				options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator"));
			});

			return services;
		}
	}
}