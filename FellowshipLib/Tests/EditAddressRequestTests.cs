using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FellowshipLib.APIRequests.Get;
using FluentAssertions;

namespace FellowshipLib.Tests
{
	[TestFixture]
	public class EditAddressRequestTests
	{
		[TestCase]
		[Category("IntegrationTest")]
		public void WhenCallingEditAddressFor_AValidPerson_AndAValidAddressId_ItShouldReturnThatAddress()
		{
			var personId = "18970874";
			var addressId = "12162767";
			var editRequest = new EditAddressRequest(personId, addressId);
			editRequest.Find();

			editRequest.Succeeded().Should().BeTrue();
			var result = editRequest.Result();
			result.Should().NotBeNull();
			result.Id.Should().Be(addressId);
		}

		[TestCase]
		[Category("IntegrationTest")]
		public void WhenCallingEditAddressFor_AnInvalidPerson_AndAValidAddressId_ItShouldReturnThatAddress()
		{
			var personId = "invalidPersonId";
			var addressId = "12162767";
			var editRequest = new EditAddressRequest(personId, addressId);
			editRequest.Find();

			editRequest.Succeeded().Should().BeTrue();
			var result = editRequest.Result();
			result.Should().NotBeNull();
			result.Id.Should().Be(addressId);
		}

		[TestCase]
		[Category("IntegrationTest")]
		public void WhenCallingEditAddressFor_AnValidPerson_AndAnInvalidAddressId_ItShouldFail()
		{
			var personId = "18970874";
			var addressId = "121627670000";
			var editRequest = new EditAddressRequest(personId, addressId);
			editRequest.Find();

			editRequest.Succeeded().Should().BeFalse();
			var result = editRequest.Result();
			result.Should().BeNull();
		}
	}
}
