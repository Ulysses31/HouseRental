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

namespace CleanArchitecture.Application.MediatR.PowerType.Services
{
	/// <summary>
	/// PowerTypeService class
	/// </summary>
	public class PowerTypeService
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
		/// PowerTypeService constructor
		/// </summary>
		/// <param name="mapper"></param>
		/// <param name="context"></param>
		public PowerTypeService(
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
		/// <param name="responseList">SlApiResponse PaginatedList PowerTypeDto</param>
		/// <returns>SlApiResponse PaginatedList PowerTypeDto</returns>
		public async Task<SlApiResponse<PaginatedList<PowerTypeDto>, object>> GetAllWithPagination(
			SlApiPaginationQuery query,
			SlApiResponse<PaginatedList<PowerTypeDto>, object> responseList
		)
		{
			try
			{
				var result = await context.PowerTypes
					.AsNoTracking()
					.Where(a => a.IsEnabled == true && a.IsDeleted == false)
					.OrderBy(x => x.PowerTypeID)
					.Select(t => new PowerTypeDto()
					{
						PowerTypeID = t.PowerTypeID,
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
		/// <param name="response">SlApiResponse PowerTypeDto</param>
		/// <returns>SlApiResponse PowerTypeDto</returns>
		public async Task<SlApiResponse<PowerTypeDto, object>> GetById(
			int id,
			SlApiResponse<PowerTypeDto, object> response
		)
		{
			try
			{
				var result = await context.PowerTypes
					.AsNoTracking()
					.Where(a =>
						a.IsEnabled == true &&
						a.IsDeleted == false &&
						a.PowerTypeID == id
					)
					.OrderBy(x => x.PowerTypeID)
					.Select(t => new PowerTypeDto()
					{
						PowerTypeID = t.PowerTypeID,
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
		/// <param name="PowerTypeDto">PowerTypeDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse PowerTypeDto</param>
		/// <returns>SlApiResponse PowerTypeDto</returns>
		public async Task<SlApiResponse<PowerTypeDto, object>> UpdateDtoById(
			int id,
			PowerTypeDto powerTypeDto,
			SlApiResponse<PowerTypeDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.PowerTypes.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(powerTypeDto), id);
				}

#pragma warning disable CS0472 // The result of the expression is always the same
				entity.Title = powerTypeDto.Title != null ? powerTypeDto.Title : entity.Title;
				entity.Description = powerTypeDto.Description != null ? powerTypeDto.Description : entity.Description;
				entity.IsEnabled = powerTypeDto.IsEnabled;
				entity.IsDeleted = powerTypeDto.IsDeleted;
#pragma warning restore CS0472 // The result of the expression is always the same

				await context.SaveChangesAsync(cancellationToken);

				response.Data = new PowerTypeDto()
				{
					PowerTypeID = entity.PowerTypeID,
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
		/// <param name="PowerTypeDto">PowerTypeDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse PowerTypeDto</param>
		/// <returns>SlApiResponse PowerTypeDto</returns>
		public async Task<SlApiResponse<PowerTypeDto, object>> AddDto(
			PowerTypeDto powerTypeDto,
			SlApiResponse<PowerTypeDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				if (powerTypeDto != null)
				{
					var entity = mapper.Map<Domain.Entities.PowerType>(powerTypeDto);
					context.PowerTypes.Add(entity);
					await context.SaveChangesAsync(cancellationToken);

					response.Data = new PowerTypeDto()
					{
						PowerTypeID = entity.PowerTypeID,
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
		/// <param name="PowerTypeDto">PowerTypeDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse PowerTypeDto</param>
		/// <returns>SlApiResponse PowerTypeDto</returns>
		public async Task<SlApiResponse<PowerTypeDto, object>> DeleteDtoById(
			int id,
			SlApiResponse<PowerTypeDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.PowerTypes.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(PowerTypeDto), id);
				}

				var deletedDto = mapper.Map<PowerTypeDto>(entity);

				context.PowerTypes.Remove(entity);

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
		/// <param name="PowerTypeDto">PowerTypeDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse PowerTypeDto</param>
		/// <returns>SlApiResponse PowerTypeDto</returns>
		public async Task<SlApiResponse<PowerTypeDto, object>> DisableEnableDtoById(
			int id,
			SlApiResponse<PowerTypeDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.PowerTypes.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(PowerTypeDto), id);
				}

				entity.IsDeleted = true;

				await context.SaveChangesAsync(cancellationToken);

				var deactivatedDto = mapper.Map<PowerTypeDto>(entity);

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