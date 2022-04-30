using AutoMapper;
using CleanArchitecture.Application.Repository.Interfaces;

namespace CleanArchitecture.Application
{
	public class BaseRequestHandler
	{
		protected readonly IMapper Mapper;
		protected readonly IRepoManager RepoManager;

		public BaseRequestHandler(
			IRepoManager repoManager,
			IMapper mapper
		)
		{
			this.RepoManager = repoManager;
			this.Mapper = mapper;
		}
	}
}