﻿using System;

namespace CleanArchitecture.Domain.Common
{
	public abstract class AuditableEntity
	{
		public Guid Guid { get; set; }
		public DateTime Created { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? LastModified { get; set; }
		public string LastModifiedBy { get; set; }
	}
}