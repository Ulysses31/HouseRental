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

namespace CleanArchitecture.Application.MediatR.FloorNo.Services
{
	/// <summary>
	/// FloorNoService class
	/// </summary>
	public class FloorNoService
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
		/// FloorNoService constructor
		/// </summary>
		/// <param name="mapper"></param>
		/// <param name="context"></param>
		public FloorNoService(
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
		/// <param name="responseList">SlApiResponse PaginatedList FloorNoDto</param>
		/// <returns>SlApiResponse PaginatedList FloorNoDto</returns>
		public async Task<SlApiResponse<PaginatedList<FloorNoDto>, object>> GetAllWithPagination(
			SlApiPaginationQuery query,
			SlApiResponse<PaginatedList<FloorNoDto>, object> responseList
		)
		{
			try
			{
				var result = await context.FloorNos
					.AsNoTracking()
					.Where(a => a.IsEnabled == true && a.IsDeleted == false)
					.OrderBy(x => x.FloorNoID)
					.Select(t => new FloorNoDto()
					{
						FloorNoID = t.FloorNoID,
						FloorNoValue = t.FloorNoValue,
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
		/// <param name="response">SlApiResponse FloorNoDto</param>
		/// <returns>SlApiResponse FloorNoDto</returns>
		public async Task<SlApiResponse<FloorNoDto, object>> GetById(
			int id,
			SlApiResponse<FloorNoDto, object> response
		)
		{
			try
			{
				var result = await context.FloorNos
					.AsNoTracking()
					.Where(a =>
						a.IsEnabled == true &&
						a.IsDeleted == false &&
						a.FloorNoID == id
					)
					.OrderBy(x => x.FloorNoID)
					.Select(t => new FloorNoDto()
					{
						FloorNoID = t.FloorNoID,
						FloorNoValue = t.FloorNoValue,
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
		/// <param name="FloorNoDto">FloorNoDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse FloorNoDto</param>
		/// <returns>SlApiResponse FloorNoDto</returns>
		public async Task<SlApiResponse<FloorNoDto, object>> UpdateDtoById(
			int id,
			FloorNoDto floorNoDto,
			SlApiResponse<FloorNoDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.FloorNos.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(FloorNoDto), id);
				}

#pragma warning disable CS0472 // The result of the expression is always the same
				entity.FloorNoValue = floorNoDto.FloorNoValue != null ? floorNoDto.FloorNoValue : entity.FloorNoValue;
				entity.Description = floorNoDto.Description != null ? floorNoDto.Description : entity.Description;
				entity.IsEnabled = floorNoDto.IsEnabled;
				entity.IsDeleted = floorNoDto.IsDeleted;
#pragma warning restore CS0472 // The result of the expression is always the same

				await context.SaveChangesAsync(cancellationToken);

				response.Data = new FloorNoDto()
				{
					FloorNoID = entity.FloorNoID,
					FloorNoValue = entity.FloorNoValue,
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
		/// <param name="FloorNoDto">FloorNoDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse FloorNoDto</param>
		/// <returns>SlApiResponse FloorNoDto</returns>
		public async Task<SlApiResponse<FloorNoDto, object>> AddDto(
			FloorNoDto floorNoDto,
			SlApiResponse<FloorNoDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				if (floorNoDto != null)
				{
					var entity = mapper.Map<Domain.Entities.FloorNo>(floorNoDto);
					context.FloorNos.Add(entity);
					await context.SaveChangesAsync(cancellationToken);

					response.Data = new FloorNoDto()
					{
						FloorNoID = entity.FloorNoID,
						FloorNoValue = entity.FloorNoValue,
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
		/// <param name="FloorNoDto">FloorNoDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse FloorNoDto</param>
		/// <returns>SlApiResponse FloorNoDto</returns>
		public async Task<SlApiResponse<FloorNoDto, object>> DeleteDtoById(
			int id,
			SlApiResponse<FloorNoDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.FloorNos.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(FloorNoDto), id);
				}

				var deletedDto = mapper.Map<FloorNoDto>(entity);

				context.FloorNos.Remove(entity);

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
		/// <param name="FloorNoDto">FloorNoDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse FloorNoDto</param>
		/// <returns>SlApiResponse FloorNoDto</returns>
		public async Task<SlApiResponse<FloorNoDto, object>> DisableEnableDtoById(
			int id,
			SlApiResponse<FloorNoDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.FloorNos.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(FloorNoDto), id);
				}

				entity.IsDeleted = true;

				await context.SaveChangesAsync(cancellationToken);

				var deactivatedDto = mapper.Map<FloorNoDto>(entity);

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