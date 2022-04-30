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

namespace CleanArchitecture.Application.MediatR.HeatingSystem.Services
{
	/// <summary>
	/// HeatingSystemService class
	/// </summary>
	public class HeatingSystemService
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
		/// HeatingSystemService constructor
		/// </summary>
		/// <param name="mapper"></param>
		/// <param name="context"></param>
		public HeatingSystemService(
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
		/// <param name="responseList">SlApiResponse PaginatedList HeatingSystemDto</param>
		/// <returns>SlApiResponse PaginatedList HeatingSystemDto</returns>
		public async Task<SlApiResponse<PaginatedList<HeatingSystemDto>, object>> GetAllWithPagination(
			SlApiPaginationQuery query,
			SlApiResponse<PaginatedList<HeatingSystemDto>, object> responseList
		)
		{
			try
			{
				var result = await context.HeatingSystems
					.AsNoTracking()
					.Where(a => a.IsEnabled == true && a.IsDeleted == false)
					.OrderBy(x => x.HeatingSystemID)
					.Select(t => new HeatingSystemDto()
					{
						HeatingSystemID = t.HeatingSystemID,
						HeatingSystemValue = t.HeatingSystemValue,
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
		/// <param name="response">SlApiResponse HeatingSystemDto</param>
		/// <returns>SlApiResponse HeatingSystemDto</returns>
		public async Task<SlApiResponse<HeatingSystemDto, object>> GetById(
			int id,
			SlApiResponse<HeatingSystemDto, object> response
		)
		{
			try
			{
				var result = await context.HeatingSystems
					.AsNoTracking()
					.Where(a =>
						a.IsEnabled == true &&
						a.IsDeleted == false &&
						a.HeatingSystemID == id
					)
					.OrderBy(x => x.HeatingSystemID)
					.Select(t => new HeatingSystemDto()
					{
						HeatingSystemID = t.HeatingSystemID,
						HeatingSystemValue = t.HeatingSystemValue,
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
		/// <param name="HeatingSystemDto">HeatingSystemDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse HeatingSystemDto</param>
		/// <returns>SlApiResponse HeatingSystemDto</returns>
		public async Task<SlApiResponse<HeatingSystemDto, object>> UpdateDtoById(
			int id,
			HeatingSystemDto heatingSystemDto,
			SlApiResponse<HeatingSystemDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.HeatingSystems.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(HeatingSystemDto), id);
				}

#pragma warning disable CS0472 // The result of the expression is always the same
				entity.HeatingSystemValue = heatingSystemDto.HeatingSystemValue != null ? heatingSystemDto.HeatingSystemValue : entity.HeatingSystemValue;
				entity.Description = heatingSystemDto.Description != null ? heatingSystemDto.Description : entity.Description;
				entity.IsEnabled = heatingSystemDto.IsEnabled;
				entity.IsDeleted = heatingSystemDto.IsDeleted;
#pragma warning restore CS0472 // The result of the expression is always the same

				await context.SaveChangesAsync(cancellationToken);

				response.Data = new HeatingSystemDto()
				{
					HeatingSystemID = entity.HeatingSystemID,
					HeatingSystemValue = entity.HeatingSystemValue,
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
		/// <param name="HeatingSystemDto">HeatingSystemDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse HeatingSystemDto</param>
		/// <returns>SlApiResponse HeatingSystemDto</returns>
		public async Task<SlApiResponse<HeatingSystemDto, object>> AddDto(
			HeatingSystemDto heatingSystemDto,
			SlApiResponse<HeatingSystemDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				if (heatingSystemDto != null)
				{
					var entity = mapper.Map<Domain.Entities.HeatingSystem>(heatingSystemDto);
					context.HeatingSystems.Add(entity);
					await context.SaveChangesAsync(cancellationToken);

					response.Data = new HeatingSystemDto()
					{
						HeatingSystemID = entity.HeatingSystemID,
						HeatingSystemValue = entity.HeatingSystemValue,
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
		/// <param name="HeatingSystemDto">HeatingSystemDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse HeatingSystemDto</param>
		/// <returns>SlApiResponse HeatingSystemDto</returns>
		public async Task<SlApiResponse<HeatingSystemDto, object>> DeleteDtoById(
			int id,
			SlApiResponse<HeatingSystemDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.HeatingSystems.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(HeatingSystemDto), id);
				}

				var deletedDto = mapper.Map<HeatingSystemDto>(entity);

				context.HeatingSystems.Remove(entity);

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
		/// <param name="HeatingSystemDto">HeatingSystemDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse HeatingSystemDto</param>
		/// <returns>SlApiResponse HeatingSystemDto</returns>
		public async Task<SlApiResponse<HeatingSystemDto, object>> DisableEnableDtoById(
			int id,
			SlApiResponse<HeatingSystemDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.HeatingSystems.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(HeatingSystemDto), id);
				}

				entity.IsDeleted = true;

				await context.SaveChangesAsync(cancellationToken);

				var deactivatedDto = mapper.Map<HeatingSystemDto>(entity);

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