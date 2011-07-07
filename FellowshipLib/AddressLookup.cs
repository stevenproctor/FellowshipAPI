using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;

namespace FellowshipLib
{
	public class AddressLookupByPerson : GetRequest<Addresses>
	{
		private const string PersonIdParameter = "Person";
		private const string resource = "People/{" + PersonIdParameter + "}/Addresses";
		private string personId;

		public AddressLookupByPerson(string personId)
		{
			this.personId = personId;
		}

		protected override void AddParameters(RestRequest request)
		{
			request.AddParameter(PersonIdParameter, personId, ParameterType.UrlSegment);
		}

		protected override string GetResource()
		{
			return resource;
		}
	}
}
