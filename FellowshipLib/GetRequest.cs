using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;

namespace FellowshipLib
{
	public abstract class GetRequest<T> where T : new()
	{
		private T results;

		protected void Get()
		{
			var request = new RestRequest(Method.GET);
			request.Resource = GetResource() + ".xml";
			request.RequestFormat = DataFormat.Xml;
			AddParameters(request);
			var apiRequest = new FellowshipAPI();
			results = apiRequest.SendRequest<T>(request);
		}

		public T Results()
		{
			return results;
		}

		protected virtual void AddParameters(RestRequest request)
		{
		}

		protected abstract string GetResource();
	}
}
