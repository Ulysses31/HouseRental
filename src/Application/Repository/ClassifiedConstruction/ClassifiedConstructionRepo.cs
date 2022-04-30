using AutoMapper;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.MediatR.ClassifiedConstruction.Services;
using CleanArchitecture.Application.Repository.Interfaces.ClassifiedConstruction;
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

namespace CleanArchitecture.Application.Repository.ClassifiedConstruction
{
	/// <summary>
	/// ClassifiedConstructionRepo class
	/// </summary>
	public class ClassifiedConstructionRepo : BaseRepo<ClassifiedConstructionDto, ClassifiedConstructionDto>, IClassifiedConstructionRepo
	{
		private readonly ClassifiedConstructionService ClassifiedConstructionService;
		private readonly SlApiResponse<PaginatedList<ClassifiedConstructionDto>, object> responseList;
		private readonly SlApiResponse<ClassifiedConstructionDto, object> response;

		public ClassifiedConstructionRepo(
			IMapper mapper,
			IConfiguration configuration,
			IHttpClientFactory httpClientFactory,
			IHttpContextAccessor httpContextAccessor,
			ClassifiedConstructionService ClassifiedConstructionService,
			SlApiResponse<PaginatedList<ClassifiedConstructionDto>, object> responseList,
			SlApiResponse<ClassifiedConstructionDto, object> response
		) : base(mapper, configuration, httpClientFactory, httpContextAccessor)
		{
			this.ClassifiedConstructionService = ClassifiedConstructionService;
			this.responseList = responseList;
			this.response = response;
		}

		public async Task<SlApiResponse<PaginatedList<ClassifiedConstructionDto>, object>> GetAllWithPagination(
			[FromQuery] SlApiPaginationQuery query
		)
		{
			return await this.ClassifiedConstructionService.GetAllWithPagination(
				query,
				this.responseList
			);
		}

		public async Task<SlApiResponse<ClassifiedConstructionDto, object>> GetById(int id)
		{
			return await this.ClassifiedConstructionService.GetById(
				id,
				this.response
			);
		}

		public async Task<SlApiResponse<ClassifiedConstructionDto, object>> UpdateDtoById(
			int id,
			ClassifiedConstructionDto dto,
			CancellationToken cancellationToken
		)
		{
			return await this.ClassifiedConstructionService.UpdateDtoById(
				id,
				dto,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<ClassifiedConstructionDto, object>> AddDto(
			ClassifiedConstructionDto dto,
			CancellationToken cancellationToken
		)
		{
			return await this.ClassifiedConstructionService.AddDto(
				dto,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<ClassifiedConstructionDto, object>> DeleteDtoById(
			int id,
			CancellationToken cancellationToken
		)
		{
			return await this.ClassifiedConstructionService.DeleteDtoById(
				id,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<ClassifiedConstructionDto, object>> DisableEnableDtoById(
			int id,
			CancellationToken cancellationToken
		)
		{
			return await this.ClassifiedConstructionService.DisableEnableDtoById(
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