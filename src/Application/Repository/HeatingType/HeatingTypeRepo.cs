using AutoMapper;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.MediatR.HeatingType.Services;
using CleanArchitecture.Application.Repository.Interfaces.HeatingType;
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

namespace CleanArchitecture.Application.Repository.HeatingType
{
	/// <summary>
	/// HeatingTypeRepo class
	/// </summary>
	public class HeatingTypeRepo : BaseRepo<HeatingTypeDto, HeatingTypeDto>, IHeatingTypeRepo
	{
		private readonly HeatingTypeService HeatingTypeService;
		private readonly SlApiResponse<PaginatedList<HeatingTypeDto>, object> responseList;
		private readonly SlApiResponse<HeatingTypeDto, object> response;

		public HeatingTypeRepo(
			IMapper mapper,
			IConfiguration configuration,
			IHttpClientFactory httpClientFactory,
			IHttpContextAccessor httpContextAccessor,
			HeatingTypeService HeatingTypeService,
			SlApiResponse<PaginatedList<HeatingTypeDto>, object> responseList,
			SlApiResponse<HeatingTypeDto, object> response
		) : base(mapper, configuration, httpClientFactory, httpContextAccessor)
		{
			this.HeatingTypeService = HeatingTypeService;
			this.responseList = responseList;
			this.response = response;
		}

		public async Task<SlApiResponse<PaginatedList<HeatingTypeDto>, object>> GetAllWithPagination(
			[FromQuery] SlApiPaginationQuery query
		)
		{
			return await this.HeatingTypeService.GetAllWithPagination(
				query,
				this.responseList
			);
		}

		public async Task<SlApiResponse<HeatingTypeDto, object>> GetById(int id)
		{
			return await this.HeatingTypeService.GetById(
				id,
				this.response
			);
		}

		public async Task<SlApiResponse<HeatingTypeDto, object>> UpdateDtoById(
			int id,
			HeatingTypeDto dto,
			CancellationToken cancellationToken
		)
		{
			return await this.HeatingTypeService.UpdateDtoById(
				id,
				dto,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<HeatingTypeDto, object>> AddDto(
			HeatingTypeDto dto,
			CancellationToken cancellationToken
		)
		{
			return await this.HeatingTypeService.AddDto(
				dto,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<HeatingTypeDto, object>> DeleteDtoById(
			int id,
			CancellationToken cancellationToken
		)
		{
			return await this.HeatingTypeService.DeleteDtoById(
				id,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<HeatingTypeDto, object>> DisableEnableDtoById(
			int id,
			CancellationToken cancellationToken
		)
		{
			return await this.HeatingTypeService.DisableEnableDtoById(
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