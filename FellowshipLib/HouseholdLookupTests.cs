using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FluentAssertions;

namespace FellowshipLib
{
	[TestFixture]
	public class HouseholdLookupTests
	{
		[Test]
		[Category("IntegrationTest")]
		public void WhenFindingPeopleInAHousehold_EveryPersonInShouldHaveThatHouseholdId()
		{
			string householdId = "7320143";
			var lookup = new HouseholdLookup(householdId);
			lookup.FindHousehold();
			People people = lookup.Result();

			people.Should().NotBeNull();
			people.Should().OnlyContain(p => p.HouseholdID == householdId);
		}
	}
}
