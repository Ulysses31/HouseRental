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

namespace CleanArchitecture.Application.MediatR.GoogleMapPlace.Services
{
	/// <summary>
	/// GoogleMapPlaceService class
	/// </summary>
	public class GoogleMapPlaceService
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
		/// GoogleMapPlaceService constructor
		/// </summary>
		/// <param name="mapper"></param>
		/// <param name="context"></param>
		public GoogleMapPlaceService(
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
		/// <param name="responseList">SlApiResponse PaginatedList GoogleMapPlaceDto</param>
		/// <returns>SlApiResponse PaginatedList GoogleMapPlaceDto</returns>
		public async Task<SlApiResponse<PaginatedList<GoogleMapPlaceDto>, object>> GetAllWithPagination(
			SlApiPaginationQuery query,
			SlApiResponse<PaginatedList<GoogleMapPlaceDto>, object> responseList
		)
		{
			try
			{
				var result = await context.GoogleMapPlaces
					.AsNoTracking()
					.Where(a => a.IsEnabled == true && a.IsDeleted == false)
					.OrderBy(x => x.GoogleMapPlaceID)
					.Select(t => new GoogleMapPlaceDto()
					{
						GoogleMapPlaceID = t.GoogleMapPlaceID,
						Area = t.Area,
						Latitude = t.Latitude,
						Longitude = t.Longitude,
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
		/// <param name="response">SlApiResponse GoogleMapPlaceDto</param>
		/// <returns>SlApiResponse GoogleMapPlaceDto</returns>
		public async Task<SlApiResponse<GoogleMapPlaceDto, object>> GetById(
			int id,
			SlApiResponse<GoogleMapPlaceDto, object> response
		)
		{
			try
			{
				var result = await context.GoogleMapPlaces
					.AsNoTracking()
					.Where(a =>
						a.IsEnabled == true &&
						a.IsDeleted == false &&
						a.GoogleMapPlaceID == id
					)
					.OrderBy(x => x.GoogleMapPlaceID)
					.Select(t => new GoogleMapPlaceDto()
					{
						GoogleMapPlaceID = t.GoogleMapPlaceID,
						Area = t.Area,
						Latitude = t.Latitude,
						Longitude = t.Longitude,
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
		/// <param name="GoogleMapPlaceDto">GoogleMapPlaceDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse GoogleMapPlaceDto</param>
		/// <returns>SlApiResponse GoogleMapPlaceDto</returns>
		public async Task<SlApiResponse<GoogleMapPlaceDto, object>> UpdateDtoById(
			int id,
			GoogleMapPlaceDto googleMapPlaceDto,
			SlApiResponse<GoogleMapPlaceDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.GoogleMapPlaces.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(GoogleMapPlaceDto), id);
				}

#pragma warning disable CS0472 // The result of the expression is always the same
				entity.Area = googleMapPlaceDto.Area != null ? googleMapPlaceDto.Area : entity.Area;
				entity.Latitude = googleMapPlaceDto.Latitude != null ? googleMapPlaceDto.Latitude : entity.Latitude;
				entity.Longitude = googleMapPlaceDto.Longitude != null ? googleMapPlaceDto.Longitude : entity.Longitude;
				entity.Description = googleMapPlaceDto.Description != null ? googleMapPlaceDto.Description : entity.Description;
				entity.IsEnabled = googleMapPlaceDto.IsEnabled;
				entity.IsDeleted = googleMapPlaceDto.IsDeleted;
#pragma warning restore CS0472 // The result of the expression is always the same

				await context.SaveChangesAsync(cancellationToken);

				response.Data = new GoogleMapPlaceDto()
				{
					GoogleMapPlaceID = entity.GoogleMapPlaceID,
					Area = entity.Area,
					Latitude = entity.Latitude,
					Longitude = entity.Longitude,
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
		/// <param name="GoogleMapPlaceDto">GoogleMapPlaceDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse GoogleMapPlaceDto</param>
		/// <returns>SlApiResponse GoogleMapPlaceDto</returns>
		public async Task<SlApiResponse<GoogleMapPlaceDto, object>> AddDto(
			GoogleMapPlaceDto googleMapPlaceDto,
			SlApiResponse<GoogleMapPlaceDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				if (googleMapPlaceDto != null)
				{
					var entity = mapper.Map<Domain.Entities.GoogleMapPlace>(googleMapPlaceDto);
					context.GoogleMapPlaces.Add(entity);
					await context.SaveChangesAsync(cancellationToken);

					response.Data = new GoogleMapPlaceDto()
					{
						GoogleMapPlaceID = entity.GoogleMapPlaceID,
						Area = entity.Area,
						Latitude = entity.Latitude,
						Longitude = entity.Longitude,
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
		/// <param name="GoogleMapPlaceDto">GoogleMapPlaceDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse GoogleMapPlaceDto</param>
		/// <returns>SlApiResponse GoogleMapPlaceDto</returns>
		public async Task<SlApiResponse<GoogleMapPlaceDto, object>> DeleteDtoById(
			int id,
			SlApiResponse<GoogleMapPlaceDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.GoogleMapPlaces.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(GoogleMapPlaceDto), id);
				}

				var deletedDto = mapper.Map<GoogleMapPlaceDto>(entity);

				context.GoogleMapPlaces.Remove(entity);

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
		/// <param name="GoogleMapPlaceDto">GoogleMapPlaceDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse GoogleMapPlaceDto</param>
		/// <returns>SlApiResponse GoogleMapPlaceDto</returns>
		public async Task<SlApiResponse<GoogleMapPlaceDto, object>> DisableEnableDtoById(
			int id,
			SlApiResponse<GoogleMapPlaceDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.GoogleMapPlaces.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(GoogleMapPlaceDto), id);
				}

				entity.IsDeleted = true;

				await context.SaveChangesAsync(cancellationToken);

				var deactivatedDto = mapper.Map<GoogleMapPlaceDto>(entity);

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