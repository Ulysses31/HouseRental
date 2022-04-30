using AutoMapper;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.MediatR.FrameType.Services;
using CleanArchitecture.Application.Repository.Interfaces.FrameType;
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

namespace CleanArchitecture.Application.Repository.FrameType
{
	/// <summary>
	/// FrameTypeRepo class
	/// </summary>
	public class FrameTypeRepo : BaseRepo<FrameTypeDto, FrameTypeDto>, IFrameTypeRepo
	{
		private readonly FrameTypeService FrameTypeService;
		private readonly SlApiResponse<PaginatedList<FrameTypeDto>, object> responseList;
		private readonly SlApiResponse<FrameTypeDto, object> response;

		public FrameTypeRepo(
			IMapper mapper,
			IConfiguration configuration,
			IHttpClientFactory httpClientFactory,
			IHttpContextAccessor httpContextAccessor,
			FrameTypeService FrameTypeService,
			SlApiResponse<PaginatedList<FrameTypeDto>, object> responseList,
			SlApiResponse<FrameTypeDto, object> response
		) : base(mapper, configuration, httpClientFactory, httpContextAccessor)
		{
			this.FrameTypeService = FrameTypeService;
			this.responseList = responseList;
			this.response = response;
		}

		public async Task<SlApiResponse<PaginatedList<FrameTypeDto>, object>> GetAllWithPagination(
			[FromQuery] SlApiPaginationQuery query
		)
		{
			return await this.FrameTypeService.GetAllWithPagination(
				query,
				this.responseList
			);
		}

		public async Task<SlApiResponse<FrameTypeDto, object>> GetById(int id)
		{
			return await this.FrameTypeService.GetById(
				id,
				this.response
			);
		}

		public async Task<SlApiResponse<FrameTypeDto, object>> UpdateDtoById(
			int id,
			FrameTypeDto dto,
			CancellationToken cancellationToken
		)
		{
			return await this.FrameTypeService.UpdateDtoById(
				id,
				dto,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<FrameTypeDto, object>> AddDto(
			FrameTypeDto dto,
			CancellationToken cancellationToken
		)
		{
			return await this.FrameTypeService.AddDto(
				dto,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<FrameTypeDto, object>> DeleteDtoById(
			int id,
			CancellationToken cancellationToken
		)
		{
			return await this.FrameTypeService.DeleteDtoById(
				id,
				this.response,
				cancellationToken
			);
		}

		public async Task<SlApiResponse<FrameTypeDto, object>> DisableEnableDtoById(
			int id,
			CancellationToken cancellationToken
		)
		{
			return await this.FrameTypeService.DisableEnableDtoById(
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