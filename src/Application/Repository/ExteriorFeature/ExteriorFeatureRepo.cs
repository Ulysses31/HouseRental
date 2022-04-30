using AutoMapper;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.MediatR.ExteriorFeature.Services;
using CleanArchitecture.Application.Repository.Interfaces.ExteriorFeature;
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

namespace CleanArchitecture.Application.Repository.ExteriorFeature
{
	/// <summary>
	/// ExteriorFeatureRepo class
	/// </summary>
	public class ExteriorFeatureRepo : BaseRepo<ExteriorFeatureDto, ExteriorFeatureDto>, IExteriorFeatureRepo
	{
		private readonly ExteriorFeatureService ExteriorFeatureService;
		private readonly SlApiResponse<PaginatedList<ExteriorFeatureDto>, object> responseList;
		private readonly SlApiResponse<ExteriorFeatureDto, object> response;

		public ExteriorFeatureRepo(
			IMapper mapper,
			IConfiguration configuration,
			IHttpClientFactory httpClientFactory,
			IHttpContextAccessor httpContextAccessor,
			ExteriorFeatureService ExteriorFeatureService,
			SlApiResponse<PaginatedList<ExteriorFeatureDto>, object> responseList,
			SlApiResponse<ExteriorFeatureDto, object> response
		) : base(mapper, configuration, httpClientFactory, httpContextAccessor)
		{
			this.ExteriorFeatureService = ExteriorFeatureService;
			this.responseList = responseList;
			this.response = response;
		}

		public async Task<SlApiResponse<PaginatedList<ExteriorFeatureDto>, object>> GetAllWithPagination(
			[FromQuery] SlApiPaginationQuery query
		)
		{
			return await this.ExteriorFeatureService.GetAllWithPagination(
				query,
				this.responseList
			);
		}

		public async Task<SlApiResponse<ExteriorFeatureDto, object>> GetById(int id)
		{
			return await this.ExteriorFeatureService.GetById(
				id,
				this.response
			);
		}

		public async Task<SlApiResponse<ExteriorFeatureDto, object>> UpdateDtoById(
			int id,
			ExteriorFeatureDto dto,
			CancellationToken cancellationToken
		)
		{
			return await this.ExteriorFeatureService.UpdateDtoById(
				id,
				dto,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<ExteriorFeatureDto, object>> AddDto(
			ExteriorFeatureDto dto,
			CancellationToken cancellationToken
		)
		{
			return await this.ExteriorFeatureService.AddDto(
				dto,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<ExteriorFeatureDto, object>> DeleteDtoById(
			int id,
			CancellationToken cancellationToken
		)
		{
			return await this.ExteriorFeatureService.DeleteDtoById(
				id,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<ExteriorFeatureDto, object>> DisableEnableDtoById(
			int id,
			CancellationToken cancellationToken
		)
		{
			return await this.ExteriorFeatureService.DisableEnableDtoById(
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