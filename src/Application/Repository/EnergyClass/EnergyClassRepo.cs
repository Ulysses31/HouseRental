using AutoMapper;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.MediatR.EnergyClass.Services;
using CleanArchitecture.Application.Repository.Interfaces.EnergyClass;
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

namespace CleanArchitecture.Application.Repository.EnergyClass
{
	/// <summary>
	/// EnergyClassRepo class
	/// </summary>
	public class EnergyClassRepo : BaseRepo<EnergyClassDto, EnergyClassDto>, IEnergyClassRepo
	{
		private readonly EnergyClassService EnergyClassService;
		private readonly SlApiResponse<PaginatedList<EnergyClassDto>, object> responseList;
		private readonly SlApiResponse<EnergyClassDto, object> response;

		public EnergyClassRepo(
			IMapper mapper,
			IConfiguration configuration,
			IHttpClientFactory httpClientFactory,
			IHttpContextAccessor httpContextAccessor,
			EnergyClassService EnergyClassService,
			SlApiResponse<PaginatedList<EnergyClassDto>, object> responseList,
			SlApiResponse<EnergyClassDto, object> response
		) : base(mapper, configuration, httpClientFactory, httpContextAccessor)
		{
			this.EnergyClassService = EnergyClassService;
			this.responseList = responseList;
			this.response = response;
		}

		public async Task<SlApiResponse<PaginatedList<EnergyClassDto>, object>> GetAllWithPagination(
			[FromQuery] SlApiPaginationQuery query
		)
		{
			return await this.EnergyClassService.GetAllWithPagination(
				query,
				this.responseList
			);
		}

		public async Task<SlApiResponse<EnergyClassDto, object>> GetById(int id)
		{
			return await this.EnergyClassService.GetById(
				id,
				this.response
			);
		}

		public async Task<SlApiResponse<EnergyClassDto, object>> UpdateDtoById(
			int id,
			EnergyClassDto dto,
			CancellationToken cancellationToken
		)
		{
			return await this.EnergyClassService.UpdateDtoById(
				id,
				dto,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<EnergyClassDto, object>> AddDto(
			EnergyClassDto dto,
			CancellationToken cancellationToken
		)
		{
			return await this.EnergyClassService.AddDto(
				dto,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<EnergyClassDto, object>> DeleteDtoById(
			int id,
			CancellationToken cancellationToken
		)
		{
			return await this.EnergyClassService.DeleteDtoById(
				id,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<EnergyClassDto, object>> DisableEnableDtoById(
			int id,
			CancellationToken cancellationToken
		)
		{
			return await this.EnergyClassService.DisableEnableDtoById(
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