﻿using System;
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
		[Category("IntegrationTest")]
		public void WhenSearchingForAPerson_WithANameOfA_ItShouldReturnAnEnumerationOfPeople()
		{
			var query = new PersonQuery("A");
			query.Search();
			var people = query.Results();

			people.Should().NotBeNull();
			people.PageNumber.Should().Be(1);
			people.AdditionalPages.Should().BeGreaterOrEqualTo(25, "AdditionalPages");
			people.TotalRecords.Should().BeGreaterOrEqualTo(500, "TotalRecords");
			people.Count.Should().Be(20);
		}
		
		[Test]
		[Category("IntegrationTest")]
		public void WhenSearchingForAPerson_WithANameOfMeyer_ItShouldReturnAnEnumerationOfPeople()
		{
			var query = new PersonQuery("Meyer");
			query.Search();
			var people = query.Results();

			people.Should().NotBeNull();
			people.PageNumber.Should().Be(1, "PageNumber");
			people.AdditionalPages.Should().BeGreaterOrEqualTo(0, "AdditionalPages");
			people.TotalRecords.Should().BeGreaterOrEqualTo(5, "TotalRecords");
			people.Count.Should().BeGreaterOrEqualTo(5);
		}

		[Test]
		[Category("IntegrationTest")]
		public void WhenSearchingForAPerson_AndAPageNumberIsSpecified_ItShouldReturnTheResultsForThatPage()
		{
			var query = new PersonQuery("%").AtPage(100);
			query.Search();
			var people = query.Results();

			people.Should().NotBeNull();
			people.PageNumber.Should().Be(100, "PageNumber");
		}

		[Test]
		[Category("IntegrationTest")]
		public void WhenSearchingForAPerson_AndAPageNumberLargerThanTheTotalPagesIsSpecified_ItShouldReturnNoResultsForThatPage()
		{
			var query = new PersonQuery("%").AtPage(int.MaxValue);
			query.Search();
			var people = query.Results();

			people.Should().NotBeNull();
			people.PageNumber.Should().Be(0, "PageNumber");
			people.TotalRecords.Should().Be(0, "TotalRecords");
		}

		[Test]
		[Category("IntegrationTest")]
		public void WhenSearchingForAPerson_WithNoNameSpecified_ItShouldBeTheSameAsAWildcardSearch()
		{
			var query = new PersonQuery(string.Empty);
			query.Search();
			var people = query.Results();
			people.Should().NotBeEmpty();
		}
	}
}
