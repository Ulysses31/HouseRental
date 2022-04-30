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

namespace CleanArchitecture.Application.MediatR.Photos.Services
{
	/// <summary>
	/// PhotosService class
	/// </summary>
	public class PhotosService
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
		/// PhotosService constructor
		/// </summary>
		/// <param name="mapper"></param>
		/// <param name="context"></param>
		public PhotosService(
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
		/// <param name="responseList">SlApiResponse PaginatedList PhotosDto</param>
		/// <returns>SlApiResponse PaginatedList PhotosDto</returns>
		public async Task<SlApiResponse<PaginatedList<PhotosDto>, object>> GetAllWithPagination(
			SlApiPaginationQuery query,
			SlApiResponse<PaginatedList<PhotosDto>, object> responseList
		)
		{
			try
			{
				var result = await context.Photos
					.AsNoTracking()
					.Where(a => a.IsEnabled == true && a.IsDeleted == false)
					.OrderBy(x => x.PhotoID)
					.Select(t => new PhotosDto()
					{
						PhotoID = t.PhotoID,
						ClassifiedID = t.ClassifiedID,
						FileName = t.FileName,
						FileSize = t.FileSize,
						FileContent = t.FileContent,
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
		/// <param name="response">SlApiResponse PhotosDto</param>
		/// <returns>SlApiResponse PhotosDto</returns>
		public async Task<SlApiResponse<PhotosDto, object>> GetById(
			int id,
			SlApiResponse<PhotosDto, object> response
		)
		{
			try
			{
				var result = await context.Photos
					.AsNoTracking()
					.Where(a =>
						a.IsEnabled == true &&
						a.IsDeleted == false &&
						a.PhotoID == id
					)
					.OrderBy(x => x.PhotoID)
					.Select(t => new PhotosDto()
					{
						PhotoID = t.PhotoID,
						ClassifiedID = t.ClassifiedID,
						FileName = t.FileName,
						FileSize = t.FileSize,
						FileContent = t.FileContent,
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
		/// <param name="PhotosDto">PhotosDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse PhotosDto</param>
		/// <returns>SlApiResponse PhotosDto</returns>
		public async Task<SlApiResponse<PhotosDto, object>> UpdateDtoById(
			int id,
			PhotosDto photosDto,
			SlApiResponse<PhotosDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.Photos.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(photosDto), id);
				}

#pragma warning disable CS0472 // The result of the expression is always the same
				entity.ClassifiedID = photosDto.ClassifiedID != null ? photosDto.ClassifiedID : entity.ClassifiedID;
				entity.FileName = photosDto.FileName != null ? photosDto.FileName : entity.FileName;
				entity.FileSize = photosDto.FileSize != null ? photosDto.FileSize : entity.FileSize;
				entity.FileContent = photosDto.FileContent != null ? photosDto.FileContent : entity.FileContent;
				entity.IsEnabled = photosDto.IsEnabled;
				entity.IsDeleted = photosDto.IsDeleted;
#pragma warning restore CS0472 // The result of the expression is always the same

				await context.SaveChangesAsync(cancellationToken);

				response.Data = new PhotosDto()
				{
					PhotoID = entity.PhotoID,
					ClassifiedID = entity.ClassifiedID,
					FileName = entity.FileName,
					FileSize = entity.FileSize,
					FileContent = entity.FileContent,
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
		/// <param name="PhotosDto">PhotosDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse PhotosDto</param>
		/// <returns>SlApiResponse PhotosDto</returns>
		public async Task<SlApiResponse<PhotosDto, object>> AddDto(
			PhotosDto photosDto,
			SlApiResponse<PhotosDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				if (photosDto != null)
				{
					var entity = mapper.Map<Domain.Entities.Photos>(photosDto);
					context.Photos.Add(entity);
					await context.SaveChangesAsync(cancellationToken);

					response.Data = new PhotosDto()
					{
						PhotoID = entity.PhotoID,
						ClassifiedID = entity.ClassifiedID,
						FileName = entity.FileName,
						FileSize = entity.FileSize,
						FileContent = entity.FileContent,
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
		/// <param name="PhotosDto">PhotosDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse PhotosDto</param>
		/// <returns>SlApiResponse PhotosDto</returns>
		public async Task<SlApiResponse<PhotosDto, object>> DeleteDtoById(
			int id,
			SlApiResponse<PhotosDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.Photos.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(PhotosDto), id);
				}

				var deletedDto = mapper.Map<PhotosDto>(entity);

				context.Photos.Remove(entity);

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
		/// <param name="PhotosDto">PhotosDto</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <param name="response">SlApiResponse PhotosDto</param>
		/// <returns>SlApiResponse PhotosDto</returns>
		public async Task<SlApiResponse<PhotosDto, object>> DisableEnableDtoById(
			int id,
			SlApiResponse<PhotosDto, object> response,
			CancellationToken cancellationToken
		)
		{
			try
			{
				var entity = await context.Photos.FindAsync(id);

				if (entity == null)
				{
					throw new NotFoundException(nameof(PhotosDto), id);
				}

				entity.IsDeleted = true;

				await context.SaveChangesAsync(cancellationToken);

				var deactivatedDto = mapper.Map<PhotosDto>(entity);

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