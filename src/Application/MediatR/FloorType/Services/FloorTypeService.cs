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

namespace CleanArchitecture.Application.MediatR.FloorType.Services
{
	/// <summary>
	/// FloorTypeService class
	/// </summary>
	public class FloorTypeService
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
		/// FloorTypeService constructor
		/// </summary>
		/// <param name="mapper"></param>
		/// <param name="context"></param>
		public FloorTypeService(
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
		/// <param name="responseList">SlApiResponse PaginatedList FloorTypeDto</param>
		/// <returns>SlApiResponse PaginatedList FloorTypeDto</returns>
		public async Task<SlApiResponse<PaginatedList<FloorTypeDto>, object>> GetAllWithPagination(
			SlApiPaginationQuery query,
			SlApiResponse<PaginatedList<FloorTypeDto>, object> responseList
		)
		{
			try
			{
				var result = await context.FloorTypes
					.AsNoTracking()
					.Where(a => a.IsEnabled == true && a.IsDeleted == false)
					.OrderBy(x => x.FloorTypeID)
					.Select(t => new FloorTypeDto()
					{
						FloorTypeID = t.FloorTypeID,
						Title = t.Title,
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
		/// <param name="response">SlApiResponse FloorTypeDto</param>
		/// <returns>SlApiResponse FloorTypeDto</returns>
		public async Task<SlApiResponse<FloorTypeDto, object>> GetById(
			int id,
			SlApiResponse<FloorTypeDto, object> response
		)
		{
			try
			{
				var result = await context.FloorTypes
					.AsNoTracking()
					.Where(a =>
						a.IsEnabled == true &&
						a.IsDeleted == false &&
						a.FloorTypeID == id
					)
					.OrderBy(x => x.FloorTypeID)
					.Select(t => new FloorTypeDto()
					{
						FloorTypeID = t.FloorTypeID,
						Title = t.Title,
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
		/// <param name="FloorTypeDto">FloorTypeDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse FloorTypeDto</param>
		/// <returns>SlApiResponse FloorTypeDto</returns>
		public async Task<SlApiResponse<FloorTypeDto, object>> UpdateDtoById(
			int id,
			FloorTypeDto floorTypeDto,
			SlApiResponse<FloorTypeDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.FloorTypes.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(FloorTypeDto), id);
				}

#pragma warning disable CS0472 // The result of the expression is always the same
				entity.Title = floorTypeDto.Title != null ? floorTypeDto.Title : entity.Title;
				entity.Description = floorTypeDto.Description != null ? floorTypeDto.Description : entity.Description;
				entity.IsEnabled = floorTypeDto.IsEnabled;
				entity.IsDeleted = floorTypeDto.IsDeleted;
#pragma warning restore CS0472 // The result of the expression is always the same

				await context.SaveChangesAsync(cancellationToken);

				response.Data = new FloorTypeDto()
				{
					FloorTypeID = entity.FloorTypeID,
					Title = entity.Title,
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
		/// <param name="FloorTypeDto">FloorTypeDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse FloorTypeDto</param>
		/// <returns>SlApiResponse FloorTypeDto</returns>
		public async Task<SlApiResponse<FloorTypeDto, object>> AddDto(
			FloorTypeDto floorTypeDto,
			SlApiResponse<FloorTypeDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				if (floorTypeDto != null)
				{
					var entity = mapper.Map<Domain.Entities.FloorType>(floorTypeDto);
					context.FloorTypes.Add(entity);
					await context.SaveChangesAsync(cancellationToken);

					response.Data = new FloorTypeDto()
					{
						FloorTypeID = entity.FloorTypeID,
						Title = entity.Title,
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
		/// <param name="FloorTypeDto">FloorTypeDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse FloorTypeDto</param>
		/// <returns>SlApiResponse FloorTypeDto</returns>
		public async Task<SlApiResponse<FloorTypeDto, object>> DeleteDtoById(
			int id,
			SlApiResponse<FloorTypeDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.FloorTypes.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(FloorTypeDto), id);
				}

				var deletedDto = mapper.Map<FloorTypeDto>(entity);

				context.FloorTypes.Remove(entity);

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
		/// <param name="FloorTypeDto">FloorTypeDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse FloorTypeDto</param>
		/// <returns>SlApiResponse FloorTypeDto</returns>
		public async Task<SlApiResponse<FloorTypeDto, object>> DisableEnableDtoById(
			int id,
			SlApiResponse<FloorTypeDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.FloorTypes.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(FloorTypeDto), id);
				}

				entity.IsDeleted = true;

				await context.SaveChangesAsync(cancellationToken);

				var deactivatedDto = mapper.Map<FloorTypeDto>(entity);

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