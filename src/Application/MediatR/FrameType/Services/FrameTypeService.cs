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

namespace CleanArchitecture.Application.MediatR.FrameType.Services
{
	/// <summary>
	/// FrameTypeService class
	/// </summary>
	public class FrameTypeService
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
		/// FrameTypeService constructor
		/// </summary>
		/// <param name="mapper"></param>
		/// <param name="context"></param>
		public FrameTypeService(
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
		/// <param name="responseList">SlApiResponse PaginatedList FrameTypeDto</param>
		/// <returns>SlApiResponse PaginatedList FrameTypeDto</returns>
		public async Task<SlApiResponse<PaginatedList<FrameTypeDto>, object>> GetAllWithPagination(
			SlApiPaginationQuery query,
			SlApiResponse<PaginatedList<FrameTypeDto>, object> responseList
		)
		{
			try
			{
				var result = await context.FrameTypes
					.AsNoTracking()
					.Where(a => a.IsEnabled == true && a.IsDeleted == false)
					.OrderBy(x => x.FrameTypeID)
					.Select(t => new FrameTypeDto()
					{
						FrameTypeID = t.FrameTypeID,
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
		/// <param name="response">SlApiResponse FrameTypeDto</param>
		/// <returns>SlApiResponse FrameTypeDto</returns>
		public async Task<SlApiResponse<FrameTypeDto, object>> GetById(
			int id,
			SlApiResponse<FrameTypeDto, object> response
		)
		{
			try
			{
				var result = await context.FrameTypes
					.AsNoTracking()
					.Where(a =>
						a.IsEnabled == true &&
						a.IsDeleted == false &&
						a.FrameTypeID == id
					)
					.OrderBy(x => x.FrameTypeID)
					.Select(t => new FrameTypeDto()
					{
						FrameTypeID = t.FrameTypeID,
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
		/// <param name="FrameTypeDto">FrameTypeDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse FrameTypeDto</param>
		/// <returns>SlApiResponse FrameTypeDto</returns>
		public async Task<SlApiResponse<FrameTypeDto, object>> UpdateDtoById(
			int id,
			FrameTypeDto frameTypeDto,
			SlApiResponse<FrameTypeDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.FrameTypes.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(FrameTypeDto), id);
				}

#pragma warning disable CS0472 // The result of the expression is always the same
				entity.Title = frameTypeDto.Title != null ? frameTypeDto.Title : entity.Title;
				entity.Description = frameTypeDto.Description != null ? frameTypeDto.Description : entity.Description;
				entity.IsEnabled = frameTypeDto.IsEnabled;
				entity.IsDeleted = frameTypeDto.IsDeleted;
#pragma warning restore CS0472 // The result of the expression is always the same

				await context.SaveChangesAsync(cancellationToken);

				response.Data = new FrameTypeDto()
				{
					FrameTypeID = entity.FrameTypeID,
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
		/// <param name="FrameTypeDto">FrameTypeDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse FrameTypeDto</param>
		/// <returns>SlApiResponse FrameTypeDto</returns>
		public async Task<SlApiResponse<FrameTypeDto, object>> AddDto(
			FrameTypeDto frameTypeDto,
			SlApiResponse<FrameTypeDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				if (frameTypeDto != null)
				{
					var entity = mapper.Map<Domain.Entities.FrameType>(frameTypeDto);
					context.FrameTypes.Add(entity);
					await context.SaveChangesAsync(cancellationToken);

					response.Data = new FrameTypeDto()
					{
						FrameTypeID = entity.FrameTypeID,
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
		/// <param name="FrameTypeDto">FrameTypeDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse FrameTypeDto</param>
		/// <returns>SlApiResponse FrameTypeDto</returns>
		public async Task<SlApiResponse<FrameTypeDto, object>> DeleteDtoById(
			int id,
			SlApiResponse<FrameTypeDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.FrameTypes.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(FrameTypeDto), id);
				}

				var deletedDto = mapper.Map<FrameTypeDto>(entity);

				context.FrameTypes.Remove(entity);

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
		/// <param name="FrameTypeDto">FrameTypeDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse FrameTypeDto</param>
		/// <returns>SlApiResponse FrameTypeDto</returns>
		public async Task<SlApiResponse<FrameTypeDto, object>> DisableEnableDtoById(
			int id,
			SlApiResponse<FrameTypeDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.FrameTypes.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(FrameTypeDto), id);
				}

				entity.IsDeleted = true;

				await context.SaveChangesAsync(cancellationToken);

				var deactivatedDto = mapper.Map<FrameTypeDto>(entity);

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