using AutoMapper;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.MediatR.Photos.Services;
using CleanArchitecture.Application.Repository.Interfaces.Photo;
using CleanArchitecture.Domain.DTOs;
using GenesisCloud.Application.ServerApp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Repository.Photo
{
	/// <summary>
	/// PhotoRepo class
	/// </summary>
	public class PhotoRepo : BaseRepo<PhotosDto, PhotosDto>, IPhotoRepo
	{
		private readonly PhotosService PhotoService;
		private readonly SlApiResponse<PaginatedList<PhotosDto>, object> responseList;
		private readonly SlApiResponse<PhotosDto, object> response;

		public PhotoRepo(
			IMapper mapper,
			IConfiguration configuration,
			IHttpClientFactory httpClientFactory,
			IHttpContextAccessor httpContextAccessor,
			PhotosService PhotoService,
			SlApiResponse<PaginatedList<PhotosDto>, object> responseList,
			SlApiResponse<PhotosDto, object> response
		) : base(mapper, configuration, httpClientFactory, httpContextAccessor)
		{
			this.PhotoService = PhotoService;
			this.responseList = responseList;
			this.response = response;
		}

		public async Task<SlApiResponse<PaginatedList<PhotosDto>, object>> GetAllWithPagination(
			[FromQuery] SlApiPaginationQuery query
		)
		{
			return await this.PhotoService.GetAllWithPagination(
				query,
				this.responseList
			);
		}

		public async Task<SlApiResponse<PhotosDto, object>> GetById(int id)
		{
			return await this.PhotoService.GetById(
				id,
				this.response
			);
		}

		public async Task<SlApiResponse<PhotosDto, object>> UpdateDtoById(
			int id,
			PhotosDto dto,
			CancellationToken cancellationToken
		)
		{
			return await this.PhotoService.UpdateDtoById(
				id,
				dto,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<PhotosDto, object>> AddDto(
			PhotosDto dto,
			CancellationToken cancellationToken
		)
		{
			return await this.PhotoService.AddDto(
				dto,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<PhotosDto, object>> DeleteDtoById(
			int id,
			CancellationToken cancellationToken
		)
		{
			return await this.PhotoService.DeleteDtoById(
				id,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<PhotosDto, object>> DisableEnableDtoById(
			int id,
			CancellationToken cancellationToken
		)
		{
			return await this.PhotoService.DisableEnableDtoById(
				id,
				this.response,
				cancellationToken
			);
		}

		/// <summary>
		/// HashCode
		/// </summary>
		/// <param name="str">string</param>
		/// <returns>string</returns>
		private static string HashCode(string str)
		{
			string newHash = string.Empty;
			try
			{
				SHA256 hashSha256 = SHA256.Create();
				UTF8Encoding encoder = new UTF8Encoding();
				byte[] combined = encoder.GetBytes(str);
				hashSha256.ComputeHash(combined);
				newHash = Convert.ToBase64String(hashSha256.Hash);
			}
			catch (Exception ex)
			{
				return "Error in HashCode : " + ex.Message;
			}
			return newHash;
		}
	}
}