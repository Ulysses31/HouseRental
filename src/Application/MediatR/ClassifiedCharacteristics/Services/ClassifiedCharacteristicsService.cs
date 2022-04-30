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

namespace CleanArchitecture.Application.MediatR.ClassifiedCharacteristics.Services
{
	/// <summary>
	/// ClassifiedCharacteristicsService class
	/// </summary>
	public class ClassifiedCharacteristicsService
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
		/// ClassifiedCharacteristicsService constructor
		/// </summary>
		/// <param name="mapper"></param>
		/// <param name="context"></param>
		public ClassifiedCharacteristicsService(
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
		/// <param name="responseList">SlApiResponse PaginatedList ClassifiedCharacteristicsDto</param>
		/// <returns>SlApiResponse PaginatedList ClassifiedCharacteristicsDto</returns>
		public async Task<SlApiResponse<PaginatedList<ClassifiedCharacteristicsDto>, object>> GetAllWithPagination(
			SlApiPaginationQuery query,
			SlApiResponse<PaginatedList<ClassifiedCharacteristicsDto>, object> responseList
		)
		{
			try
			{
				var result = await context.ClassifiedCharacteristics
					.AsNoTracking()
					.Where(a => a.IsEnabled == true && a.IsDeleted == false)
					.OrderBy(x => x.CharacteristicsID)
					.Select(t => new ClassifiedCharacteristicsDto()
					{
						CharacteristicsID = t.CharacteristicsID,
						Price = t.Price,
						PricePerTm = t.PricePerTm,
						AreaTm = t.AreaTm,
						LandAreaTm = t.LandAreaTm,
						Levels = t.Levels,
						Square = t.Square,
						Region = t.Region,
						Cuisines = t.Cuisines,
						Bathrooms = t.Bathrooms,
						Bedrooms = t.Bedrooms,
						ContructionYear = t.ContructionYear,
						LandArea = t.LandArea,
						Lounges = t.Lounges,
						MonthlyShared = t.MonthlyShared,
						DistanceFromSea = t.DistanceFromSea,
						YearOfRenovation = t.YearOfRenovation,
						BuildingCoefficient = t.BuildingCoefficient,
						SystemCode = t.SystemCode,
						PropertyCode = t.PropertyCode,
						AvailableFrom = t.AvailableFrom,
						PublicationOfAdvert = t.PublicationOfAdvert,
						HeatingSystemID = t.HeatingSystemID,
						HeatingSystem = context.HeatingSystems
							.Where(s => s.HeatingSystemID == t.HeatingSystemID)
							.Select(s => new HeatingSystemDto()
							{
								HeatingSystemID = s.HeatingSystemID,
								HeatingSystemValue = s.HeatingSystemValue,
								Description = s.Description,
								IsEnabled = s.IsEnabled,
								IsDeleted = s.IsDeleted
							})
							.FirstOrDefault(),
						HeatingTypeID = t.HeatingTypeID,
						HeatingType = context.HeatingTypes
							.Where(s => s.HeatingTypeID == t.HeatingTypeID)
							.Select(s => new HeatingTypeDto()
							{
								HeatingTypeID = s.HeatingTypeID,
								HeatingTypeValue = s.HeatingTypeValue,
								Description = s.Description,
								IsEnabled = s.IsEnabled,
								IsDeleted = s.IsDeleted
							})
							.FirstOrDefault(),
						EnergyClassID = t.EnergyClassID,
						EnergyClass = context.EnergyClasses
							.Where(s => s.EnergyClassID == t.EnergyClassID)
							.Select(s => new EnergyClassDto()
							{
								EnergyClassID = s.EnergyClassID,
								EnergyClassValue = s.EnergyClassValue,
								Description = s.Description,
								IsEnabled = s.IsEnabled,
								IsDeleted = s.IsDeleted
							})
							.FirstOrDefault(),
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
		/// <param name="response">SlApiResponse ClassifiedCharacteristicsDto</param>
		/// <returns>SlApiResponse ClassifiedCharacteristicsDto</returns>
		public async Task<SlApiResponse<ClassifiedCharacteristicsDto, object>> GetById(
			int id,
			SlApiResponse<ClassifiedCharacteristicsDto, object> response
		)
		{
			try
			{
				var result = await context.ClassifiedCharacteristics
					.AsNoTracking()
					.Where(a =>
						a.IsEnabled == true &&
						a.IsDeleted == false &&
						a.CharacteristicsID == id
					)
					.Select(t => new ClassifiedCharacteristicsDto()
					{
						CharacteristicsID = t.CharacteristicsID,
						Price = t.Price,
						PricePerTm = t.PricePerTm,
						AreaTm = t.AreaTm,
						LandAreaTm = t.LandAreaTm,
						Levels = t.Levels,
						Square = t.Square,
						Region = t.Region,
						Cuisines = t.Cuisines,
						Bathrooms = t.Bathrooms,
						Bedrooms = t.Bedrooms,
						ContructionYear = t.ContructionYear,
						LandArea = t.LandArea,
						Lounges = t.Lounges,
						MonthlyShared = t.MonthlyShared,
						DistanceFromSea = t.DistanceFromSea,
						YearOfRenovation = t.YearOfRenovation,
						BuildingCoefficient = t.BuildingCoefficient,
						SystemCode = t.SystemCode,
						PropertyCode = t.PropertyCode,
						AvailableFrom = t.AvailableFrom,
						PublicationOfAdvert = t.PublicationOfAdvert,
						HeatingSystemID = t.HeatingSystemID,
						HeatingSystem = context.HeatingSystems
							.Where(s => s.HeatingSystemID == t.HeatingSystemID)
							.Select(s => new HeatingSystemDto()
							{
								HeatingSystemID = s.HeatingSystemID,
								HeatingSystemValue = s.HeatingSystemValue,
								Description = s.Description,
								IsEnabled = s.IsEnabled,
								IsDeleted = s.IsDeleted
							})
							.FirstOrDefault(),
						HeatingTypeID = t.HeatingTypeID,
						HeatingType = context.HeatingTypes
							.Where(s => s.HeatingTypeID == t.HeatingTypeID)
							.Select(s => new HeatingTypeDto()
							{
								HeatingTypeID = s.HeatingTypeID,
								HeatingTypeValue = s.HeatingTypeValue,
								Description = s.Description,
								IsEnabled = s.IsEnabled,
								IsDeleted = s.IsDeleted
							})
							.FirstOrDefault(),
						EnergyClassID = t.EnergyClassID,
						EnergyClass = context.EnergyClasses
							.Where(s => s.EnergyClassID == t.EnergyClassID)
							.Select(s => new EnergyClassDto()
							{
								EnergyClassID = s.EnergyClassID,
								EnergyClassValue = s.EnergyClassValue,
								Description = s.Description,
								IsEnabled = s.IsEnabled,
								IsDeleted = s.IsDeleted
							})
							.FirstOrDefault(),
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
		/// <param name="ClassifiedCharacteristicsDto">ClassifiedCharacteristicsDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse ClassifiedCharacteristicsDto</param>
		/// <returns>SlApiResponse ClassifiedCharacteristicsDto</returns>
		public async Task<SlApiResponse<ClassifiedCharacteristicsDto, object>> UpdateDtoById(
			int id,
			ClassifiedCharacteristicsDto classifiedCharacteristicsDto,
			SlApiResponse<ClassifiedCharacteristicsDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.ClassifiedCharacteristics.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(classifiedCharacteristicsDto), id);
				}

#pragma warning disable CS0472 // The result of the expression is always the same
				entity.AreaTm = classifiedCharacteristicsDto.AreaTm != null ? classifiedCharacteristicsDto.AreaTm : entity.AreaTm;
				entity.AvailableFrom = classifiedCharacteristicsDto.AvailableFrom != null ? classifiedCharacteristicsDto.AvailableFrom : entity.AvailableFrom;
				entity.Bathrooms = classifiedCharacteristicsDto.Bathrooms != null ? classifiedCharacteristicsDto.Bathrooms : entity.Bathrooms;
				entity.Bedrooms = classifiedCharacteristicsDto.Bedrooms != null ? classifiedCharacteristicsDto.Bedrooms : entity.Bedrooms;
				entity.BuildingCoefficient = classifiedCharacteristicsDto.BuildingCoefficient != null ? classifiedCharacteristicsDto.BuildingCoefficient : entity.BuildingCoefficient;
				entity.ContructionYear = classifiedCharacteristicsDto.ContructionYear != null ? classifiedCharacteristicsDto.ContructionYear : entity.ContructionYear;
				entity.Cuisines = classifiedCharacteristicsDto.Cuisines != null ? classifiedCharacteristicsDto.Cuisines : entity.Cuisines;
				entity.Description = classifiedCharacteristicsDto.Description != null ? classifiedCharacteristicsDto.Description : entity.Description;
				entity.DistanceFromSea = classifiedCharacteristicsDto.DistanceFromSea != null ? classifiedCharacteristicsDto.DistanceFromSea : entity.DistanceFromSea;
				entity.EnergyClassID = classifiedCharacteristicsDto.EnergyClassID != null ? classifiedCharacteristicsDto.EnergyClassID : entity.EnergyClassID;
				entity.HeatingSystemID = classifiedCharacteristicsDto.HeatingSystemID != null ? classifiedCharacteristicsDto.HeatingSystemID : entity.HeatingSystemID;
				entity.HeatingTypeID = classifiedCharacteristicsDto.HeatingTypeID != null ? classifiedCharacteristicsDto.HeatingTypeID : entity.HeatingTypeID;
				entity.LandArea = classifiedCharacteristicsDto.LandArea != null ? classifiedCharacteristicsDto.LandArea : entity.LandArea;
				entity.LandAreaTm = classifiedCharacteristicsDto.LandAreaTm != null ? classifiedCharacteristicsDto.LandAreaTm : entity.LandAreaTm;
				entity.Levels = classifiedCharacteristicsDto.Levels != null ? classifiedCharacteristicsDto.Levels : entity.Levels;
				entity.Lounges = classifiedCharacteristicsDto.Lounges != null ? classifiedCharacteristicsDto.Lounges : entity.Lounges;
				entity.MonthlyShared = classifiedCharacteristicsDto.MonthlyShared != null ? classifiedCharacteristicsDto.MonthlyShared : entity.MonthlyShared;
				entity.Price = classifiedCharacteristicsDto.Price != null ? classifiedCharacteristicsDto.Price : entity.Price;
				entity.PricePerTm = classifiedCharacteristicsDto.PricePerTm != null ? classifiedCharacteristicsDto.PricePerTm : entity.PricePerTm;
				entity.PropertyCode = classifiedCharacteristicsDto.PropertyCode != null ? classifiedCharacteristicsDto.PropertyCode : entity.PropertyCode;
				entity.PublicationOfAdvert = classifiedCharacteristicsDto.PublicationOfAdvert != null ? classifiedCharacteristicsDto.PublicationOfAdvert : entity.PublicationOfAdvert;
				entity.Region = classifiedCharacteristicsDto.Region != null ? classifiedCharacteristicsDto.Region : entity.Region;
				entity.Square = classifiedCharacteristicsDto.Square != null ? classifiedCharacteristicsDto.Square : entity.Square;
				entity.SystemCode = classifiedCharacteristicsDto.SystemCode != null ? classifiedCharacteristicsDto.SystemCode : entity.SystemCode;
				entity.YearOfRenovation = classifiedCharacteristicsDto.YearOfRenovation != null ? classifiedCharacteristicsDto.YearOfRenovation : entity.YearOfRenovation;
				entity.IsEnabled = classifiedCharacteristicsDto.IsEnabled;
				entity.IsDeleted = classifiedCharacteristicsDto.IsDeleted;
#pragma warning restore CS0472 // The result of the expression is always the same

				await context.SaveChangesAsync(cancellationToken);

				response.Data = new ClassifiedCharacteristicsDto()
				{
					CharacteristicsID = entity.CharacteristicsID,
					AreaTm = entity.AreaTm,
					AvailableFrom = entity.AvailableFrom,
					Bathrooms = entity.Bathrooms,
					Bedrooms = entity.Bedrooms,
					BuildingCoefficient = entity.BuildingCoefficient,
					ContructionYear = entity.ContructionYear,
					Cuisines = entity.Cuisines,
					DistanceFromSea = entity.DistanceFromSea,
					EnergyClassID = entity.EnergyClassID,
					HeatingSystemID = entity.HeatingSystemID,
					HeatingTypeID = entity.HeatingTypeID,
					LandArea = entity.LandArea,
					LandAreaTm = entity.LandAreaTm,
					Levels = entity.Levels,
					Lounges = entity.Lounges,
					MonthlyShared = entity.MonthlyShared,
					Price = entity.Price,
					PricePerTm = entity.PricePerTm,
					PropertyCode = entity.PropertyCode,
					PublicationOfAdvert = entity.PublicationOfAdvert,
					Region = entity.Region,
					Square = entity.Square,
					SystemCode = entity.SystemCode,
					YearOfRenovation = entity.YearOfRenovation,
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
		/// <param name="ClassifiedCharacteristicsDto">ClassifiedCharacteristicsDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse ClassifiedCharacteristicsDto</param>
		/// <returns>SlApiResponse ClassifiedCharacteristicsDto</returns>
		public async Task<SlApiResponse<ClassifiedCharacteristicsDto, object>> AddDto(
			ClassifiedCharacteristicsDto classifiedCharacteristicsDto,
			SlApiResponse<ClassifiedCharacteristicsDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				if (classifiedCharacteristicsDto != null)
				{
					var entity = mapper.Map<Domain.Entities.ClassifiedCharacteristics>(classifiedCharacteristicsDto);
					context.ClassifiedCharacteristics.Add(entity);
					await context.SaveChangesAsync(cancellationToken);

					response.Data = new ClassifiedCharacteristicsDto()
					{
						CharacteristicsID = entity.CharacteristicsID,
						AreaTm = entity.AreaTm,
						AvailableFrom = entity.AvailableFrom,
						Bathrooms = entity.Bathrooms,
						Bedrooms = entity.Bedrooms,
						BuildingCoefficient = entity.BuildingCoefficient,
						ContructionYear = entity.ContructionYear,
						Cuisines = entity.Cuisines,
						DistanceFromSea = entity.DistanceFromSea,
						EnergyClassID = entity.EnergyClassID,
						HeatingSystemID = entity.HeatingSystemID,
						HeatingTypeID = entity.HeatingTypeID,
						LandArea = entity.LandArea,
						LandAreaTm = entity.LandAreaTm,
						Levels = entity.Levels,
						Lounges = entity.Lounges,
						MonthlyShared = entity.MonthlyShared,
						Price = entity.Price,
						PricePerTm = entity.PricePerTm,
						PropertyCode = entity.PropertyCode,
						PublicationOfAdvert = entity.PublicationOfAdvert,
						Region = entity.Region,
						Square = entity.Square,
						SystemCode = entity.SystemCode,
						YearOfRenovation = entity.YearOfRenovation,
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
		/// <param name="ClassifiedCharacteristicsDto">ClassifiedCharacteristicsDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse ClassifiedCharacteristicsDto</param>
		/// <returns>SlApiResponse ClassifiedCharacteristicsDto</returns>
		public async Task<SlApiResponse<ClassifiedCharacteristicsDto, object>> DeleteDtoById(
			int id,
			SlApiResponse<ClassifiedCharacteristicsDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.ClassifiedCharacteristics.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(ClassifiedCharacteristicsDto), id);
				}

				var deletedDto = mapper.Map<ClassifiedCharacteristicsDto>(entity);

				context.ClassifiedCharacteristics.Remove(entity);

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
		/// <param name="ClassifiedCharacteristicsDto">ClassifiedCharacteristicsDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse ClassifiedCharacteristicsDto</param>
		/// <returns>SlApiResponse ClassifiedCharacteristicsDto</returns>
		public async Task<SlApiResponse<ClassifiedCharacteristicsDto, object>> DisableEnableDtoById(
			int id,
			SlApiResponse<ClassifiedCharacteristicsDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.ClassifiedCharacteristics.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(ClassifiedCharacteristicsDto), id);
				}

				entity.IsDeleted = true;

				await context.SaveChangesAsync(cancellationToken);

				var deactivatedDto = mapper.Map<ClassifiedCharacteristicsDto>(entity);

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