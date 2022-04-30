using AutoMapper;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.MediatR.InteriorFeature.Services;
using CleanArchitecture.Application.Repository.Interfaces.InteriorFeature;
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

namespace CleanArchitecture.Application.Repository.InteriorFeature
{
	/// <summary>
	/// InteriorFeatureRepo class
	/// </summary>
	public class InteriorFeatureRepo : BaseRepo<InteriorFeatureDto, InteriorFeatureDto>, IInteriorFeatureRepo
	{
		private readonly InteriorFeatureService InteriorFeatureService;
		private readonly SlApiResponse<PaginatedList<InteriorFeatureDto>, object> responseList;
		private readonly SlApiResponse<InteriorFeatureDto, object> response;

		public InteriorFeatureRepo(
			IMapper mapper,
			IConfiguration configuration,
			IHttpClientFactory httpClientFactory,
			IHttpContextAccessor httpContextAccessor,
			InteriorFeatureService InteriorFeatureService,
			SlApiResponse<PaginatedList<InteriorFeatureDto>, object> responseList,
			SlApiResponse<InteriorFeatureDto, object> response
		) : base(mapper, configuration, httpClientFactory, httpContextAccessor)
		{
			this.InteriorFeatureService = InteriorFeatureService;
			this.responseList = responseList;
			this.response = response;
		}

		public async Task<SlApiResponse<PaginatedList<InteriorFeatureDto>, object>> GetAllWithPagination(
			[FromQuery] SlApiPaginationQuery query
		)
		{
			return await this.InteriorFeatureService.GetAllWithPagination(
				query,
				this.responseList
			);
		}

		public async Task<SlApiResponse<InteriorFeatureDto, object>> GetById(int id)
		{
			return await this.InteriorFeatureService.GetById(
				id,
				this.response
			);
		}

		public async Task<SlApiResponse<InteriorFeatureDto, object>> UpdateDtoById(
			int id,
			InteriorFeatureDto dto,
			CancellationToken cancellationToken
		)
		{
			return await this.InteriorFeatureService.UpdateDtoById(
				id,
				dto,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<InteriorFeatureDto, object>> AddDto(
			InteriorFeatureDto dto,
			CancellationToken cancellationToken
		)
		{
			return await this.InteriorFeatureService.AddDto(
				dto,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<InteriorFeatureDto, object>> DeleteDtoById(
			int id,
			CancellationToken cancellationToken
		)
		{
			return await this.InteriorFeatureService.DeleteDtoById(
				id,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<InteriorFeatureDto, object>> DisableEnableDtoById(
			int id,
			CancellationToken cancellationToken
		)
		{
			return await this.InteriorFeatureService.DisableEnableDtoById(
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