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

namespace CleanArchitecture.Application.MediatR.EnergyClass.Services
{
	/// <summary>
	/// EnergyClassService class
	/// </summary>
	public class EnergyClassService
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
		/// EnergyClassService constructor
		/// </summary>
		/// <param name="mapper"></param>
		/// <param name="context"></param>
		public EnergyClassService(
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
		/// <param name="responseList">SlApiResponse PaginatedList EnergyClassDto</param>
		/// <returns>SlApiResponse PaginatedList EnergyClassDto</returns>
		public async Task<SlApiResponse<PaginatedList<EnergyClassDto>, object>> GetAllWithPagination(
			SlApiPaginationQuery query,
			SlApiResponse<PaginatedList<EnergyClassDto>, object> responseList
		)
		{
			try
			{
				var result = await context.EnergyClasses
					.AsNoTracking()
					.Where(a => a.IsEnabled == true && a.IsDeleted == false)
					.OrderBy(x => x.EnergyClassID)
					.Select(t => new EnergyClassDto()
					{
						EnergyClassID = t.EnergyClassID,
						EnergyClassValue = t.EnergyClassValue,
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
		/// <param name="response">SlApiResponse EnergyClassDto</param>
		/// <returns>SlApiResponse EnergyClassDto</returns>
		public async Task<SlApiResponse<EnergyClassDto, object>> GetById(
			int id,
			SlApiResponse<EnergyClassDto, object> response
		)
		{
			try
			{
				var result = await context.EnergyClasses
					.AsNoTracking()
					.Where(a =>
						a.IsEnabled == true &&
						a.IsDeleted == false &&
						a.EnergyClassID == id
					)
					.OrderBy(x => x.EnergyClassID)
					.Select(t => new EnergyClassDto()
					{
						EnergyClassID = t.EnergyClassID,
						EnergyClassValue = t.EnergyClassValue,
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
		/// <param name="EnergyClassDto">EnergyClassDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse EnergyClassDto</param>
		/// <returns>SlApiResponse EnergyClassDto</returns>
		public async Task<SlApiResponse<EnergyClassDto, object>> UpdateDtoById(
			int id,
			EnergyClassDto EnergyClassDto,
			SlApiResponse<EnergyClassDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.EnergyClasses.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(EnergyClassDto), id);
				}

#pragma warning disable CS0472 // The result of the expression is always the same
				entity.EnergyClassValue = EnergyClassDto.EnergyClassValue != null ? EnergyClassDto.EnergyClassValue : entity.EnergyClassValue;
				entity.Description = EnergyClassDto.Description != null ? EnergyClassDto.Description : entity.Description;
				entity.IsEnabled = EnergyClassDto.IsEnabled;
				entity.IsDeleted = EnergyClassDto.IsDeleted;
#pragma warning restore CS0472 // The result of the expression is always the same

				await context.SaveChangesAsync(cancellationToken);

				response.Data = new EnergyClassDto()
				{
					EnergyClassID = entity.EnergyClassID,
					EnergyClassValue = entity.EnergyClassValue,
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
		/// <param name="EnergyClassDto">EnergyClassDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse EnergyClassDto</param>
		/// <returns>SlApiResponse EnergyClassDto</returns>
		public async Task<SlApiResponse<EnergyClassDto, object>> AddDto(
			EnergyClassDto EnergyClassDto,
			SlApiResponse<EnergyClassDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				if (EnergyClassDto != null)
				{
					var entity = mapper.Map<Domain.Entities.EnergyClass>(EnergyClassDto);
					context.EnergyClasses.Add(entity);
					await context.SaveChangesAsync(cancellationToken);

					response.Data = new EnergyClassDto()
					{
						EnergyClassID = entity.EnergyClassID,
						EnergyClassValue = entity.EnergyClassValue,
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
		/// <param name="EnergyClassDto">EnergyClassDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse EnergyClassDto</param>
		/// <returns>SlApiResponse EnergyClassDto</returns>
		public async Task<SlApiResponse<EnergyClassDto, object>> DeleteDtoById(
			int id,
			SlApiResponse<EnergyClassDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.EnergyClasses.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(EnergyClassDto), id);
				}

				var deletedDto = mapper.Map<EnergyClassDto>(entity);

				context.EnergyClasses.Remove(entity);

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
		/// <param name="EnergyClassDto">EnergyClassDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse EnergyClassDto</param>
		/// <returns>SlApiResponse EnergyClassDto</returns>
		public async Task<SlApiResponse<EnergyClassDto, object>> DisableEnableDtoById(
			int id,
			SlApiResponse<EnergyClassDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.EnergyClasses.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(EnergyClassDto), id);
				}

				entity.IsDeleted = true;

				await context.SaveChangesAsync(cancellationToken);

				var deactivatedDto = mapper.Map<EnergyClassDto>(entity);

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