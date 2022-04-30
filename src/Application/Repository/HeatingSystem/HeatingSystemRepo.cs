using AutoMapper;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.MediatR.HeatingSystem.Services;
using CleanArchitecture.Application.Repository.Interfaces.HeatingSystem;
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

namespace CleanArchitecture.Application.Repository.HeatingSystem
{
	/// <summary>
	/// HeatingSystemRepo class
	/// </summary>
	public class HeatingSystemRepo : BaseRepo<HeatingSystemDto, HeatingSystemDto>, IHeatingSystemRepo
	{
		private readonly HeatingSystemService HeatingSystemService;
		private readonly SlApiResponse<PaginatedList<HeatingSystemDto>, object> responseList;
		private readonly SlApiResponse<HeatingSystemDto, object> response;

		public HeatingSystemRepo(
			IMapper mapper,
			IConfiguration configuration,
			IHttpClientFactory httpClientFactory,
			IHttpContextAccessor httpContextAccessor,
			HeatingSystemService HeatingSystemService,
			SlApiResponse<PaginatedList<HeatingSystemDto>, object> responseList,
			SlApiResponse<HeatingSystemDto, object> response
		) : base(mapper, configuration, httpClientFactory, httpContextAccessor)
		{
			this.HeatingSystemService = HeatingSystemService;
			this.responseList = responseList;
			this.response = response;
		}

		public async Task<SlApiResponse<PaginatedList<HeatingSystemDto>, object>> GetAllWithPagination(
			[FromQuery] SlApiPaginationQuery query
		)
		{
			return await this.HeatingSystemService.GetAllWithPagination(
				query,
				this.responseList
			);
		}

		public async Task<SlApiResponse<HeatingSystemDto, object>> GetById(int id)
		{
			return await this.HeatingSystemService.GetById(
				id,
				this.response
			);
		}

		public async Task<SlApiResponse<HeatingSystemDto, object>> UpdateDtoById(
			int id,
			HeatingSystemDto dto,
			CancellationToken cancellationToken
		)
		{
			return await this.HeatingSystemService.UpdateDtoById(
				id,
				dto,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<HeatingSystemDto, object>> AddDto(
			HeatingSystemDto dto,
			CancellationToken cancellationToken
		)
		{
			return await this.HeatingSystemService.AddDto(
				dto,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<HeatingSystemDto, object>> DeleteDtoById(
			int id,
			CancellationToken cancellationToken
		)
		{
			return await this.HeatingSystemService.DeleteDtoById(
				id,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<HeatingSystemDto, object>> DisableEnableDtoById(
			int id,
			CancellationToken cancellationToken
		)
		{
			return await this.HeatingSystemService.DisableEnableDtoById(
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