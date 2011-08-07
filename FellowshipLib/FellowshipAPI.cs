using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using System.Net;

namespace FellowshipLib
{
	internal class FellowshipAPI<T> where T : new()
	{
		private const string baseUrl = "https://demo.fellowshiponeapi.com/v1/";
		private T resultSet;
		public void SendRequest(RestRequest request)
		{
			var client = new RestClient();
			client.BaseUrl = baseUrl;
			AddDefaultParameters(client);

			var response = client.Execute<T>(request);
			if (response.StatusCode == 0)
			{
				Succeeded = false;
				resultSet = default(T);
			}
			else if (response.StatusCode == HttpStatusCode.MethodNotAllowed)
			{
				Succeeded = false;
				resultSet = default(T);
			}
			else if (response.StatusCode == HttpStatusCode.NotFound)
			{
				Succeeded = false;
				resultSet = default(T);
			}
			else if (response.Content.StartsWith("400"))
			{
				Succeeded = false;
				resultSet = new T();
			}
			else if (response.Data == null)
			{
				Succeeded = false;
				resultSet = new T();
			}
			else
			{
				Succeeded = true;
				resultSet = response.Data;
			}
		}

		private static void AddDefaultParameters(RestClient client)
		{
			client.AddDefaultParameter("mode", "Demo", ParameterType.GetOrPost);
		}

		public bool Succeeded { get; private set; }

		internal T GetResultSet()
		{
			return resultSet;
		}
	}
}
