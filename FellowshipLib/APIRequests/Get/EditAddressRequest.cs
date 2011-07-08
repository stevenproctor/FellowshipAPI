using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;

namespace FellowshipLib.APIRequests.Get
{
	public class EditAddressRequest : GetRequest<Address>
	{
		private const string PersonParameterId = "PersonId";
		private const string AddressParameterId = "AddressId";
		private const string Resource = "People/{" + PersonParameterId + "}/Addresses/{" + AddressParameterId + "}/edit";

		private string personId;
		private string addressId;

		public EditAddressRequest(string personId, string addressId)
		{
			this.personId = personId;
			this.addressId = addressId;
		}

		protected override void AddParameters(RestRequest request)
		{
			request.AddParameter(PersonParameterId, personId, ParameterType.UrlSegment);
			request.AddParameter(AddressParameterId, addressId, ParameterType.UrlSegment);
		}

		protected override string GetResource()
		{
			return Resource;
		}
	}
}
