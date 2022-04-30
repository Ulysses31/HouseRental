//using AutoMapper;
//using CleanArchitecture.Domain.Entities;
//using CleanArchitecture.Domain.Interfaces;
//using System;

//namespace CleanArchitecture.Domain.DTOs
//{
//	public class DbLogDto : IMapFrom<DbLog>
//	{
//		public int DbLogId { get; set; }
//		public string Message { get; set; }
//		public string MessageTemplate { get; set; }
//		public string Level { get; set; }
//		public DateTime TimeStamp { get; set; }
//		public string Exception { get; set; }
//		public string Properties { get; set; }
//		public int? EventType { get; set; }
//		public string Release { get; set; }
//		public string OsVersion { get; set; }
//		public string ServerName { get; set; }
//		public string UserName { get; set; }
//		public string UserDomainName { get; set; }
//		public string Address { get; set; }
//		public string All_SqlColumn_Defaults { get; set; }

//		//public void Mapping(Profile profile)
//		//{
//		//	profile.CreateMap<DbLog, DbLogDto>()
//		//		.ForMember(d => d.Properties, opt => opt.MapFrom(
//		//			s => s.Properties
//		//		));
//		//}
//	}
//}