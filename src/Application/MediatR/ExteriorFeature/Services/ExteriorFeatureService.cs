using AutoMapper;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.ExteriorFeature.Services
{
	/// <summary>
	/// ExteriorFeatureService class
	/// </summary>
	public class ExteriorFeatureService
	{
		/// <summary>
		/// IMapper mapper
		/// </summary>
		private readonly IMapper mapper;

		/// <summary>
		/// IApplicationDbContext context
		/// </summary>
		private readonly IApplicationDbContext context;

		/// <summary>
		/// ExteriorFeatureService constructor
		/// </summary>
		/// <param name="mapper"></param>
		/// <param name="context"></param>
		public ExteriorFeatureService(
			IMapper mapper,
			IApplicationDbContext context
		)
		{
			this.mapper = mapper;
			this.context = context;
		}

		/// <summary>
		/// GetAllWithPagination
		/// </summary>
		/// <param name="query">SlApiPaginationQuery</param>
		/// <param name="responseList">SlApiResponse PaginatedList ExteriorFeatureDto</param>
		/// <returns>SlApiResponse PaginatedList ExteriorFeatureDto</returns>
		public async Task<SlApiResponse<PaginatedList<ExteriorFeatureDto>, object>> GetAllWithPagination(
			SlApiPaginationQuery query,
			SlApiResponse<PaginatedList<ExteriorFeatureDto>, object> responseList
		)
		{
			try
			{
				var result = await context.ExteriorFeatures
					.AsNoTracking()
					.Where(a => a.IsEnabled == true && a.IsDeleted == false)
					.OrderBy(x => x.ExteriorFeaturesID)
					.Select(t => new ExteriorFeatureDto()
					{
						ExteriorFeaturesID = t.ExteriorFeaturesID,
						PropertyView = t.PropertyView,
						Facade = t.Facade,
						Orientation = t.Orientation,
						AccessFrom = t.AccessFrom,
						ResidentialZone = t.ResidentialZone,
						ParkingSpot = t.ParkingSpot,
						Awnings = t.Awnings,
						Garden = t.Garden,
						DisabledAccess = t.DisabledAccess,
						Pool = t.Pool,
						Corner = t.Corner,
						Veranda = t.Veranda,
						ShowcaseGlassLength = t.ShowcaseGlassLength,
						UnloadingRamp = t.UnloadingRamp,
						WithinCityPlan = t.WithinCityPlan,
						StructureFactor = t.StructureFactor,
						Description = t.Description,
						IsEnabled = t.IsEnabled,
						IsDeleted = t.IsDeleted,
						Guid = t.Guid,
						Created = t.Created,
						CreatedBy = t.CreatedBy,
						LastModified = t.LastModified,
						LastModifiedBy = t.LastModifiedBy
					})
					//	.ProjectTo<ClassifiedCharacteristicsDto>(mapper.ConfigurationProvider)
					.PaginatedListAsync(query.PageNumber, query.PageSize);

				if (result == null)
				{
					responseList.Messages = new List<SlApiMessage>() {
							new SlApiMessage() {
								MessageType = SlApiMessageTypeEnum.Warning,
								Message = $"Δεν βρέθηκαν εγγραφές."
							}
						};
				}
				else
				{
					responseList.Data = result;
				}
			}
			catch (Exception e)
			{
				responseList.IsError = true;
				responseList.Messages = new List<SlApiMessage>() {
					new SlApiMessage() {
						MessageType = SlApiMessageTypeEnum.Error,
						Message = e.Message
					}
				};
			}

			return responseList;
		}

		/// <summary>
		/// GetById
		/// </summary>
		/// <param name="id">int</param>
		/// <param name="response">SlApiResponse ExteriorFeatureDto</param>
		/// <returns>SlApiResponse ExteriorFeatureDto</returns>
		public async Task<SlApiResponse<ExteriorFeatureDto, object>> GetById(
			int id,
			SlApiResponse<ExteriorFeatureDto, object> response
		)
		{
			try
			{
				var result = await context.ExteriorFeatures
					.AsNoTracking()
					.Where(a =>
						a.IsEnabled == true &&
						a.IsDeleted == false &&
						a.ExteriorFeaturesID == id
					)
					.OrderBy(x => x.ExteriorFeaturesID)
					.Select(t => new ExteriorFeatureDto()
					{
						ExteriorFeaturesID = t.ExteriorFeaturesID,
						PropertyView = t.PropertyView,
						Facade = t.Facade,
						Orientation = t.Orientation,
						AccessFrom = t.AccessFrom,
						ResidentialZone = t.ResidentialZone,
						ParkingSpot = t.ParkingSpot,
						Awnings = t.Awnings,
						Garden = t.Garden,
						DisabledAccess = t.DisabledAccess,
						Pool = t.Pool,
						Corner = t.Corner,
						Veranda = t.Veranda,
						ShowcaseGlassLength = t.ShowcaseGlassLength,
						UnloadingRamp = t.UnloadingRamp,
						WithinCityPlan = t.WithinCityPlan,
						StructureFactor = t.StructureFactor,
						Description = t.Description,
						IsEnabled = t.IsEnabled,
						IsDeleted = t.IsDeleted,
						Guid = t.Guid,
						Created = t.Created,
						CreatedBy = t.CreatedBy,
						LastModified = t.LastModified,
						LastModifiedBy = t.LastModifiedBy
					})
					.FirstOrDefaultAsync();

				if (result == null)
				{
					response.Messages = new List<SlApiMessage>() {
							new SlApiMessage() {
								MessageType = SlApiMessageTypeEnum.Warning,
								Message = $"Δεν βρέθηκαν εγγραφές."
							}
						};
				}
				else
				{
					response.Data = result;
				}
			}
			catch (Exception e)
			{
				response.IsError = true;
				response.Messages = new List<SlApiMessage>() {
					new SlApiMessage() {
						MessageType = SlApiMessageTypeEnum.Error,
						Message = e.Message
					}
				};
			}

			return response;
		}

		/// <summary>
		/// UpdateDtoById
		/// </summary>
		/// <param name="id">int</param>
		/// <param name="ExteriorFeatureDto">ExteriorFeatureDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse ExteriorFeatureDto</param>
		/// <returns>SlApiResponse ExteriorFeatureDto</returns>
		public async Task<SlApiResponse<ExteriorFeatureDto, object>> UpdateDtoById(
			int id,
			ExteriorFeatureDto exteriorFeatureDto,
			SlApiResponse<ExteriorFeatureDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.ExteriorFeatures.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(ExteriorFeatureDto), id);
				}

#pragma warning disable CS0472 // The result of the expression is always the same
				entity.PropertyView = exteriorFeatureDto.PropertyView != null ? exteriorFeatureDto.PropertyView : entity.PropertyView;
				entity.Facade = exteriorFeatureDto.Facade != null ? exteriorFeatureDto.Facade : entity.Facade;
				entity.Orientation = exteriorFeatureDto.Orientation != null ? exteriorFeatureDto.Orientation : entity.Orientation;
				entity.AccessFrom = exteriorFeatureDto.AccessFrom != null ? exteriorFeatureDto.AccessFrom : entity.AccessFrom;
				entity.ResidentialZone = exteriorFeatureDto.ResidentialZone != null ? exteriorFeatureDto.ResidentialZone : entity.ResidentialZone;
				entity.ParkingSpot = exteriorFeatureDto.ParkingSpot != null ? exteriorFeatureDto.ParkingSpot : entity.ParkingSpot;
				entity.Awnings = exteriorFeatureDto.Awnings != null ? exteriorFeatureDto.Awnings : entity.Awnings;
				entity.Garden = exteriorFeatureDto.Garden != null ? exteriorFeatureDto.Garden : entity.Garden;
				entity.DisabledAccess = exteriorFeatureDto.DisabledAccess != null ? exteriorFeatureDto.DisabledAccess : entity.DisabledAccess;
				entity.Pool = exteriorFeatureDto.Pool != null ? exteriorFeatureDto.Pool : entity.Pool;
				entity.Corner = exteriorFeatureDto.Corner != null ? exteriorFeatureDto.Corner : entity.Corner;
				entity.Veranda = exteriorFeatureDto.Veranda != null ? exteriorFeatureDto.Veranda : entity.Veranda;
				entity.ShowcaseGlassLength = exteriorFeatureDto.ShowcaseGlassLength != null ? exteriorFeatureDto.ShowcaseGlassLength : entity.ShowcaseGlassLength;
				entity.UnloadingRamp = exteriorFeatureDto.UnloadingRamp != null ? exteriorFeatureDto.UnloadingRamp : entity.UnloadingRamp;
				entity.WithinCityPlan = exteriorFeatureDto.WithinCityPlan != null ? exteriorFeatureDto.WithinCityPlan : entity.WithinCityPlan;
				entity.StructureFactor = exteriorFeatureDto.StructureFactor != null ? exteriorFeatureDto.StructureFactor : entity.StructureFactor;
				entity.Description = exteriorFeatureDto.Description != null ? exteriorFeatureDto.Description : entity.Description;
				entity.IsEnabled = exteriorFeatureDto.IsEnabled;
				entity.IsDeleted = exteriorFeatureDto.IsDeleted;
#pragma warning restore CS0472 // The result of the expression is always the same

				await context.SaveChangesAsync(cancellationToken);

				response.Data = new ExteriorFeatureDto()
				{
					ExteriorFeaturesID = entity.ExteriorFeaturesID,
					PropertyView = entity.PropertyView,
					Facade = entity.Facade,
					Orientation = entity.Orientation,
					AccessFrom = entity.AccessFrom,
					ResidentialZone = entity.ResidentialZone,
					ParkingSpot = entity.ParkingSpot,
					Awnings = entity.Awnings,
					Garden = entity.Garden,
					DisabledAccess = entity.DisabledAccess,
					Pool = entity.Pool,
					Corner = entity.Corner,
					Veranda = entity.Veranda,
					ShowcaseGlassLength = entity.ShowcaseGlassLength,
					UnloadingRamp = entity.UnloadingRamp,
					WithinCityPlan = entity.WithinCityPlan,
					StructureFactor = entity.StructureFactor,
					Description = entity.Description,
					IsEnabled = entity.IsEnabled,
					IsDeleted = entity.IsDeleted,
					Guid = entity.Guid,
					Created = entity.Created,
					CreatedBy = entity.CreatedBy,
					LastModified = entity.LastModified,
					LastModifiedBy = entity.LastModifiedBy
				};
			}
			catch (Exception e)
			{
				response.IsError = true;
				response.Messages = new List<SlApiMessage>() {
					new SlApiMessage() {
						MessageType = SlApiMessageTypeEnum.Error,
						Message = e.Message
					}
				};
			}

			return response;
		}

		/// <summary>
		/// AddDto
		/// </summary>
		/// <param name="ExteriorFeatureDto">ExteriorFeatureDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse ExteriorFeatureDto</param>
		/// <returns>SlApiResponse ExteriorFeatureDto</returns>
		public async Task<SlApiResponse<ExteriorFeatureDto, object>> AddDto(
			ExteriorFeatureDto exteriorFeatureDto,
			SlApiResponse<ExteriorFeatureDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				if (exteriorFeatureDto != null)
				{
					var entity = mapper.Map<Domain.Entities.ExteriorFeature>(exteriorFeatureDto);
					context.ExteriorFeatures.Add(entity);
					await context.SaveChangesAsync(cancellationToken);

					response.Data = new ExteriorFeatureDto()
					{
						ExteriorFeaturesID = entity.ExteriorFeaturesID,
						PropertyView = entity.PropertyView,
						Facade = entity.Facade,
						Orientation = entity.Orientation,
						AccessFrom = entity.AccessFrom,
						ResidentialZone = entity.ResidentialZone,
						ParkingSpot = entity.ParkingSpot,
						Awnings = entity.Awnings,
						Garden = entity.Garden,
						DisabledAccess = entity.DisabledAccess,
						Pool = entity.Pool,
						Corner = entity.Corner,
						Veranda = entity.Veranda,
						ShowcaseGlassLength = entity.ShowcaseGlassLength,
						UnloadingRamp = entity.UnloadingRamp,
						WithinCityPlan = entity.WithinCityPlan,
						StructureFactor = entity.StructureFactor,
						Description = entity.Description,
						IsEnabled = entity.IsEnabled,
						IsDeleted = entity.IsDeleted,
						Guid = entity.Guid,
						Created = entity.Created,
						CreatedBy = entity.CreatedBy,
						LastModified = entity.LastModified,
						LastModifiedBy = entity.LastModifiedBy
					};
				}
			}
			catch (Exception e)
			{
				response.IsError = true;
				response.Messages = new List<SlApiMessage>() {
					new SlApiMessage() {
						MessageType = SlApiMessageTypeEnum.Error,
						Message = e.Message
					}
				};
			}

			return response;
		}

		/// <summary>
		/// DeleteDtoById
		/// </summary>
		/// <param name="ExteriorFeatureDto">ExteriorFeatureDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse ExteriorFeatureDto</param>
		/// <returns>SlApiResponse ExteriorFeatureDto</returns>
		public async Task<SlApiResponse<ExteriorFeatureDto, object>> DeleteDtoById(
			int id,
			SlApiResponse<ExteriorFeatureDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.ExteriorFeatures.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(ExteriorFeatureDto), id);
				}

				var deletedDto = mapper.Map<ExteriorFeatureDto>(entity);

				context.ExteriorFeatures.Remove(entity);

				await context.SaveChangesAsync(cancellationToken);

				response.Data = deletedDto;
			}
			catch (Exception e)
			{
				response.IsError = true;
				response.Messages = new List<SlApiMessage>() {
					new SlApiMessage() {
						MessageType = SlApiMessageTypeEnum.Error,
						Message = e.Message
					}
				};
			}

			return response;
		}

		/// <summary>
		/// DisableEnableDtoById
		/// </summary>
		/// <param name="id">int</param>
		/// <param name="ExteriorFeatureDto">ExteriorFeatureDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse ExteriorFeatureDto</param>
		/// <returns>SlApiResponse ExteriorFeatureDto</returns>
		public async Task<SlApiResponse<ExteriorFeatureDto, object>> DisableEnableDtoById(
			int id,
			SlApiResponse<ExteriorFeatureDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.ExteriorFeatures.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(ExteriorFeatureDto), id);
				}

				entity.IsDeleted = true;

				await context.SaveChangesAsync(cancellationToken);

				var deactivatedDto = mapper.Map<ExteriorFeatureDto>(entity);

				response.Data = deactivatedDto;
			}
			catch (Exception e)
			{
				response.IsError = true;
				response.Messages = new List<SlApiMessage>() {
					new SlApiMessage() {
						MessageType = SlApiMessageTypeEnum.Error,
						Message = e.Message
					}
				};
			}

			return response;
		}
	}
}