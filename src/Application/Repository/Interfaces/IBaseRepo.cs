using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Repository.Interfaces
{
	/// <summary>
	/// IBaseRepo interface
	/// </summary>
	/// <typeparam name="TListDto"></typeparam>
	/// <typeparam name="TDto"></typeparam>
	public interface IBaseRepo<TListDto, TDto>
	{
	}
}