using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FluentAssertions;

namespace FellowshipLib
{
	[TestFixture]
	public class PersonQueryTests
	{
		[Test]
		public void WhenSearchingForAPerson_WithANameOfMeyer_ItShouldReturnAnEnumerationOfPeople()
		{
			var people = new PersonQuery().WithNameOf("Chad").Search();
			people.Should().NotBeNull();
			people.Count.Should().BeGreaterOrEqualTo(5);
		}

		[Test]
		public void WhenSearchingForAPerson_WithNoNameSpecified()
		{
			var query = new PersonQuery();
			var people = query.Search();
			people.Should().BeNull();
		}
	}
}
