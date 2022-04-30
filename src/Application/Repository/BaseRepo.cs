using AutoMapper;
using CleanArchitecture.Application.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace GenesisCloud.Application.ServerApp
{
	public abstract class BaseRepo<TListDto, TDto> : IBaseRepo<TListDto, TDto> where TListDto : class, new() where TDto : class, new()
	{
		private readonly IMapper mapper;
		private readonly IConfiguration configuration;
		private readonly IHttpClientFactory httpClientFactory;
		private readonly IHttpContextAccessor httpContextAccessor;

		public BaseRepo(
			IMapper mapper,
			IConfiguration configuration,
			IHttpClientFactory httpClientFactory,
			IHttpContextAccessor httpContextAccessor
		)
		{
			this.mapper = mapper;
			this.configuration = configuration;
			this.httpClientFactory = httpClientFactory;
			this.httpContextAccessor = httpContextAccessor;
		}
	}
}