using AutoMapper;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.MediatR.ClassifiedType.Services;
using CleanArchitecture.Application.Repository.Interfaces.ClassifiedType;
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

namespace CleanArchitecture.Application.Repository.ClassifiedType
{
	/// <summary>
	/// ClassifiedTypeRepo class
	/// </summary>
	public class ClassifiedTypeRepo : BaseRepo<ClassifiedTypeDto, ClassifiedTypeDto>, IClassifiedTypeRepo
	{
		private readonly ClassifiedTypeService ClassifiedTypeService;
		private readonly SlApiResponse<PaginatedList<ClassifiedTypeDto>, object> responseList;
		private readonly SlApiResponse<ClassifiedTypeDto, object> response;

		public ClassifiedTypeRepo(
			IMapper mapper,
			IConfiguration configuration,
			IHttpClientFactory httpClientFactory,
			IHttpContextAccessor httpContextAccessor,
			ClassifiedTypeService ClassifiedTypeService,
			SlApiResponse<PaginatedList<ClassifiedTypeDto>, object> responseList,
			SlApiResponse<ClassifiedTypeDto, object> response
		) : base(mapper, configuration, httpClientFactory, httpContextAccessor)
		{
			this.ClassifiedTypeService = ClassifiedTypeService;
			this.responseList = responseList;
			this.response = response;
		}

		public async Task<SlApiResponse<PaginatedList<ClassifiedTypeDto>, object>> GetAllWithPagination(
			[FromQuery] SlApiPaginationQuery query
		)
		{
			return await this.ClassifiedTypeService.GetAllWithPagination(
				query,
				this.responseList
			);
		}

		public async Task<SlApiResponse<ClassifiedTypeDto, object>> GetById(int id)
		{
			return await this.ClassifiedTypeService.GetById(
				id,
				this.response
			);
		}

		public async Task<SlApiResponse<ClassifiedTypeDto, object>> UpdateDtoById(
			int id,
			ClassifiedTypeDto dto,
			CancellationToken cancellationToken
		)
		{
			return await this.ClassifiedTypeService.UpdateDtoById(
				id,
				dto,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<ClassifiedTypeDto, object>> AddDto(
			ClassifiedTypeDto dto,
			CancellationToken cancellationToken
		)
		{
			return await this.ClassifiedTypeService.AddDto(
				dto,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<ClassifiedTypeDto, object>> DeleteDtoById(
			int id,
			CancellationToken cancellationToken
		)
		{
			return await this.ClassifiedTypeService.DeleteDtoById(
				id,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<ClassifiedTypeDto, object>> DisableEnableDtoById(
			int id,
			CancellationToken cancellationToken
		)
		{
			return await this.ClassifiedTypeService.DisableEnableDtoById(
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