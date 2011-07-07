using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;

namespace FellowshipLib.APIRequests.Get
{
	public class CommunicationsLookupByPerson : GetRequest<Communications>
	{
		private const string PersonIdParameter = "PersonId";
		private const string Resource = "People/{" + PersonIdParameter + "}/Communications";
		private string personId;

		public CommunicationsLookupByPerson(string personId)
		{
			this.personId = personId;
		}

		protected override void AddParameters(RestRequest request)
		{
			request.AddParameter(PersonIdParameter, personId, ParameterType.UrlSegment);
		}

		protected override string GetResource()
		{
			return Resource;
		}
	}
}
