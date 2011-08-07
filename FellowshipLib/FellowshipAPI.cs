using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using System.Net;

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
			if (response.StatusCode == 0)
			{
				Succeeded = false;
				return default(T);
			}
			if (response.StatusCode == HttpStatusCode.MethodNotAllowed)
			{
				Succeeded = false;
				return default(T);
			}
			if (response.StatusCode == HttpStatusCode.NotFound)
			{
				Succeeded = false;
				return default(T);
			}
			if (response.Content.StartsWith("400"))
			{
				Succeeded = false;
				return new T();
			}
			if (response.Data == null)
			{
				Succeeded = false;
				return new T();
			}

			Succeeded = true;
			return response.Data;
		}

		private static void AddDefaultParameters(RestClient client)
		{
			client.AddDefaultParameter("mode", "Demo", ParameterType.GetOrPost);
		}

		public bool Succeeded { get; private set; }
	}
}
