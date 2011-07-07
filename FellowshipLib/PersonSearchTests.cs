using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FluentAssertions;

namespace FellowshipLib
{
	[TestFixture]
	public class PersonSearchTests
	{
		[Test]
		[Category("IntegrationTest")]
		public void WhenSearchingForAPerson_WithANameOfA_ItShouldReturnAPeopleSearchResults()
		{
			var query = new PersonSearch("A");
			query.Find();
			var people = query.Result();

			people.Should().NotBeNull();
			people.SearchName.Should().Be("A");
			people.PageNumber.Should().Be(1);
			people.AdditionalPages.Should().BeGreaterOrEqualTo(25, "AdditionalPages");
			people.TotalRecords.Should().BeGreaterOrEqualTo(500, "TotalRecords");
			people.Count.Should().Be(20);
		}
		
		[Test]
		[Category("IntegrationTest")]
		public void WhenSearchingForAPerson_WithANameOfMeyer_ItShouldReturnAPeopleSearchResults()
		{
			var query = new PersonSearch("Meyer");
			query.Find();
			var people = query.Result();

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
			var query = new PersonSearch("%").AtPage(100);
			query.Find();
			var people = query.Result();

			people.Should().NotBeNull();
			people.PageNumber.Should().Be(100, "PageNumber");
		}

		[Test]
		[Category("IntegrationTest")]
		public void WhenSearchingForAPerson_AndAPageNumberLargerThanTheTotalPagesIsSpecified_ItShouldReturnNoResultsForThatPage()
		{
			var query = new PersonSearch("%").AtPage(int.MaxValue);
			query.Find();
			query.Succeeded().Should().BeFalse();
		}

		[Test]
		[Category("IntegrationTest")]
		public void WhenSearchingForAPerson_WithANameOfTwoSpaces()
		{
			var query = new PersonSearch("  ").AtPage(int.MaxValue);
			query.Find();
			query.Succeeded().Should().BeFalse();
		}

		[Test]
		[Category("IntegrationTest")]
		public void WhenSearchingForAPerson_WithNoNameSpecified_ItShouldBeTheSameAsAWildcardSearch()
		{
			var query = new PersonSearch(string.Empty);
			query.Find();
			var people = query.Result();
			people.Should().NotBeEmpty();
		}
	}
}
