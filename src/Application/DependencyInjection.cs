using AutoMapper.EquivalencyExpression;
using CleanArchitecture.Application.Common.Behaviours;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.MediatR.AdvertiserInfo.Services;
using CleanArchitecture.Application.MediatR.ClassifiedCharacteristics.Services;
using CleanArchitecture.Application.MediatR.ClassifiedConstruction.Services;
using CleanArchitecture.Application.MediatR.ClassifiedPurpose.Services;
using CleanArchitecture.Application.MediatR.ClassifiedType.Services;
using CleanArchitecture.Application.MediatR.EnergyClass.Services;
using CleanArchitecture.Application.MediatR.ExteriorFeature.Services;
using CleanArchitecture.Application.MediatR.FloorNo.Services;
using CleanArchitecture.Application.MediatR.FloorType.Services;
using CleanArchitecture.Application.MediatR.FrameType.Services;
using CleanArchitecture.Application.MediatR.GoogleMapPlace.Services;
using CleanArchitecture.Application.MediatR.HeatingSystem.Services;
using CleanArchitecture.Application.Repository;
using CleanArchitecture.Application.Repository.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchitecture.Application
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			//services.AddAutoMapper(Assembly.GetExecutingAssembly());
			services.AddAutoMapper((cfg) =>
			{
				cfg.AddCollectionMappers();
				cfg.AllowNullCollections = true;
			}, System.Reflection.Assembly.GetExecutingAssembly(), System.Reflection.Assembly.GetCallingAssembly());
			services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
			services.AddMediatR(Assembly.GetExecutingAssembly());
			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
			services.AddScoped(typeof(SlApiResponse<,>), typeof(SlApiResponse<,>));

			services.AddScoped<IRepoManager, RepoManager>();
			services.AddScoped<AdvertiserInfoService, AdvertiserInfoService>();
			services.AddScoped<ClassifiedCharacteristicsService, ClassifiedCharacteristicsService>();
			services.AddScoped<ClassifiedConstructionService, ClassifiedConstructionService>();
			services.AddScoped<ClassifiedPurposeService, ClassifiedPurposeService>();
			services.AddScoped<ClassifiedTypeService, ClassifiedTypeService>();
			services.AddScoped<EnergyClassService, EnergyClassService>();
			services.AddScoped<ExteriorFeatureService, ExteriorFeatureService>();
			services.AddScoped<FloorNoService, FloorNoService>();
			services.AddScoped<FloorTypeService, FloorTypeService>();
			services.AddScoped<FrameTypeService, FrameTypeService>();
			services.AddScoped<GoogleMapPlaceService, GoogleMapPlaceService>();
			services.AddScoped<HeatingSystemService, HeatingSystemService>();

			return services;
		}
	}
}