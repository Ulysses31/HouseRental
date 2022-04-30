//using CleanArchitecture.Domain.Common;
//using System;
//using System.ComponentModel.DataAnnotations;

//namespace CleanArchitecture.Domain.Entities
//{
//	public class DbLog : AuditableEntity
//	{
//		public int DbLogId { get; set; }

//		[Display(Name = "Message")]
//		public string Message { get; set; }

//		[Display(Name = "MessageTemplate")]
//		public string MessageTemplate { get; set; }

//		[Display(Name = "Level")]
//		public string Level { get; set; }

//		[Display(Name = "TimeStamp")]
//		public DateTime? TimeStamp { get; set; }

//		[Display(Name = "Exception")]
//		public string Exception { get; set; }

//		[Display(Name = "Properties")]
//		public string Properties { get; set; }

//		[Display(Name = "EventType")]
//		public int? EventType { get; set; }

//		[Display(Name = "Release")]
//		[StringLength(32)]
//		public string Release { get; set; }

//		[Display(Name = "OsVersion")]
//		[StringLength(50)]
//		public string OsVersion { get; set; }

//		[Display(Name = "ServerName")]
//		[StringLength(50)]
//		public string ServerName { get; set; }

//		[Display(Name = "UserName")]
//		[StringLength(100)]
//		public string UserName { get; set; }

//		[Display(Name = "UserDomainName")]
//		[StringLength(150)]
//		public string UserDomainName { get; set; }

//		[Display(Name = "Address")]
//		[StringLength(150)]
//		public string Address { get; set; }

//		[Display(Name = "All_SqlColumn_Defaults")]
//		public string All_SqlColumn_Defaults { get; set; }
//	}
//}