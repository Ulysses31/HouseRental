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

namespace CleanArchitecture.Application.MediatR.ClassifiedPurpose.Services
{
	/// <summary>
	/// ClassifiedPurposeService class
	/// </summary>
	public class ClassifiedPurposeService
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
		/// ClassifiedPurposeService constructor
		/// </summary>
		/// <param name="mapper"></param>
		/// <param name="context"></param>
		public ClassifiedPurposeService(
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
		/// <param name="responseList">SlApiResponse PaginatedList ClassifiedPurposeDto</param>
		/// <returns>SlApiResponse PaginatedList ClassifiedPurposeDto</returns>
		public async Task<SlApiResponse<PaginatedList<ClassifiedPurposeDto>, object>> GetAllWithPagination(
			SlApiPaginationQuery query,
			SlApiResponse<PaginatedList<ClassifiedPurposeDto>, object> responseList
		)
		{
			try
			{
				var result = await context.ClassifiedPurposes
					.AsNoTracking()
					.Where(a => a.IsEnabled == true && a.IsDeleted == false)
					.OrderBy(x => x.PurposeID)
					.Select(t => new ClassifiedPurposeDto()
					{
						PurposeID = t.PurposeID,
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
		/// <param name="response">SlApiResponse ClassifiedPurposeDto</param>
		/// <returns>SlApiResponse ClassifiedPurposeDto</returns>
		public async Task<SlApiResponse<ClassifiedPurposeDto, object>> GetById(
			int id,
			SlApiResponse<ClassifiedPurposeDto, object> response
		)
		{
			try
			{
				var result = await context.ClassifiedPurposes
					.AsNoTracking()
					.Where(a =>
						a.IsEnabled == true &&
						a.IsDeleted == false &&
						a.PurposeID == id
					)
					.OrderBy(x => x.PurposeID)
					.Select(t => new ClassifiedPurposeDto()
					{
						PurposeID = t.PurposeID,
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
		/// <param name="ClassifiedPurposeDto">ClassifiedPurposeDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse ClassifiedPurposeDto</param>
		/// <returns>SlApiResponse ClassifiedPurposeDto</returns>
		public async Task<SlApiResponse<ClassifiedPurposeDto, object>> UpdateDtoById(
			int id,
			ClassifiedPurposeDto classifiedPurposeDto,
			SlApiResponse<ClassifiedPurposeDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.ClassifiedPurposes.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(classifiedPurposeDto), id);
				}

#pragma warning disable CS0472 // The result of the expression is always the same
				entity.Title = classifiedPurposeDto.Title != null ? classifiedPurposeDto.Title : entity.Title;
				entity.Description = classifiedPurposeDto.Description != null ? classifiedPurposeDto.Description : entity.Description;
				entity.IsEnabled = classifiedPurposeDto.IsEnabled;
				entity.IsDeleted = classifiedPurposeDto.IsDeleted;
#pragma warning restore CS0472 // The result of the expression is always the same

				await context.SaveChangesAsync(cancellationToken);

				response.Data = new ClassifiedPurposeDto()
				{
					PurposeID = entity.PurposeID,
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
		/// <param name="ClassifiedPurposeDto">ClassifiedPurposeDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse ClassifiedPurposeDto</param>
		/// <returns>SlApiResponse ClassifiedPurposeDto</returns>
		public async Task<SlApiResponse<ClassifiedPurposeDto, object>> AddDto(
			ClassifiedPurposeDto classifiedPurposeDto,
			SlApiResponse<ClassifiedPurposeDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				if (classifiedPurposeDto != null)
				{
					var entity = mapper.Map<Domain.Entities.ClassifiedPurpose>(classifiedPurposeDto);
					context.ClassifiedPurposes.Add(entity);
					await context.SaveChangesAsync(cancellationToken);

					response.Data = new ClassifiedPurposeDto()
					{
						PurposeID = entity.PurposeID,
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
		/// <param name="ClassifiedPurposeDto">ClassifiedPurposeDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse ClassifiedPurposeDto</param>
		/// <returns>SlApiResponse ClassifiedPurposeDto</returns>
		public async Task<SlApiResponse<ClassifiedPurposeDto, object>> DeleteDtoById(
			int id,
			SlApiResponse<ClassifiedPurposeDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.ClassifiedPurposes.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(ClassifiedPurposeDto), id);
				}

				var deletedDto = mapper.Map<ClassifiedPurposeDto>(entity);

				context.ClassifiedPurposes.Remove(entity);

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
		/// <param name="ClassifiedPurposeDto">ClassifiedPurposeDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse ClassifiedPurposeDto</param>
		/// <returns>SlApiResponse ClassifiedPurposeDto</returns>
		public async Task<SlApiResponse<ClassifiedPurposeDto, object>> DisableEnableDtoById(
			int id,
			SlApiResponse<ClassifiedPurposeDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.ClassifiedPurposes.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(ClassifiedPurposeDto), id);
				}

				entity.IsDeleted = true;

				await context.SaveChangesAsync(cancellationToken);

				var deactivatedDto = mapper.Map<ClassifiedPurposeDto>(entity);

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