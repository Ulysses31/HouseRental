using AutoMapper;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.MediatR.FloorNo.Services;
using CleanArchitecture.Application.Repository.Interfaces.FloorNo;
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

namespace CleanArchitecture.Application.Repository.FloorNo
{
	/// <summary>
	/// FloorNoRepo class
	/// </summary>
	public class FloorNoRepo : BaseRepo<FloorNoDto, FloorNoDto>, IFloorNoRepo
	{
		private readonly FloorNoService FloorNoService;
		private readonly SlApiResponse<PaginatedList<FloorNoDto>, object> responseList;
		private readonly SlApiResponse<FloorNoDto, object> response;

		public FloorNoRepo(
			IMapper mapper,
			IConfiguration configuration,
			IHttpClientFactory httpClientFactory,
			IHttpContextAccessor httpContextAccessor,
			FloorNoService FloorNoService,
			SlApiResponse<PaginatedList<FloorNoDto>, object> responseList,
			SlApiResponse<FloorNoDto, object> response
		) : base(mapper, configuration, httpClientFactory, httpContextAccessor)
		{
			this.FloorNoService = FloorNoService;
			this.responseList = responseList;
			this.response = response;
		}

		public async Task<SlApiResponse<PaginatedList<FloorNoDto>, object>> GetAllWithPagination(
			[FromQuery] SlApiPaginationQuery query
		)
		{
			return await this.FloorNoService.GetAllWithPagination(
				query,
				this.responseList
			);
		}

		public async Task<SlApiResponse<FloorNoDto, object>> GetById(int id)
		{
			return await this.FloorNoService.GetById(
				id,
				this.response
			);
		}

		public async Task<SlApiResponse<FloorNoDto, object>> UpdateDtoById(
			int id,
			FloorNoDto dto,
			CancellationToken cancellationToken
		)
		{
			return await this.FloorNoService.UpdateDtoById(
				id,
				dto,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<FloorNoDto, object>> AddDto(
			FloorNoDto dto,
			CancellationToken cancellationToken
		)
		{
			return await this.FloorNoService.AddDto(
				dto,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<FloorNoDto, object>> DeleteDtoById(
			int id,
			CancellationToken cancellationToken
		)
		{
			return await this.FloorNoService.DeleteDtoById(
				id,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<FloorNoDto, object>> DisableEnableDtoById(
			int id,
			CancellationToken cancellationToken
		)
		{
			return await this.FloorNoService.DisableEnableDtoById(
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