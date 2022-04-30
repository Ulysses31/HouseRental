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

namespace CleanArchitecture.Application.MediatR.ClassifiedType.Services
{
	/// <summary>
	/// ClassifiedTypeService class
	/// </summary>
	public class ClassifiedTypeService
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
		/// ClassifiedTypeService constructor
		/// </summary>
		/// <param name="mapper"></param>
		/// <param name="context"></param>
		public ClassifiedTypeService(
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
		/// <param name="responseList">SlApiResponse PaginatedList ClassifiedTypeDto</param>
		/// <returns>SlApiResponse PaginatedList ClassifiedTypeDto</returns>
		public async Task<SlApiResponse<PaginatedList<ClassifiedTypeDto>, object>> GetAllWithPagination(
			SlApiPaginationQuery query,
			SlApiResponse<PaginatedList<ClassifiedTypeDto>, object> responseList
		)
		{
			try
			{
				var result = await context.ClassifiedTypes
					.AsNoTracking()
					.Where(a => a.IsEnabled == true && a.IsDeleted == false)
					.OrderBy(x => x.TypeID)
					.Select(t => new ClassifiedTypeDto()
					{
						TypeID = t.TypeID,
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
		/// <param name="response">SlApiResponse ClassifiedTypeDto</param>
		/// <returns>SlApiResponse ClassifiedTypeDto</returns>
		public async Task<SlApiResponse<ClassifiedTypeDto, object>> GetById(
			int id,
			SlApiResponse<ClassifiedTypeDto, object> response
		)
		{
			try
			{
				var result = await context.ClassifiedTypes
					.AsNoTracking()
					.Where(a =>
						a.IsEnabled == true &&
						a.IsDeleted == false &&
						a.TypeID == id
					)
					.OrderBy(x => x.TypeID)
					.Select(t => new ClassifiedTypeDto()
					{
						TypeID = t.TypeID,
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
		/// <param name="ClassifiedTypeDto">ClassifiedTypeDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse ClassifiedTypeDto</param>
		/// <returns>SlApiResponse ClassifiedTypeDto</returns>
		public async Task<SlApiResponse<ClassifiedTypeDto, object>> UpdateDtoById(
			int id,
			ClassifiedTypeDto classifiedTypeDto,
			SlApiResponse<ClassifiedTypeDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.ClassifiedTypes.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(classifiedTypeDto), id);
				}

#pragma warning disable CS0472 // The result of the expression is always the same
				entity.Title = classifiedTypeDto.Title != null ? classifiedTypeDto.Title : entity.Title;
				entity.Description = classifiedTypeDto.Description != null ? classifiedTypeDto.Description : entity.Description;
				entity.IsEnabled = classifiedTypeDto.IsEnabled;
				entity.IsDeleted = classifiedTypeDto.IsDeleted;
#pragma warning restore CS0472 // The result of the expression is always the same

				await context.SaveChangesAsync(cancellationToken);

				response.Data = new ClassifiedTypeDto()
				{
					TypeID = entity.TypeID,
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
		/// <param name="ClassifiedTypeDto">ClassifiedTypeDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse ClassifiedTypeDto</param>
		/// <returns>SlApiResponse ClassifiedTypeDto</returns>
		public async Task<SlApiResponse<ClassifiedTypeDto, object>> AddDto(
			ClassifiedTypeDto classifiedTypeDto,
			SlApiResponse<ClassifiedTypeDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				if (classifiedTypeDto != null)
				{
					var entity = mapper.Map<Domain.Entities.ClassifiedType>(classifiedTypeDto);
					context.ClassifiedTypes.Add(entity);
					await context.SaveChangesAsync(cancellationToken);

					response.Data = new ClassifiedTypeDto()
					{
						TypeID = entity.TypeID,
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
		/// <param name="ClassifiedTypeDto">ClassifiedTypeDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse ClassifiedTypeDto</param>
		/// <returns>SlApiResponse ClassifiedTypeDto</returns>
		public async Task<SlApiResponse<ClassifiedTypeDto, object>> DeleteDtoById(
			int id,
			SlApiResponse<ClassifiedTypeDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.ClassifiedTypes.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(ClassifiedTypeDto), id);
				}

				var deletedDto = mapper.Map<ClassifiedTypeDto>(entity);

				context.ClassifiedTypes.Remove(entity);

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
		/// <param name="ClassifiedTypeDto">ClassifiedTypeDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse ClassifiedTypeDto</param>
		/// <returns>SlApiResponse ClassifiedTypeDto</returns>
		public async Task<SlApiResponse<ClassifiedTypeDto, object>> DisableEnableDtoById(
			int id,
			SlApiResponse<ClassifiedTypeDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.ClassifiedTypes.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(ClassifiedTypeDto), id);
				}

				entity.IsDeleted = true;

				await context.SaveChangesAsync(cancellationToken);

				var deactivatedDto = mapper.Map<ClassifiedTypeDto>(entity);

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