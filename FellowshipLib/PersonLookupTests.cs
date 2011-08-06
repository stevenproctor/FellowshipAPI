using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FluentAssertions;

namespace FellowshipLib
{
	[TestFixture]
	public class PersonLookupTests
	{
		[Test]
		[Category("IntegrationTests")]
		public void WhenSearchingForAUserByAValidId_TheUserShouldNotBeNull()
		{
			var lookup = new PersonLookup("18970886");
			lookup.FindPerson();
			var person = lookup.Result();
			person.Should().NotBeNull();
		}

		[Test]
		[Category("IntegrationTests")]
		public void WhenSearchingForAUserByAnInvctalidId_TheUserShouldNotBeNull()
		{
			var lookup = new PersonLookup("0123456789");
			lookup.FindPerson();
			var person = lookup.Result();
			person.Should().BeNull();
		}
	}
}
