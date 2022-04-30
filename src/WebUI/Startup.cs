using CleanArchitecture.Application;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Infrastructure;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.WebUI.Filters;
using CleanArchitecture.WebUI.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSwag;
using NSwag.Generation.Processors.Security;
using System;
using System.Linq;

namespace CleanArchitecture.WebUI
{
	/// <summary>
	/// Startup class
	/// </summary>
	public class Startup
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Startup"/> class.
		/// </summary>
		/// <param name="configuration">The configuration.</param>
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		/// <summary>
		/// Gets the configuration.
		/// </summary>
		/// <value>
		/// The configuration.
		/// </value>
		public IConfiguration Configuration { get; }

		/// <summary>
		/// Configures the services.
		/// </summary>
		/// <param name="services">The services.</param>
		public void ConfigureServices(
			IServiceCollection services
		)
		{
			services.AddApplication();
			services.AddInfrastructure(Configuration);

			services.AddDatabaseDeveloperPageExceptionFilter();

			services.AddSingleton<ICurrentUserService, CurrentUserService>();

			services.AddHttpContextAccessor();

			services.AddHealthChecks()
					.AddDbContextCheck<ApplicationDbContext>();

			services.AddControllersWithViews(options =>
					options.Filters.Add<ApiExceptionFilterAttribute>())
							.AddFluentValidation(x => x.AutomaticValidationEnabled = false);

			services.AddRazorPages();

			// Customise default API behaviour
			services.Configure<ApiBehaviorOptions>(options =>
			{
				options.SuppressModelStateInvalidFilter = true;
			});

			// In production, the Angular files will be served from this directory
			services.AddSpaStaticFiles(configuration =>
			{
				configuration.RootPath = "ClientApp/dist";
			});

			services.AddApiVersioning(setup =>
			{
				setup.DefaultApiVersion = new ApiVersion(1, 0);
				setup.ApiVersionReader = new UrlSegmentApiVersionReader();
				setup.AssumeDefaultVersionWhenUnspecified = true;
				setup.ReportApiVersions = true;
			});

			services.AddVersionedApiExplorer(setup =>
			{
				setup.GroupNameFormat = "'v'VV";
				setup.SubstituteApiVersionInUrl = true;
			});

			services.AddOpenApiDocument(configure =>
				{
					configure.Title = "CleanArchitecture API";
					configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
					{
						Type = OpenApiSecuritySchemeType.ApiKey,
						Name = "Authorization",
						In = OpenApiSecurityApiKeyLocation.Header,
						Description = "Type into the textbox: Bearer {your JWT token}."
					});

					configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));

					configure.PostProcess = document =>
					{
						document.Info.Title = "CleanArchitecture API";
						document.Info.Version = ApiVersion.Default.ToString();
						document.Info.License = new OpenApiLicense
						{
							Name = "MIT License",
							Url = new Uri("https://opensource.org/licenses/MIT").ToString()
						};
						document.Info.Contact = new NSwag.OpenApiContact
						{
							Email = "info@datacenter.com",
							Name = "Iordanidis Chris",
							Url = new Uri("https://www.linkedin.com/in/iordanidischristos/").ToString()
						};
					};
				});

			services.AddMvc(setupAction =>
			{
				setupAction.EnableEndpointRouting = false;
				setupAction.Filters.Add(
						new ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest));
				setupAction.Filters.Add(
						new ProducesResponseTypeAttribute(StatusCodes.Status401Unauthorized));
				setupAction.Filters.Add(
						new ProducesResponseTypeAttribute(StatusCodes.Status406NotAcceptable));
				setupAction.Filters.Add(
						new ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError));
				setupAction.Filters.Add(
						new ProducesDefaultResponseTypeAttribute());

				setupAction.ReturnHttpNotAcceptable = true;

				// XML support
				//setupAction.OutputFormatters.Add(new XmlSerializerOutputFormatter());
				setupAction.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
			})
				//.AddXmlSerializerFormatters()
				.AddXmlDataContractSerializerFormatters()
				.SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
		}

		/// <summary>
		/// Configures the specified application.
		/// </summary>
		/// <param name="app">The application.</param>
		/// <param name="env">The env.</param>
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseMigrationsEndPoint();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHealthChecks("/health");
			app.UseHttpsRedirection();
			app.UseStaticFiles();
			if (!env.IsDevelopment())
			{
				app.UseSpaStaticFiles();
			}

			app.UseSwaggerUi3(settings =>
			{
				settings.CustomStylesheetPath = "/assets/custom-ui.css";
				settings.Path = "/api";
				settings.DocumentPath = "/api/specification.json";
			});

			app.UseRouting();

			app.UseAuthentication();
			app.UseIdentityServer();
			app.UseAuthorization();
			app.UseEndpoints(endpoints =>
			{
				//endpoints.MapControllerRoute(
				//					name: "default",
				//					pattern: "{controller}/{action=Index}/{id?}");
				endpoints.MapControllers();
				endpoints.MapRazorPages();
			});

			app.UseSpa(spa =>
			{
				// To learn more about options for serving an Angular SPA from ASP.NET Core,
				// see https://go.microsoft.com/fwlink/?linkid=864501

				spa.Options.SourcePath = "ClientApp";

				if (env.IsDevelopment())
				{
					//spa.UseAngularCliServer(npmScript: "start");
					spa.UseProxyToSpaDevelopmentServer(Configuration["SpaBaseUrl"] ?? "http://localhost:4200");
				}
			});
		}
	}
}