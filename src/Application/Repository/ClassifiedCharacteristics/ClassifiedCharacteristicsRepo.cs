using AutoMapper;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.MediatR.ClassifiedCharacteristics.Services;
using CleanArchitecture.Application.Repository.Interfaces.ClassifiedCharacteristics;
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

namespace CleanArchitecture.Application.Repository.ClassifiedCharacteristics
{
	/// <summary>
	/// ClassifiedCharacteristicsRepo class
	/// </summary>
	public class ClassifiedCharacteristicsRepo : BaseRepo<ClassifiedCharacteristicsDto, ClassifiedCharacteristicsDto>, IClassifiedCharacteristicsRepo
	{
		private readonly ClassifiedCharacteristicsService ClassifiedCharacteristicsService;
		private readonly SlApiResponse<PaginatedList<ClassifiedCharacteristicsDto>, object> responseList;
		private readonly SlApiResponse<ClassifiedCharacteristicsDto, object> response;

		public ClassifiedCharacteristicsRepo(
			IMapper mapper,
			IConfiguration configuration,
			IHttpClientFactory httpClientFactory,
			IHttpContextAccessor httpContextAccessor,
			ClassifiedCharacteristicsService ClassifiedCharacteristicsService,
			SlApiResponse<PaginatedList<ClassifiedCharacteristicsDto>, object> responseList,
			SlApiResponse<ClassifiedCharacteristicsDto, object> response
		) : base(mapper, configuration, httpClientFactory, httpContextAccessor)
		{
			this.ClassifiedCharacteristicsService = ClassifiedCharacteristicsService;
			this.responseList = responseList;
			this.response = response;
		}

		public async Task<SlApiResponse<PaginatedList<ClassifiedCharacteristicsDto>, object>> GetAllWithPagination(
			[FromQuery] SlApiPaginationQuery query
		)
		{
			return await this.ClassifiedCharacteristicsService.GetAllWithPagination(
				query,
				this.responseList
			);
		}

		public async Task<SlApiResponse<ClassifiedCharacteristicsDto, object>> GetById(int id)
		{
			return await this.ClassifiedCharacteristicsService.GetById(
				id,
				this.response
			);
		}

		public async Task<SlApiResponse<ClassifiedCharacteristicsDto, object>> UpdateDtoById(
			int id,
			ClassifiedCharacteristicsDto dto,
			CancellationToken cancellationToken
		)
		{
			return await this.ClassifiedCharacteristicsService.UpdateDtoById(
				id,
				dto,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<ClassifiedCharacteristicsDto, object>> AddDto(
			ClassifiedCharacteristicsDto dto,
			CancellationToken cancellationToken
		)
		{
			return await this.ClassifiedCharacteristicsService.AddDto(
				dto,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<ClassifiedCharacteristicsDto, object>> DeleteDtoById(
			int id,
			CancellationToken cancellationToken
		)
		{
			return await this.ClassifiedCharacteristicsService.DeleteDtoById(
				id,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<ClassifiedCharacteristicsDto, object>> DisableEnableDtoById(
			int id,
			CancellationToken cancellationToken
		)
		{
			return await this.ClassifiedCharacteristicsService.DisableEnableDtoById(
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