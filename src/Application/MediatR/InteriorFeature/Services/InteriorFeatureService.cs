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

namespace CleanArchitecture.Application.MediatR.InteriorFeature.Services
{
	/// <summary>
	/// InteriorFeatureService class
	/// </summary>
	public class InteriorFeatureService
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
		/// InteriorFeatureService constructor
		/// </summary>
		/// <param name="mapper"></param>
		/// <param name="context"></param>
		public InteriorFeatureService(
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
		/// <param name="responseList">SlApiResponse PaginatedList InteriorFeatureDto</param>
		/// <returns>SlApiResponse PaginatedList InteriorFeatureDto</returns>
		public async Task<SlApiResponse<PaginatedList<InteriorFeatureDto>, object>> GetAllWithPagination(
			SlApiPaginationQuery query,
			SlApiResponse<PaginatedList<InteriorFeatureDto>, object> responseList
		)
		{
			try
			{
				var result = await context.InteriorFeatures
					.AsNoTracking()
					.Where(a => a.IsEnabled == true && a.IsDeleted == false)
					.OrderBy(x => x.InteriorFeaturesID)
					.Select(t => new InteriorFeatureDto()
					{
						InteriorFeaturesID = t.InteriorFeaturesID,
						Elevator = t.Elevator,
						InternalStaircase = t.InternalStaircase,
						AirConditioning = t.AirConditioning,
						Warehouse = t.Warehouse,
						FloorTypeID = t.FloorTypeID,
						FloorType = context.FloorTypes
							.Where(f => f.FloorTypeID == t.FloorTypeID)
							.Select(f => new FloorTypeDto()
							{
								FloorTypeID = f.FloorTypeID,
								Title = f.Title,
								Description = f.Description,
								IsEnabled = f.IsEnabled,
								IsDeleted = f.IsDeleted
							})
							.FirstOrDefault(),
						PetsWelcome = t.PetsWelcome,
						SecurityDoor = t.SecurityDoor,
						FrameTypeID = t.FrameTypeID,
						FrameType = context.FrameTypes
							.Where(f => f.FrameTypeID == t.FrameTypeID)
							.Select(f => new FrameTypeDto()
							{
								FrameTypeID = f.FrameTypeID,
								Title = f.Title,
								Description = f.Description,
								IsEnabled = f.IsEnabled,
								IsDeleted = f.IsDeleted
							})
							.FirstOrDefault(),
						PowerTypeID = t.PowerTypeID,
						PowerType = context.PowerTypes
							.Where(f => f.PowerTypeID == t.PowerTypeID)
							.Select(f => new PowerTypeDto()
							{
								PowerTypeID = f.PowerTypeID,
								Title = f.Title,
								Description = f.Description,
								IsEnabled = f.IsEnabled,
								IsDeleted = f.IsDeleted
							})
							.FirstOrDefault(),
						DoubleGlazing = t.DoubleGlazing,
						Furnished = t.Furnished,
						Fireplace = t.Fireplace,
						UnderfloorHeating = t.UnderfloorHeating,
						SolarHeating = t.SolarHeating,
						NightCurrent = t.NightCurrent,
						Garret = t.Garret,
						Playroom = t.Playroom,
						SatelliteAntenna = t.SatelliteAntenna,
						Alarm = t.Alarm,
						DoorScreens = t.DoorScreens,
						Airy = t.Airy,
						Painted = t.Painted,
						WithEquipment = t.WithEquipment,
						CableTV = t.CableTV,
						Wiring = t.Wiring,
						LoadingUnloadingElevator = t.LoadingUnloadingElevator,
						SuspendedCeiling = t.SuspendedCeiling,
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
		/// <param name="response">SlApiResponse InteriorFeatureDto</param>
		/// <returns>SlApiResponse InteriorFeatureDto</returns>
		public async Task<SlApiResponse<InteriorFeatureDto, object>> GetById(
			int id,
			SlApiResponse<InteriorFeatureDto, object> response
		)
		{
			try
			{
				var result = await context.InteriorFeatures
					.AsNoTracking()
					.Where(a =>
						a.IsEnabled == true &&
						a.IsDeleted == false &&
						a.InteriorFeaturesID == id
					)
					.OrderBy(x => x.InteriorFeaturesID)
					.Select(t => new InteriorFeatureDto()
					{
						InteriorFeaturesID = t.InteriorFeaturesID,
						Elevator = t.Elevator,
						InternalStaircase = t.InternalStaircase,
						AirConditioning = t.AirConditioning,
						Warehouse = t.Warehouse,
						FloorTypeID = t.FloorTypeID,
						FloorType = context.FloorTypes
							.Where(f => f.FloorTypeID == t.FloorTypeID)
							.Select(f => new FloorTypeDto()
							{
								FloorTypeID = f.FloorTypeID,
								Title = f.Title,
								Description = f.Description,
								IsEnabled = f.IsEnabled,
								IsDeleted = f.IsDeleted
							})
							.FirstOrDefault(),
						PetsWelcome = t.PetsWelcome,
						SecurityDoor = t.SecurityDoor,
						FrameTypeID = t.FrameTypeID,
						FrameType = context.FrameTypes
							.Where(f => f.FrameTypeID == t.FrameTypeID)
							.Select(f => new FrameTypeDto()
							{
								FrameTypeID = f.FrameTypeID,
								Title = f.Title,
								Description = f.Description,
								IsEnabled = f.IsEnabled,
								IsDeleted = f.IsDeleted
							})
							.FirstOrDefault(),
						PowerTypeID = t.PowerTypeID,
						PowerType = context.PowerTypes
							.Where(f => f.PowerTypeID == t.PowerTypeID)
							.Select(f => new PowerTypeDto()
							{
								PowerTypeID = f.PowerTypeID,
								Title = f.Title,
								Description = f.Description,
								IsEnabled = f.IsEnabled,
								IsDeleted = f.IsDeleted
							})
							.FirstOrDefault(),
						DoubleGlazing = t.DoubleGlazing,
						Furnished = t.Furnished,
						Fireplace = t.Fireplace,
						UnderfloorHeating = t.UnderfloorHeating,
						SolarHeating = t.SolarHeating,
						NightCurrent = t.NightCurrent,
						Garret = t.Garret,
						Playroom = t.Playroom,
						SatelliteAntenna = t.SatelliteAntenna,
						Alarm = t.Alarm,
						DoorScreens = t.DoorScreens,
						Airy = t.Airy,
						Painted = t.Painted,
						WithEquipment = t.WithEquipment,
						CableTV = t.CableTV,
						Wiring = t.Wiring,
						LoadingUnloadingElevator = t.LoadingUnloadingElevator,
						SuspendedCeiling = t.SuspendedCeiling,
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
		/// <param name="InteriorFeatureDto">InteriorFeatureDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse InteriorFeatureDto</param>
		/// <returns>SlApiResponse InteriorFeatureDto</returns>
		public async Task<SlApiResponse<InteriorFeatureDto, object>> UpdateDtoById(
			int id,
			InteriorFeatureDto interiorFeatureDto,
			SlApiResponse<InteriorFeatureDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.InteriorFeatures.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(InteriorFeatureDto), id);
				}

#pragma warning disable CS0472 // The result of the expression is always the same
				entity.Elevator = interiorFeatureDto.Elevator != null ? interiorFeatureDto.Elevator : entity.Elevator;
				entity.InternalStaircase = interiorFeatureDto.InternalStaircase != null ? interiorFeatureDto.InternalStaircase : entity.InternalStaircase;
				entity.AirConditioning = interiorFeatureDto.AirConditioning != null ? interiorFeatureDto.AirConditioning : entity.AirConditioning;
				entity.Warehouse = interiorFeatureDto.Warehouse != null ? interiorFeatureDto.Warehouse : entity.Warehouse;
				entity.FloorTypeID = interiorFeatureDto.FloorTypeID != null ? interiorFeatureDto.FloorTypeID : entity.FloorTypeID;
				entity.PetsWelcome = interiorFeatureDto.PetsWelcome != null ? interiorFeatureDto.PetsWelcome : entity.PetsWelcome;
				entity.SecurityDoor = interiorFeatureDto.SecurityDoor != null ? interiorFeatureDto.SecurityDoor : entity.SecurityDoor;
				entity.FrameTypeID = interiorFeatureDto.FrameTypeID != null ? interiorFeatureDto.FrameTypeID : entity.FrameTypeID;
				entity.PowerTypeID = interiorFeatureDto.PowerTypeID != null ? interiorFeatureDto.PowerTypeID : entity.PowerTypeID;
				entity.DoubleGlazing = interiorFeatureDto.DoubleGlazing != null ? interiorFeatureDto.DoubleGlazing : entity.DoubleGlazing;
				entity.Furnished = interiorFeatureDto.Furnished != null ? interiorFeatureDto.Furnished : entity.Furnished;
				entity.Fireplace = interiorFeatureDto.Fireplace != null ? interiorFeatureDto.Fireplace : entity.Fireplace;
				entity.UnderfloorHeating = interiorFeatureDto.UnderfloorHeating != null ? interiorFeatureDto.UnderfloorHeating : entity.UnderfloorHeating;
				entity.SolarHeating = interiorFeatureDto.SolarHeating != null ? interiorFeatureDto.SolarHeating : entity.SolarHeating;
				entity.NightCurrent = interiorFeatureDto.NightCurrent != null ? interiorFeatureDto.NightCurrent : entity.NightCurrent;
				entity.Garret = interiorFeatureDto.Garret != null ? interiorFeatureDto.Garret : entity.Garret;
				entity.Playroom = interiorFeatureDto.Playroom != null ? interiorFeatureDto.Playroom : entity.Playroom;
				entity.SatelliteAntenna = interiorFeatureDto.SatelliteAntenna != null ? interiorFeatureDto.SatelliteAntenna : entity.SatelliteAntenna;
				entity.Alarm = interiorFeatureDto.Alarm != null ? interiorFeatureDto.Alarm : entity.Alarm;
				entity.DoorScreens = interiorFeatureDto.DoorScreens != null ? interiorFeatureDto.DoorScreens : entity.DoorScreens;
				entity.Airy = interiorFeatureDto.Airy != null ? interiorFeatureDto.Airy : entity.Airy;
				entity.Painted = interiorFeatureDto.Painted != null ? interiorFeatureDto.Painted : entity.Painted;
				entity.WithEquipment = interiorFeatureDto.WithEquipment != null ? interiorFeatureDto.WithEquipment : entity.WithEquipment;
				entity.Wiring = interiorFeatureDto.Wiring != null ? interiorFeatureDto.Wiring : entity.Wiring;
				entity.LoadingUnloadingElevator = interiorFeatureDto.LoadingUnloadingElevator != null ? interiorFeatureDto.LoadingUnloadingElevator : entity.LoadingUnloadingElevator;
				entity.SuspendedCeiling = interiorFeatureDto.SuspendedCeiling != null ? interiorFeatureDto.SuspendedCeiling : entity.SuspendedCeiling;
				entity.Description = interiorFeatureDto.Description != null ? interiorFeatureDto.Description : entity.Description;
				entity.IsEnabled = interiorFeatureDto.IsEnabled;
				entity.IsDeleted = interiorFeatureDto.IsDeleted;
#pragma warning restore CS0472 // The result of the expression is always the same

				await context.SaveChangesAsync(cancellationToken);

				response.Data = new InteriorFeatureDto()
				{
					InteriorFeaturesID = entity.InteriorFeaturesID,
					Elevator = entity.Elevator,
					InternalStaircase = entity.InternalStaircase,
					AirConditioning = entity.AirConditioning,
					Warehouse = entity.Warehouse,
					FloorTypeID = entity.FloorTypeID,
					FloorType = context.FloorTypes
							.Where(f => f.FloorTypeID == entity.FloorTypeID)
							.Select(f => new FloorTypeDto()
							{
								FloorTypeID = f.FloorTypeID,
								Title = f.Title,
								Description = f.Description,
								IsEnabled = f.IsEnabled,
								IsDeleted = f.IsDeleted
							})
							.FirstOrDefault(),
					PetsWelcome = entity.PetsWelcome,
					SecurityDoor = entity.SecurityDoor,
					FrameTypeID = entity.FrameTypeID,
					FrameType = context.FrameTypes
							.Where(f => f.FrameTypeID == entity.FrameTypeID)
							.Select(f => new FrameTypeDto()
							{
								FrameTypeID = f.FrameTypeID,
								Title = f.Title,
								Description = f.Description,
								IsEnabled = f.IsEnabled,
								IsDeleted = f.IsDeleted
							})
							.FirstOrDefault(),
					PowerTypeID = entity.PowerTypeID,
					PowerType = context.PowerTypes
							.Where(f => f.PowerTypeID == entity.PowerTypeID)
							.Select(f => new PowerTypeDto()
							{
								PowerTypeID = f.PowerTypeID,
								Title = f.Title,
								Description = f.Description,
								IsEnabled = f.IsEnabled,
								IsDeleted = f.IsDeleted
							})
							.FirstOrDefault(),
					DoubleGlazing = entity.DoubleGlazing,
					Furnished = entity.Furnished,
					Fireplace = entity.Fireplace,
					UnderfloorHeating = entity.UnderfloorHeating,
					SolarHeating = entity.SolarHeating,
					NightCurrent = entity.NightCurrent,
					Garret = entity.Garret,
					Playroom = entity.Playroom,
					SatelliteAntenna = entity.SatelliteAntenna,
					Alarm = entity.Alarm,
					DoorScreens = entity.DoorScreens,
					Airy = entity.Airy,
					Painted = entity.Painted,
					WithEquipment = entity.WithEquipment,
					CableTV = entity.CableTV,
					Wiring = entity.Wiring,
					LoadingUnloadingElevator = entity.LoadingUnloadingElevator,
					SuspendedCeiling = entity.SuspendedCeiling,
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
		/// <param name="InteriorFeatureDto">InteriorFeatureDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse InteriorFeatureDto</param>
		/// <returns>SlApiResponse InteriorFeatureDto</returns>
		public async Task<SlApiResponse<InteriorFeatureDto, object>> AddDto(
			InteriorFeatureDto InteriorFeatureDto,
			SlApiResponse<InteriorFeatureDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				if (InteriorFeatureDto != null)
				{
					var entity = mapper.Map<Domain.Entities.InteriorFeature>(InteriorFeatureDto);
					context.InteriorFeatures.Add(entity);
					await context.SaveChangesAsync(cancellationToken);

					response.Data = new InteriorFeatureDto()
					{
						InteriorFeaturesID = entity.InteriorFeaturesID,
						Elevator = entity.Elevator,
						InternalStaircase = entity.InternalStaircase,
						AirConditioning = entity.AirConditioning,
						Warehouse = entity.Warehouse,
						FloorTypeID = entity.FloorTypeID,
						FloorType = context.FloorTypes
							.Where(f => f.FloorTypeID == entity.FloorTypeID)
							.Select(f => new FloorTypeDto()
							{
								FloorTypeID = f.FloorTypeID,
								Title = f.Title,
								Description = f.Description,
								IsEnabled = f.IsEnabled,
								IsDeleted = f.IsDeleted
							})
							.FirstOrDefault(),
						PetsWelcome = entity.PetsWelcome,
						SecurityDoor = entity.SecurityDoor,
						FrameTypeID = entity.FrameTypeID,
						FrameType = context.FrameTypes
							.Where(f => f.FrameTypeID == entity.FrameTypeID)
							.Select(f => new FrameTypeDto()
							{
								FrameTypeID = f.FrameTypeID,
								Title = f.Title,
								Description = f.Description,
								IsEnabled = f.IsEnabled,
								IsDeleted = f.IsDeleted
							})
							.FirstOrDefault(),
						PowerTypeID = entity.PowerTypeID,
						PowerType = context.PowerTypes
							.Where(f => f.PowerTypeID == entity.PowerTypeID)
							.Select(f => new PowerTypeDto()
							{
								PowerTypeID = f.PowerTypeID,
								Title = f.Title,
								Description = f.Description,
								IsEnabled = f.IsEnabled,
								IsDeleted = f.IsDeleted
							})
							.FirstOrDefault(),
						DoubleGlazing = entity.DoubleGlazing,
						Furnished = entity.Furnished,
						Fireplace = entity.Fireplace,
						UnderfloorHeating = entity.UnderfloorHeating,
						SolarHeating = entity.SolarHeating,
						NightCurrent = entity.NightCurrent,
						Garret = entity.Garret,
						Playroom = entity.Playroom,
						SatelliteAntenna = entity.SatelliteAntenna,
						Alarm = entity.Alarm,
						DoorScreens = entity.DoorScreens,
						Airy = entity.Airy,
						Painted = entity.Painted,
						WithEquipment = entity.WithEquipment,
						CableTV = entity.CableTV,
						Wiring = entity.Wiring,
						LoadingUnloadingElevator = entity.LoadingUnloadingElevator,
						SuspendedCeiling = entity.SuspendedCeiling,
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
		/// <param name="InteriorFeatureDto">InteriorFeatureDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse InteriorFeatureDto</param>
		/// <returns>SlApiResponse InteriorFeatureDto</returns>
		public async Task<SlApiResponse<InteriorFeatureDto, object>> DeleteDtoById(
			int id,
			SlApiResponse<InteriorFeatureDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.InteriorFeatures.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(InteriorFeatureDto), id);
				}

				var deletedDto = mapper.Map<InteriorFeatureDto>(entity);

				context.InteriorFeatures.Remove(entity);

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
		/// <param name="InteriorFeatureDto">InteriorFeatureDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse InteriorFeatureDto</param>
		/// <returns>SlApiResponse InteriorFeatureDto</returns>
		public async Task<SlApiResponse<InteriorFeatureDto, object>> DisableEnableDtoById(
			int id,
			SlApiResponse<InteriorFeatureDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.InteriorFeatures.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(InteriorFeatureDto), id);
				}

				entity.IsDeleted = true;

				await context.SaveChangesAsync(cancellationToken);

				var deactivatedDto = mapper.Map<InteriorFeatureDto>(entity);

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