using AutoMapper;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.MediatR.ClassifiedPurpose.Services;
using CleanArchitecture.Application.Repository.Interfaces.ClassifiedPurpose;
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

namespace CleanArchitecture.Application.Repository.ClassifiedPurpose
{
	/// <summary>
	/// ClassifiedPurposeRepo class
	/// </summary>
	public class ClassifiedPurposeRepo : BaseRepo<ClassifiedPurposeDto, ClassifiedPurposeDto>, IClassifiedPurposeRepo
	{
		private readonly ClassifiedPurposeService ClassifiedPurposeService;
		private readonly SlApiResponse<PaginatedList<ClassifiedPurposeDto>, object> responseList;
		private readonly SlApiResponse<ClassifiedPurposeDto, object> response;

		public ClassifiedPurposeRepo(
			IMapper mapper,
			IConfiguration configuration,
			IHttpClientFactory httpClientFactory,
			IHttpContextAccessor httpContextAccessor,
			ClassifiedPurposeService ClassifiedPurposeService,
			SlApiResponse<PaginatedList<ClassifiedPurposeDto>, object> responseList,
			SlApiResponse<ClassifiedPurposeDto, object> response
		) : base(mapper, configuration, httpClientFactory, httpContextAccessor)
		{
			this.ClassifiedPurposeService = ClassifiedPurposeService;
			this.responseList = responseList;
			this.response = response;
		}

		public async Task<SlApiResponse<PaginatedList<ClassifiedPurposeDto>, object>> GetAllWithPagination(
			[FromQuery] SlApiPaginationQuery query
		)
		{
			return await this.ClassifiedPurposeService.GetAllWithPagination(
				query,
				this.responseList
			);
		}

		public async Task<SlApiResponse<ClassifiedPurposeDto, object>> GetById(int id)
		{
			return await this.ClassifiedPurposeService.GetById(
				id,
				this.response
			);
		}

		public async Task<SlApiResponse<ClassifiedPurposeDto, object>> UpdateDtoById(
			int id,
			ClassifiedPurposeDto dto,
			CancellationToken cancellationToken
		)
		{
			return await this.ClassifiedPurposeService.UpdateDtoById(
				id,
				dto,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<ClassifiedPurposeDto, object>> AddDto(
			ClassifiedPurposeDto dto,
			CancellationToken cancellationToken
		)
		{
			return await this.ClassifiedPurposeService.AddDto(
				dto,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<ClassifiedPurposeDto, object>> DeleteDtoById(
			int id,
			CancellationToken cancellationToken
		)
		{
			return await this.ClassifiedPurposeService.DeleteDtoById(
				id,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<ClassifiedPurposeDto, object>> DisableEnableDtoById(
			int id,
			CancellationToken cancellationToken
		)
		{
			return await this.ClassifiedPurposeService.DisableEnableDtoById(
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