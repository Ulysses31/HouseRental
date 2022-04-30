//using CleanArchitecture.Domain.DTOs;
//using CleanArchitecture.Domain.Interfaces;
//using CleanArchitecture.Infrastructure.Files.Maps;
//using CsvHelper;
//using System.Collections.Generic;
//using System.Globalization;
//using System.IO;

//namespace CleanArchitecture.Infrastructure.Files
//{
//	public class CsvFileBuilder : ICsvFileBuilder
//	{
//		public byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecordDto> records)
//		{
//			using var memoryStream = new MemoryStream();
//			using (var streamWriter = new StreamWriter(memoryStream))
//			{
//				using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

//				csvWriter.Configuration.RegisterClassMap<TodoItemRecordMap>();
//				csvWriter.WriteRecords(records);
//			}

//			return memoryStream.ToArray();
//		}
//	}
//}