using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using System;

namespace CleanArchitecture.Domain.DTOs
{
	public class PhotosDto : IMapFrom<Photos>
	{
		public int PhotoID { get; set; }
		public int ClassifiedID { get; set; }
		public ClassifiedDto Classified { get; set; }
		public string FileName { get; set; }
		public decimal FileSize { get; set; }
		public byte[] FileContent { get; set; }
		public bool IsEnabled { get; set; }
		public bool IsDeleted { get; set; }
	}
}