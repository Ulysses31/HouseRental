using AutoMapper;
using AutoMapper.QueryableExtensions;
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

namespace CleanArchitecture.Application.MediatR.AdvertiserInfo.Services
{
	/// <summary>
	/// AdvertiserInfoService class
	/// </summary>
	public class AdvertiserInfoService
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
		/// AdvertiserInfoService constructor
		/// </summary>
		/// <param name="mapper"></param>
		/// <param name="context"></param>
		public AdvertiserInfoService(
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
		/// <param name="responseList">SlApiResponse PaginatedList AdvertiserInfoDto</param>
		/// <returns>SlApiResponse PaginatedList AdvertiserInfoDto</returns>
		public async Task<SlApiResponse<PaginatedList<AdvertiserInfoDto>, object>> GetAllWithPagination(
			SlApiPaginationQuery query,
			SlApiResponse<PaginatedList<AdvertiserInfoDto>, object> responseList
		)
		{
			try
			{
				var result = await context.AdvertiserInfos
					.Where(a => a.IsEnabled == true && a.IsDeleted == false)
					//.Include(a => a.Classifieds)
					.OrderBy(x => x.AdvertiserInfoID)
					.ProjectTo<AdvertiserInfoDto>(mapper.ConfigurationProvider)
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
		/// <param name="response">SlApiResponse AdvertiserInfoDto</param>
		/// <returns>SlApiResponse AdvertiserInfoDto</returns>
		public async Task<SlApiResponse<AdvertiserInfoDto, object>> GetById(
			int id,
			SlApiResponse<AdvertiserInfoDto, object> response
		)
		{
			try
			{
				var result = await context.AdvertiserInfos
					.Where(t => t.AdvertiserInfoID == id)
					.ProjectTo<AdvertiserInfoDto>(mapper.ConfigurationProvider)
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
		/// <param name="advertiserInfoDto">AdvertiserInfoDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse AdvertiserInfoDto</param>
		/// <returns>SlApiResponse AdvertiserInfoDto</returns>
		public async Task<SlApiResponse<AdvertiserInfoDto, object>> UpdateDtoById(
			int id,
			AdvertiserInfoDto advertiserInfoDto,
			SlApiResponse<AdvertiserInfoDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.AdvertiserInfos.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(AdvertiserInfoDto), id);
				}

				entity.Code = advertiserInfoDto.Code != null ? advertiserInfoDto.Code : entity.Code;
				entity.Name = advertiserInfoDto.Name != null ? advertiserInfoDto.Name : entity.Name;
				entity.Address = advertiserInfoDto.Address != null ? advertiserInfoDto.Address : entity.Address;
				entity.Responsible = advertiserInfoDto.Responsible != null ? advertiserInfoDto.Responsible : entity.Responsible;
				entity.Telephone = advertiserInfoDto.Telephone != null ? advertiserInfoDto.Telephone : entity.Telephone;
				entity.Email = advertiserInfoDto.Email != null ? advertiserInfoDto.Email : entity.Email;
				entity.Website = advertiserInfoDto.Website != null ? advertiserInfoDto.Website : entity.Website;
				entity.IsEnabled = advertiserInfoDto.IsEnabled;
				entity.IsDeleted = advertiserInfoDto.IsDeleted;

				await context.SaveChangesAsync(cancellationToken);

				response.Data = new AdvertiserInfoDto()
				{
					AdvertiserInfoID = entity.AdvertiserInfoID,
					Address = entity.Address,
					Code = entity.Code,
					Email = entity.Email,
					Name = entity.Name,
					Responsible = entity.Responsible,
					Telephone = entity.Telephone,
					Website = entity.Website,
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
		/// <param name="advertiserInfoDto">AdvertiserInfoDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse AdvertiserInfoDto</param>
		/// <returns>SlApiResponse AdvertiserInfoDto</returns>
		public async Task<SlApiResponse<AdvertiserInfoDto, object>> AddDto(
			AdvertiserInfoDto advertiserInfoDto,
			SlApiResponse<AdvertiserInfoDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				if (advertiserInfoDto != null)
				{
					var entity = mapper.Map<Domain.Entities.AdvertiserInfo>(advertiserInfoDto);
					context.AdvertiserInfos.Add(entity);
					await context.SaveChangesAsync(cancellationToken);

					response.Data = new AdvertiserInfoDto()
					{
						AdvertiserInfoID = entity.AdvertiserInfoID,
						Address = entity.Address,
						Code = entity.Code,
						Email = entity.Email,
						Name = entity.Name,
						Responsible = entity.Responsible,
						Telephone = entity.Telephone,
						Website = entity.Website,
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
		/// <param name="advertiserInfoDto">AdvertiserInfoDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse AdvertiserInfoDto</param>
		/// <returns>SlApiResponse AdvertiserInfoDto</returns>
		public async Task<SlApiResponse<AdvertiserInfoDto, object>> DeleteDtoById(
			int id,
			SlApiResponse<AdvertiserInfoDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.AdvertiserInfos.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(AdvertiserInfoDto), id);
				}

				var deletedDto = mapper.Map<AdvertiserInfoDto>(entity);

				context.AdvertiserInfos.Remove(entity);

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
		/// <param name="advertiserInfoDto">AdvertiserInfoDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse AdvertiserInfoDto</param>
		/// <returns>SlApiResponse AdvertiserInfoDto</returns>
		public async Task<SlApiResponse<AdvertiserInfoDto, object>> DisableEnableDtoById(
			int id,
			SlApiResponse<AdvertiserInfoDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.AdvertiserInfos.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(AdvertiserInfoDto), id);
				}

				entity.IsDeleted = true;

				await context.SaveChangesAsync(cancellationToken);

				var deactivatedDto = mapper.Map<AdvertiserInfoDto>(entity);

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