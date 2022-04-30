using AutoMapper;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.MediatR.FloorType.Services;
using CleanArchitecture.Application.Repository.Interfaces.FloorType;
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

namespace CleanArchitecture.Application.Repository.FloorType
{
	/// <summary>
	/// FloorTypeRepo class
	/// </summary>
	public class FloorTypeRepo : BaseRepo<FloorTypeDto, FloorTypeDto>, IFloorTypeRepo
	{
		private readonly FloorTypeService FloorTypeService;
		private readonly SlApiResponse<PaginatedList<FloorTypeDto>, object> responseList;
		private readonly SlApiResponse<FloorTypeDto, object> response;

		public FloorTypeRepo(
			IMapper mapper,
			IConfiguration configuration,
			IHttpClientFactory httpClientFactory,
			IHttpContextAccessor httpContextAccessor,
			FloorTypeService FloorTypeService,
			SlApiResponse<PaginatedList<FloorTypeDto>, object> responseList,
			SlApiResponse<FloorTypeDto, object> response
		) : base(mapper, configuration, httpClientFactory, httpContextAccessor)
		{
			this.FloorTypeService = FloorTypeService;
			this.responseList = responseList;
			this.response = response;
		}

		public async Task<SlApiResponse<PaginatedList<FloorTypeDto>, object>> GetAllWithPagination(
			[FromQuery] SlApiPaginationQuery query
		)
		{
			return await this.FloorTypeService.GetAllWithPagination(
				query,
				this.responseList
			);
		}

		public async Task<SlApiResponse<FloorTypeDto, object>> GetById(int id)
		{
			return await this.FloorTypeService.GetById(
				id,
				this.response
			);
		}

		public async Task<SlApiResponse<FloorTypeDto, object>> UpdateDtoById(
			int id,
			FloorTypeDto dto,
			CancellationToken cancellationToken
		)
		{
			return await this.FloorTypeService.UpdateDtoById(
				id,
				dto,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<FloorTypeDto, object>> AddDto(
			FloorTypeDto dto,
			CancellationToken cancellationToken
		)
		{
			return await this.FloorTypeService.AddDto(
				dto,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<FloorTypeDto, object>> DeleteDtoById(
			int id,
			CancellationToken cancellationToken
		)
		{
			return await this.FloorTypeService.DeleteDtoById(
				id,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<FloorTypeDto, object>> DisableEnableDtoById(
			int id,
			CancellationToken cancellationToken
		)
		{
			return await this.FloorTypeService.DisableEnableDtoById(
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