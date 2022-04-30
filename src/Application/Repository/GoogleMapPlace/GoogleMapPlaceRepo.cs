using AutoMapper;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.MediatR.GoogleMapPlace.Services;
using CleanArchitecture.Application.Repository.Interfaces.GoogleMapPlace;
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

namespace CleanArchitecture.Application.Repository.GoogleMapPlace
{
	/// <summary>
	/// GoogleMapPlaceRepo class
	/// </summary>
	public class GoogleMapPlaceRepo : BaseRepo<GoogleMapPlaceDto, GoogleMapPlaceDto>, IGoogleMapPlaceRepo
	{
		private readonly GoogleMapPlaceService GoogleMapPlaceService;
		private readonly SlApiResponse<PaginatedList<GoogleMapPlaceDto>, object> responseList;
		private readonly SlApiResponse<GoogleMapPlaceDto, object> response;

		public GoogleMapPlaceRepo(
			IMapper mapper,
			IConfiguration configuration,
			IHttpClientFactory httpClientFactory,
			IHttpContextAccessor httpContextAccessor,
			GoogleMapPlaceService GoogleMapPlaceService,
			SlApiResponse<PaginatedList<GoogleMapPlaceDto>, object> responseList,
			SlApiResponse<GoogleMapPlaceDto, object> response
		) : base(mapper, configuration, httpClientFactory, httpContextAccessor)
		{
			this.GoogleMapPlaceService = GoogleMapPlaceService;
			this.responseList = responseList;
			this.response = response;
		}

		public async Task<SlApiResponse<PaginatedList<GoogleMapPlaceDto>, object>> GetAllWithPagination(
			[FromQuery] SlApiPaginationQuery query
		)
		{
			return await this.GoogleMapPlaceService.GetAllWithPagination(
				query,
				this.responseList
			);
		}

		public async Task<SlApiResponse<GoogleMapPlaceDto, object>> GetById(int id)
		{
			return await this.GoogleMapPlaceService.GetById(
				id,
				this.response
			);
		}

		public async Task<SlApiResponse<GoogleMapPlaceDto, object>> UpdateDtoById(
			int id,
			GoogleMapPlaceDto dto,
			CancellationToken cancellationToken
		)
		{
			return await this.GoogleMapPlaceService.UpdateDtoById(
				id,
				dto,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<GoogleMapPlaceDto, object>> AddDto(
			GoogleMapPlaceDto dto,
			CancellationToken cancellationToken
		)
		{
			return await this.GoogleMapPlaceService.AddDto(
				dto,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<GoogleMapPlaceDto, object>> DeleteDtoById(
			int id,
			CancellationToken cancellationToken
		)
		{
			return await this.GoogleMapPlaceService.DeleteDtoById(
				id,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<GoogleMapPlaceDto, object>> DisableEnableDtoById(
			int id,
			CancellationToken cancellationToken
		)
		{
			return await this.GoogleMapPlaceService.DisableEnableDtoById(
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