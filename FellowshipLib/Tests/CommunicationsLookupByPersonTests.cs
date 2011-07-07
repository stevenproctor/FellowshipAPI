using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FluentAssertions;
using FellowshipLib.APIRequests.Get;

namespace FellowshipLib.Tests
{
	[TestFixture]
	public class CommunicationsLookupByPersonTests
	{
		[Test]
		[Category("IntegrationTest")]
		public void WhenSearchingForCommunicationsByAValidUser_TheResultShouldNotBeNull()
		{
			var personId = "18970874";
			var lookup = new CommunicationsLookupByPerson(personId);
			lookup.Find();
			lookup.Succeeded().Should().BeTrue();
			lookup.Result().Should().NotBeNull();
		}

		[Test]
		[Category("IntegrationTest")]
		public void WhenSearchingForCommunicationsByAnInvalidUser_TheResultShouldBeNull()
		{
			var personId = Guid.NewGuid().ToString();
			var lookup = new CommunicationsLookupByPerson(personId);
			lookup.Find();
			lookup.Succeeded().Should().BeFalse();
			lookup.Result().Should().BeNull();
		}
	}
}
