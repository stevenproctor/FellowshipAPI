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
			var addressId = GetRequestTestsHelper.ValidAddressId;
			var editRequest = new EditAddressRequest(GetRequestTestsHelper.ValidPersonId, addressId);
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
			var addressId = GetRequestTestsHelper.ValidAddressId;
			var editRequest = new EditAddressRequest(GetRequestTestsHelper.InValidPersonId, addressId);
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
			var editRequest = new EditAddressRequest(GetRequestTestsHelper.ValidPersonId, GetRequestTestsHelper.InvalidAddressId);
			editRequest.Find();

			editRequest.Succeeded().Should().BeFalse();
			var result = editRequest.Result();
			result.Should().BeNull();
		}
	}
}
