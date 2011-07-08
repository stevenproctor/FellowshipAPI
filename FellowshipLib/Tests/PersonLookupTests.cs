using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FluentAssertions;

namespace FellowshipLib.Tests
{
	[TestFixture]
	public class PersonLookupTests
	{
		[Test]
		[Category("IntegrationTests")]
		public void WhenSearchingForAUserByAValidId_TheUserShouldNotBeNull()
		{
			var lookup = new PersonLookup(GetRequestTestsHelper.ValidPersonId);
			lookup.Find();
			var person = lookup.Result();
			person.Should().NotBeNull();
		}

		[Test]
		[Category("IntegrationTests")]
		public void WhenSearchingForAUserByAnInvalidId_TheUserShouldNotBeNull()
		{
			var lookup = new PersonLookup(GetRequestTestsHelper.InValidPersonId);
			lookup.Find();
			lookup.Succeeded().Should().BeFalse();
		}
	}
}
