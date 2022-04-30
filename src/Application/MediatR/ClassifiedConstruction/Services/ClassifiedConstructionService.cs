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

namespace CleanArchitecture.Application.MediatR.ClassifiedConstruction.Services
{
	/// <summary>
	/// ClassifiedConstructionService class
	/// </summary>
	public class ClassifiedConstructionService
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
		/// ClassifiedConstructionService constructor
		/// </summary>
		/// <param name="mapper"></param>
		/// <param name="context"></param>
		public ClassifiedConstructionService(
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
		/// <param name="responseList">SlApiResponse PaginatedList ClassifiedConstructionDto</param>
		/// <returns>SlApiResponse PaginatedList ClassifiedConstructionDto</returns>
		public async Task<SlApiResponse<PaginatedList<ClassifiedConstructionDto>, object>> GetAllWithPagination(
			SlApiPaginationQuery query,
			SlApiResponse<PaginatedList<ClassifiedConstructionDto>, object> responseList
		)
		{
			try
			{
				var result = await context.ClassifiedConstructions
					.AsNoTracking()
					.Where(a => a.IsEnabled == true && a.IsDeleted == false)
					.OrderBy(x => x.ClassifiedConstructionID)
					.Select(t => new ClassifiedConstructionDto()
					{
						ClassifiedConstructionID = t.ClassifiedConstructionID,
						PentHouse = t.PentHouse,
						NewlyBuilt = t.NewlyBuilt,
						Renovated = t.Renovated,
						NeedsToBeRenovated = t.NeedsToBeRenovated,
						NeoClassical = t.NeoClassical,
						Preserved = t.Preserved,
						Incomplete = t.Incomplete,
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
		/// <param name="response">SlApiResponse ClassifiedConstructionDto</param>
		/// <returns>SlApiResponse ClassifiedConstructionDto</returns>
		public async Task<SlApiResponse<ClassifiedConstructionDto, object>> GetById(
			int id,
			SlApiResponse<ClassifiedConstructionDto, object> response
		)
		{
			try
			{
				var result = await context.ClassifiedConstructions
					.AsNoTracking()
					.Where(a =>
						a.IsEnabled == true &&
						a.IsDeleted == false &&
						a.ClassifiedConstructionID == id
					)
					.OrderBy(x => x.ClassifiedConstructionID)
					.Select(t => new ClassifiedConstructionDto()
					{
						ClassifiedConstructionID = t.ClassifiedConstructionID,
						PentHouse = t.PentHouse,
						NewlyBuilt = t.NewlyBuilt,
						Renovated = t.Renovated,
						NeedsToBeRenovated = t.NeedsToBeRenovated,
						NeoClassical = t.NeoClassical,
						Preserved = t.Preserved,
						Incomplete = t.Incomplete,
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
		/// <param name="ClassifiedConstructionDto">ClassifiedConstructionDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse ClassifiedConstructionDto</param>
		/// <returns>SlApiResponse ClassifiedConstructionDto</returns>
		public async Task<SlApiResponse<ClassifiedConstructionDto, object>> UpdateDtoById(
			int id,
			ClassifiedConstructionDto classifiedConstructionDto,
			SlApiResponse<ClassifiedConstructionDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.ClassifiedConstructions.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(classifiedConstructionDto), id);
				}

#pragma warning disable CS0472 // The result of the expression is always the same
				entity.PentHouse = classifiedConstructionDto.PentHouse != null ? classifiedConstructionDto.PentHouse : entity.PentHouse;
				entity.NewlyBuilt = classifiedConstructionDto.NewlyBuilt != null ? classifiedConstructionDto.NewlyBuilt : entity.NewlyBuilt;
				entity.Renovated = classifiedConstructionDto.Renovated != null ? classifiedConstructionDto.Renovated : entity.Renovated;
				entity.NeedsToBeRenovated = classifiedConstructionDto.NeedsToBeRenovated != null ? classifiedConstructionDto.NeedsToBeRenovated : entity.NeedsToBeRenovated;
				entity.NeoClassical = classifiedConstructionDto.NeoClassical != null ? classifiedConstructionDto.NeoClassical : entity.NeoClassical;
				entity.Preserved = classifiedConstructionDto.Preserved != null ? classifiedConstructionDto.Preserved : entity.Preserved;
				entity.Incomplete = classifiedConstructionDto.Incomplete != null ? classifiedConstructionDto.Incomplete : entity.Incomplete;
				entity.Description = classifiedConstructionDto.Description != null ? classifiedConstructionDto.Description : entity.Description;
				entity.IsEnabled = classifiedConstructionDto.IsEnabled;
				entity.IsDeleted = classifiedConstructionDto.IsDeleted;
#pragma warning restore CS0472 // The result of the expression is always the same

				await context.SaveChangesAsync(cancellationToken);

				response.Data = new ClassifiedConstructionDto()
				{
					ClassifiedConstructionID = entity.ClassifiedConstructionID,
					Incomplete = entity.Incomplete,
					NeedsToBeRenovated = entity.NeedsToBeRenovated,
					NeoClassical = entity.NeoClassical,
					NewlyBuilt = entity.NewlyBuilt,
					PentHouse = entity.PentHouse,
					Preserved = entity.Preserved,
					Renovated = entity.Renovated,
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
		/// <param name="ClassifiedConstructionDto">ClassifiedConstructionDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse ClassifiedConstructionDto</param>
		/// <returns>SlApiResponse ClassifiedConstructionDto</returns>
		public async Task<SlApiResponse<ClassifiedConstructionDto, object>> AddDto(
			ClassifiedConstructionDto classifiedConstructionDto,
			SlApiResponse<ClassifiedConstructionDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				if (classifiedConstructionDto != null)
				{
					var entity = mapper.Map<Domain.Entities.ClassifiedConstruction>(classifiedConstructionDto);
					context.ClassifiedConstructions.Add(entity);
					await context.SaveChangesAsync(cancellationToken);

					response.Data = new ClassifiedConstructionDto()
					{
						ClassifiedConstructionID = entity.ClassifiedConstructionID,
						Incomplete = entity.Incomplete,
						NeedsToBeRenovated = entity.NeedsToBeRenovated,
						NeoClassical = entity.NeoClassical,
						NewlyBuilt = entity.NewlyBuilt,
						PentHouse = entity.PentHouse,
						Preserved = entity.Preserved,
						Renovated = entity.Renovated,
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
		/// <param name="ClassifiedConstructionDto">ClassifiedConstructionDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse ClassifiedConstructionDto</param>
		/// <returns>SlApiResponse ClassifiedConstructionDto</returns>
		public async Task<SlApiResponse<ClassifiedConstructionDto, object>> DeleteDtoById(
			int id,
			SlApiResponse<ClassifiedConstructionDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.ClassifiedConstructions.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(ClassifiedConstructionDto), id);
				}

				var deletedDto = mapper.Map<ClassifiedConstructionDto>(entity);

				context.ClassifiedConstructions.Remove(entity);

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
		/// <param name="ClassifiedConstructionDto">ClassifiedConstructionDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse ClassifiedConstructionDto</param>
		/// <returns>SlApiResponse ClassifiedConstructionDto</returns>
		public async Task<SlApiResponse<ClassifiedConstructionDto, object>> DisableEnableDtoById(
			int id,
			SlApiResponse<ClassifiedConstructionDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.ClassifiedConstructions.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(ClassifiedConstructionDto), id);
				}

				entity.IsDeleted = true;

				await context.SaveChangesAsync(cancellationToken);

				var deactivatedDto = mapper.Map<ClassifiedConstructionDto>(entity);

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