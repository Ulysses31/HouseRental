using AutoMapper;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.MediatR.PowerType.Services;
using CleanArchitecture.Application.Repository.Interfaces.PowerType;
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

namespace CleanArchitecture.Application.Repository.PowerType
{
	/// <summary>
	/// PowerTypeRepo class
	/// </summary>
	public class PowerTypeRepo : BaseRepo<PowerTypeDto, PowerTypeDto>, IPowerTypeRepo
	{
		private readonly PowerTypeService PowerTypeService;
		private readonly SlApiResponse<PaginatedList<PowerTypeDto>, object> responseList;
		private readonly SlApiResponse<PowerTypeDto, object> response;

		public PowerTypeRepo(
			IMapper mapper,
			IConfiguration configuration,
			IHttpClientFactory httpClientFactory,
			IHttpContextAccessor httpContextAccessor,
			PowerTypeService PowerTypeService,
			SlApiResponse<PaginatedList<PowerTypeDto>, object> responseList,
			SlApiResponse<PowerTypeDto, object> response
		) : base(mapper, configuration, httpClientFactory, httpContextAccessor)
		{
			this.PowerTypeService = PowerTypeService;
			this.responseList = responseList;
			this.response = response;
		}

		public async Task<SlApiResponse<PaginatedList<PowerTypeDto>, object>> GetAllWithPagination(
			[FromQuery] SlApiPaginationQuery query
		)
		{
			return await this.PowerTypeService.GetAllWithPagination(
				query,
				this.responseList
			);
		}

		public async Task<SlApiResponse<PowerTypeDto, object>> GetById(int id)
		{
			return await this.PowerTypeService.GetById(
				id,
				this.response
			);
		}

		public async Task<SlApiResponse<PowerTypeDto, object>> UpdateDtoById(
			int id,
			PowerTypeDto dto,
			CancellationToken cancellationToken
		)
		{
			return await this.PowerTypeService.UpdateDtoById(
				id,
				dto,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<PowerTypeDto, object>> AddDto(
			PowerTypeDto dto,
			CancellationToken cancellationToken
		)
		{
			return await this.PowerTypeService.AddDto(
				dto,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<PowerTypeDto, object>> DeleteDtoById(
			int id,
			CancellationToken cancellationToken
		)
		{
			return await this.PowerTypeService.DeleteDtoById(
				id,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<PowerTypeDto, object>> DisableEnableDtoById(
			int id,
			CancellationToken cancellationToken
		)
		{
			return await this.PowerTypeService.DisableEnableDtoById(
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