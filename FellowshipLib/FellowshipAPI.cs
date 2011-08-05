using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;

namespace FellowshipLib
{
	internal class FellowshipAPI
	{
		private const string baseUrl = "https://demo.fellowshiponeapi.com/v1/";
		public T SendRequest<T>(RestRequest request) where T : new()
		{
			var client = new RestClient();
			client.BaseUrl = baseUrl;
			AddDefaultParameters(client);

			var response = client.Execute<T>(request);
			if (response.Content.StartsWith("400"))
				return default(T);
			return response.Data;
		}

		private static void AddDefaultParameters(RestClient client)
		{
			client.AddDefaultParameter("mode", "Demo", ParameterType.GetOrPost);
		}
	}
}
