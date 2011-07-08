using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FluentAssertions;

namespace FellowshipLib.Tests
{
	[TestFixture]
	public class HouseholdLookupTests
	{
		[Test]
		[Category("IntegrationTest")]
		public void WhenFindingPeopleInAHousehold_EveryPersonInShouldHaveThatHouseholdId()
		{
			string householdId = GetRequestTestsHelper.ValidHouseholdId;
			var lookup = new HouseholdLookup(householdId);
			lookup.Find();
			People people = lookup.Result();

			people.Should().NotBeNull();
			people.Should().OnlyContain(p => p.HouseholdID == householdId);
		}
	}
}
