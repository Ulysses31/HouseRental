using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.UnitTests.Helpers
{
	public class TestDomainEntitiestHelper
	{
		public static void CompareObjects<T, TMirror>()
		{
			var t = Activator.CreateInstance(typeof(T));
			var tInstanseType = t.GetType();

			var tMirror = Activator.CreateInstance(typeof(TMirror));
			var tMirrorInstanseType = tMirror.GetType();

			var tMirrorProps = tMirrorInstanseType.GetProperties();

			var testName = tMirrorInstanseType.Name
				.Substring(0, tMirrorInstanseType.Name.IndexOf("Dto"));

			tInstanseType.Name.Should().Be(testName);
		}

		public static void CompareProperties<T, TMirror>()
		{
			var errorMessage = "Type: {0}; Property: {1}";

			var t = Activator.CreateInstance(typeof(T));
			var tInstanseType = t.GetType();

			var tMirror = Activator.CreateInstance(typeof(TMirror));
			var tMirrorInstanseType = tMirror.GetType();

			var tMirrorProps = tMirrorInstanseType.GetProperties();

			foreach (var prop in tMirrorProps)
			{
				var tProperty = tInstanseType.GetProperty(prop.Name);
				tProperty.Should().NotBeNull(
					because: string.Format(errorMessage, tInstanseType.FullName, prop.Name)
				);
			}
		}
	}
}
