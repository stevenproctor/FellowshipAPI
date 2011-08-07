using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using System.Net;
using FellowshipLib.Extensions;

namespace FellowshipLib
{
	internal class FellowshipAPI<T> where T : new()
	{
		private const string baseUrl = "https://demo.fellowshiponeapi.com/v1/";
		private T resultSet;
		private string messages;
		public void SendRequest(RestRequest request)
		{
			var client = new RestClient();
			client.BaseUrl = baseUrl;
			AddDefaultParameters(client);

			var response = client.Execute<T>(request);
			if (response.StatusCode.IsFailureStatus())
			{
				Succeeded = false;
				resultSet = default(T);
				messages = response.StatusDescription;
			}
			else if (response.Content.StartsWith("400: "))
			{
				Succeeded = false;
				messages = response.Content.Replace("400: ", "");
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

		public string GetMessages()
		{
			return messages;
		}

		internal T GetResultSet()
		{
			return resultSet;
		}
	}
}
