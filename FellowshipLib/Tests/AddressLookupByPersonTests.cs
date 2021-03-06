﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FluentAssertions;
using FellowshipLib.Tests;

namespace FellowshipLib.Tests
{
	[TestFixture]
	public class AddressLookupByPersonTests
	{
		[Test]
		[Category("IntegrationTest")]
		public void WhenFindingAddressesByAValidPersonId_ThenTheAddressesShouldNotBeNull()
		{
			var addressLookup = new AddressLookupByPerson(GetRequestTestsHelper.ValidPersonId);
			addressLookup.Find();

			addressLookup.Succeeded().Should().BeTrue();

			var addresses = addressLookup.Result();
			addresses.Should().NotBeNull();
			addresses.Count.Should().BeGreaterOrEqualTo(1);
		}

		[Test]
		[Category("IntegrationTest")]
		public void WhenFindingAddressesByAnInvalidPersonId_ThenTheAddressesShouldBeNull()
		{
			var addressLookup = new AddressLookupByPerson(GetRequestTestsHelper.InValidPersonId);
			addressLookup.Find();
			addressLookup.Succeeded().Should().BeFalse();
		}
	}
}
