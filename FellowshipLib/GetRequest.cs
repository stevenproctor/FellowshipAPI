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
		private bool succeeded;

		protected void Get()
		{
			var request = new RestRequest(Method.GET);
			request.Resource = GetResource() + ".xml";
			request.RequestFormat = DataFormat.Xml;
			AddParameters(request);
			var apiRequest = new FellowshipAPI<T>();
			apiRequest.SendRequest(request);
			succeeded = apiRequest.Succeeded;
			//messages = apiRequest.GetMessages();
			results = apiRequest.GetResultSet();
		}

		public bool Succeeded()
		{
			return succeeded;
		}

		public T Result()
		{
			return results;
		}

		protected virtual void AddParameters(RestRequest request)
		{
		}

		protected abstract string GetResource();
	}
}
