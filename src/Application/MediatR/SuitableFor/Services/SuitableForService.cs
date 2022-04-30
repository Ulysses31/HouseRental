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

namespace CleanArchitecture.Application.MediatR.SuitableFor.Services
{
	/// <summary>
	/// SuitableForService class
	/// </summary>
	public class SuitableForService
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
		/// SuitableForService constructor
		/// </summary>
		/// <param name="mapper"></param>
		/// <param name="context"></param>
		public SuitableForService(
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
		/// <param name="responseList">SlApiResponse PaginatedList SuitableForDto</param>
		/// <returns>SlApiResponse PaginatedList SuitableForDto</returns>
		public async Task<SlApiResponse<PaginatedList<SuitableForDto>, object>> GetAllWithPagination(
			SlApiPaginationQuery query,
			SlApiResponse<PaginatedList<SuitableForDto>, object> responseList
		)
		{
			try
			{
				var result = await context.SuitableFors
					.AsNoTracking()
					.Where(a => a.IsEnabled == true && a.IsDeleted == false)
					.OrderBy(x => x.SuitableForID)
					.Select(t => new SuitableForDto()
					{
						SuitableForID = t.SuitableForID,
						StudentUse = t.StudentUse,
						HolidayHomeUse = t.HolidayHomeUse,
						ProfessionalUse = t.ProfessionalUse,
						InvestmentUse = t.InvestmentUse,
						TouristRentalUse = t.TouristRentalUse,
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
		/// <param name="response">SlApiResponse SuitableForDto</param>
		/// <returns>SlApiResponse SuitableForDto</returns>
		public async Task<SlApiResponse<SuitableForDto, object>> GetById(
			int id,
			SlApiResponse<SuitableForDto, object> response
		)
		{
			try
			{
				var result = await context.SuitableFors
					.AsNoTracking()
					.Where(a =>
						a.IsEnabled == true &&
						a.IsDeleted == false &&
						a.SuitableForID == id
					)
					.OrderBy(x => x.SuitableForID)
					.Select(t => new SuitableForDto()
					{
						SuitableForID = t.SuitableForID,
						StudentUse = t.StudentUse,
						HolidayHomeUse = t.HolidayHomeUse,
						ProfessionalUse = t.ProfessionalUse,
						InvestmentUse = t.InvestmentUse,
						TouristRentalUse = t.TouristRentalUse,
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
		/// <param name="SuitableForDto">SuitableForDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse SuitableForDto</param>
		/// <returns>SlApiResponse SuitableForDto</returns>
		public async Task<SlApiResponse<SuitableForDto, object>> UpdateDtoById(
			int id,
			SuitableForDto suitableForDto,
			SlApiResponse<SuitableForDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.SuitableFors.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(suitableForDto), id);
				}

#pragma warning disable CS0472 // The result of the expression is always the same
				entity.StudentUse = suitableForDto.StudentUse != null ? suitableForDto.StudentUse : entity.StudentUse;
				entity.HolidayHomeUse = suitableForDto.HolidayHomeUse != null ? suitableForDto.HolidayHomeUse : entity.HolidayHomeUse;
				entity.ProfessionalUse = suitableForDto.ProfessionalUse != null ? suitableForDto.ProfessionalUse : entity.ProfessionalUse;
				entity.InvestmentUse = suitableForDto.InvestmentUse != null ? suitableForDto.InvestmentUse : entity.InvestmentUse;
				entity.TouristRentalUse = suitableForDto.TouristRentalUse != null ? suitableForDto.TouristRentalUse : entity.TouristRentalUse;
				entity.Description = suitableForDto.Description != null ? suitableForDto.Description : entity.Description;
				entity.IsEnabled = suitableForDto.IsEnabled;
				entity.IsDeleted = suitableForDto.IsDeleted;
#pragma warning restore CS0472 // The result of the expression is always the same

				await context.SaveChangesAsync(cancellationToken);

				response.Data = new SuitableForDto()
				{
					SuitableForID = entity.SuitableForID,
					StudentUse = entity.StudentUse,
					HolidayHomeUse = entity.HolidayHomeUse,
					ProfessionalUse = entity.ProfessionalUse,
					InvestmentUse = entity.InvestmentUse,
					TouristRentalUse = entity.TouristRentalUse,
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
		/// <param name="SuitableForDto">SuitableForDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse SuitableForDto</param>
		/// <returns>SlApiResponse SuitableForDto</returns>
		public async Task<SlApiResponse<SuitableForDto, object>> AddDto(
			SuitableForDto suitableForDto,
			SlApiResponse<SuitableForDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				if (suitableForDto != null)
				{
					var entity = mapper.Map<Domain.Entities.SuitableFor>(suitableForDto);
					context.SuitableFors.Add(entity);
					await context.SaveChangesAsync(cancellationToken);

					response.Data = new SuitableForDto()
					{
						SuitableForID = entity.SuitableForID,
						StudentUse = entity.StudentUse,
						HolidayHomeUse = entity.HolidayHomeUse,
						ProfessionalUse = entity.ProfessionalUse,
						InvestmentUse = entity.InvestmentUse,
						TouristRentalUse = entity.TouristRentalUse,
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
		/// <param name="SuitableForDto">SuitableForDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse SuitableForDto</param>
		/// <returns>SlApiResponse SuitableForDto</returns>
		public async Task<SlApiResponse<SuitableForDto, object>> DeleteDtoById(
			int id,
			SlApiResponse<SuitableForDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.SuitableFors.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(SuitableForDto), id);
				}

				var deletedDto = mapper.Map<SuitableForDto>(entity);

				context.SuitableFors.Remove(entity);

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
		/// <param name="SuitableForDto">SuitableForDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse SuitableForDto</param>
		/// <returns>SlApiResponse SuitableForDto</returns>
		public async Task<SlApiResponse<SuitableForDto, object>> DisableEnableDtoById(
			int id,
			SlApiResponse<SuitableForDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.SuitableFors.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(SuitableForDto), id);
				}

				entity.IsDeleted = true;

				await context.SaveChangesAsync(cancellationToken);

				var deactivatedDto = mapper.Map<SuitableForDto>(entity);

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