using AutoMapper;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.MediatR.SuitableFor.Services;
using CleanArchitecture.Application.Repository.Interfaces.SuitableFor;
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

namespace CleanArchitecture.Application.Repository.SuitableFor
{
	/// <summary>
	/// SuitableForRepo class
	/// </summary>
	public class SuitableForRepo : BaseRepo<SuitableForDto, SuitableForDto>, ISuitableForRepo
	{
		private readonly SuitableForService SuitableForService;
		private readonly SlApiResponse<PaginatedList<SuitableForDto>, object> responseList;
		private readonly SlApiResponse<SuitableForDto, object> response;

		public SuitableForRepo(
			IMapper mapper,
			IConfiguration configuration,
			IHttpClientFactory httpClientFactory,
			IHttpContextAccessor httpContextAccessor,
			SuitableForService SuitableForService,
			SlApiResponse<PaginatedList<SuitableForDto>, object> responseList,
			SlApiResponse<SuitableForDto, object> response
		) : base(mapper, configuration, httpClientFactory, httpContextAccessor)
		{
			this.SuitableForService = SuitableForService;
			this.responseList = responseList;
			this.response = response;
		}

		public async Task<SlApiResponse<PaginatedList<SuitableForDto>, object>> GetAllWithPagination(
			[FromQuery] SlApiPaginationQuery query
		)
		{
			return await this.SuitableForService.GetAllWithPagination(
				query,
				this.responseList
			);
		}

		public async Task<SlApiResponse<SuitableForDto, object>> GetById(int id)
		{
			return await this.SuitableForService.GetById(
				id,
				this.response
			);
		}

		public async Task<SlApiResponse<SuitableForDto, object>> UpdateDtoById(
			int id,
			SuitableForDto dto,
			CancellationToken cancellationToken
		)
		{
			return await this.SuitableForService.UpdateDtoById(
				id,
				dto,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<SuitableForDto, object>> AddDto(
			SuitableForDto dto,
			CancellationToken cancellationToken
		)
		{
			return await this.SuitableForService.AddDto(
				dto,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<SuitableForDto, object>> DeleteDtoById(
			int id,
			CancellationToken cancellationToken
		)
		{
			return await this.SuitableForService.DeleteDtoById(
				id,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<SuitableForDto, object>> DisableEnableDtoById(
			int id,
			CancellationToken cancellationToken
		)
		{
			return await this.SuitableForService.DisableEnableDtoById(
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