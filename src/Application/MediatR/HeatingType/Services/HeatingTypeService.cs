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

namespace CleanArchitecture.Application.MediatR.HeatingType.Services
{
	/// <summary>
	/// HeatingTypeService class
	/// </summary>
	public class HeatingTypeService
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
		/// HeatingTypeService constructor
		/// </summary>
		/// <param name="mapper"></param>
		/// <param name="context"></param>
		public HeatingTypeService(
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
		/// <param name="responseList">SlApiResponse PaginatedList HeatingTypeDto</param>
		/// <returns>SlApiResponse PaginatedList HeatingTypeDto</returns>
		public async Task<SlApiResponse<PaginatedList<HeatingTypeDto>, object>> GetAllWithPagination(
			SlApiPaginationQuery query,
			SlApiResponse<PaginatedList<HeatingTypeDto>, object> responseList
		)
		{
			try
			{
				var result = await context.HeatingTypes
					.AsNoTracking()
					.Where(a => a.IsEnabled == true && a.IsDeleted == false)
					.OrderBy(x => x.HeatingTypeID)
					.Select(t => new HeatingTypeDto()
					{
						HeatingTypeID = t.HeatingTypeID,
						HeatingTypeValue = t.HeatingTypeValue,
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
		/// <param name="response">SlApiResponse HeatingTypeDto</param>
		/// <returns>SlApiResponse HeatingTypeDto</returns>
		public async Task<SlApiResponse<HeatingTypeDto, object>> GetById(
			int id,
			SlApiResponse<HeatingTypeDto, object> response
		)
		{
			try
			{
				var result = await context.HeatingTypes
					.AsNoTracking()
					.Where(a =>
						a.IsEnabled == true &&
						a.IsDeleted == false &&
						a.HeatingTypeID == id
					)
					.OrderBy(x => x.HeatingTypeID)
					.Select(t => new HeatingTypeDto()
					{
						HeatingTypeID = t.HeatingTypeID,
						HeatingTypeValue = t.HeatingTypeValue,
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
		/// <param name="HeatingTypeDto">HeatingTypeDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse HeatingTypeDto</param>
		/// <returns>SlApiResponse HeatingTypeDto</returns>
		public async Task<SlApiResponse<HeatingTypeDto, object>> UpdateDtoById(
			int id,
			HeatingTypeDto heatingTypeDto,
			SlApiResponse<HeatingTypeDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.HeatingTypes.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(HeatingTypeDto), id);
				}

#pragma warning disable CS0472 // The result of the expression is always the same
				entity.HeatingTypeValue = heatingTypeDto.HeatingTypeValue != null ? heatingTypeDto.HeatingTypeValue : entity.HeatingTypeValue;
				entity.Description = heatingTypeDto.Description != null ? heatingTypeDto.Description : entity.Description;
				entity.IsEnabled = heatingTypeDto.IsEnabled;
				entity.IsDeleted = heatingTypeDto.IsDeleted;
#pragma warning restore CS0472 // The result of the expression is always the same

				await context.SaveChangesAsync(cancellationToken);

				response.Data = new HeatingTypeDto()
				{
					HeatingTypeID = entity.HeatingTypeID,
					HeatingTypeValue = entity.HeatingTypeValue,
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
		/// <param name="HeatingTypeDto">HeatingTypeDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse HeatingTypeDto</param>
		/// <returns>SlApiResponse HeatingTypeDto</returns>
		public async Task<SlApiResponse<HeatingTypeDto, object>> AddDto(
			HeatingTypeDto heatingTypeDto,
			SlApiResponse<HeatingTypeDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				if (heatingTypeDto != null)
				{
					var entity = mapper.Map<Domain.Entities.HeatingType>(heatingTypeDto);
					context.HeatingTypes.Add(entity);
					await context.SaveChangesAsync(cancellationToken);

					response.Data = new HeatingTypeDto()
					{
						HeatingTypeID = entity.HeatingTypeID,
						HeatingTypeValue = entity.HeatingTypeValue,
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
		/// <param name="HeatingTypeDto">HeatingTypeDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse HeatingTypeDto</param>
		/// <returns>SlApiResponse HeatingTypeDto</returns>
		public async Task<SlApiResponse<HeatingTypeDto, object>> DeleteDtoById(
			int id,
			SlApiResponse<HeatingTypeDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.HeatingTypes.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(HeatingTypeDto), id);
				}

				var deletedDto = mapper.Map<HeatingTypeDto>(entity);

				context.HeatingTypes.Remove(entity);

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
		/// <param name="HeatingTypeDto">HeatingTypeDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse HeatingTypeDto</param>
		/// <returns>SlApiResponse HeatingTypeDto</returns>
		public async Task<SlApiResponse<HeatingTypeDto, object>> DisableEnableDtoById(
			int id,
			SlApiResponse<HeatingTypeDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.HeatingTypes.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(HeatingTypeDto), id);
				}

				entity.IsDeleted = true;

				await context.SaveChangesAsync(cancellationToken);

				var deactivatedDto = mapper.Map<HeatingTypeDto>(entity);

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