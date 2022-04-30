using AutoMapper;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.MediatR.AdvertiserInfo.Services;
using CleanArchitecture.Application.Repository.Interfaces.AdvertiserInfo;
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

namespace CleanArchitecture.Application.Repository.AdvertiserInfo
{
	/// <summary>
	/// AdvertiserInfoRepo class
	/// </summary>
	public class AdvertiserInfoRepo : BaseRepo<AdvertiserInfoDto, AdvertiserInfoDto>, IAdvertiserInfoRepo
	{
		private readonly AdvertiserInfoService advertiserInfoService;
		private readonly SlApiResponse<PaginatedList<AdvertiserInfoDto>, object> responseList;
		private readonly SlApiResponse<AdvertiserInfoDto, object> response;

		public AdvertiserInfoRepo(
			IMapper mapper,
			IConfiguration configuration,
			IHttpClientFactory httpClientFactory,
			IHttpContextAccessor httpContextAccessor,
			AdvertiserInfoService advertiserInfoService,
			SlApiResponse<PaginatedList<AdvertiserInfoDto>, object> responseList,
			SlApiResponse<AdvertiserInfoDto, object> response
		) : base(mapper, configuration, httpClientFactory, httpContextAccessor)
		{
			this.advertiserInfoService = advertiserInfoService;
			this.responseList = responseList;
			this.response = response;
		}

		public async Task<SlApiResponse<PaginatedList<AdvertiserInfoDto>, object>> GetAllWithPagination(
			[FromQuery] SlApiPaginationQuery query
		)
		{
			return await this.advertiserInfoService.GetAllWithPagination(
				query,
				this.responseList
			);
		}

		public async Task<SlApiResponse<AdvertiserInfoDto, object>> GetById(int id)
		{
			return await this.advertiserInfoService.GetById(
				id,
				this.response
			);
		}

		public async Task<SlApiResponse<AdvertiserInfoDto, object>> UpdateDtoById(
			int id,
			AdvertiserInfoDto dto,
			CancellationToken cancellationToken
		)
		{
			return await this.advertiserInfoService.UpdateDtoById(
				id,
				dto,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<AdvertiserInfoDto, object>> AddDto(
			AdvertiserInfoDto dto,
			CancellationToken cancellationToken
		)
		{
			return await this.advertiserInfoService.AddDto(
				dto,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<AdvertiserInfoDto, object>> DeleteDtoById(
			int id,
			CancellationToken cancellationToken
		)
		{
			return await this.advertiserInfoService.DeleteDtoById(
				id,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<AdvertiserInfoDto, object>> DisableEnableDtoById(
			int id,
			CancellationToken cancellationToken
		)
		{
			return await this.advertiserInfoService.DisableEnableDtoById(
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