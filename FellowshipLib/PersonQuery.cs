using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using RestSharp;
using Newtonsoft.Json;
using System.Web;

namespace FellowshipLib
{
	class PersonQuery
	{
		private string searchName = string.Empty;
		private string searchResponse;
		internal PersonQuery WithNameOf(string name)
		{
			this.searchName = HttpUtility.UrlEncode(name);
			return this;
		}

		internal People Search()
		{
			string searchParams = "searchFor=" + searchName;
			var request = new RestRequest(Method.GET);
			request.Resource = "People/Search.xml";
			request.RequestFormat = DataFormat.Xml;
			request.AddParameter("searchFor", searchName, ParameterType.GetOrPost);
			var apiRequest = new FellowshipAPI();
			return apiRequest.SendRequest<People>(request);
		}

		internal string GetResponse()
		{
			return searchResponse;
		}
	}

	internal class FellowshipAPI
	{
		private const string baseUrl = "https://demo.fellowshiponeapi.com/v1/";
		private string response;
		public T SendRequest<T>(RestRequest request) where T : new()
		{
			var client = new RestClient();
			client.BaseUrl = baseUrl;
			client.AddDefaultParameter("mode", "Demo", ParameterType.GetOrPost);
			
			var response = client.Execute<T>(request);
			if (response.Content.StartsWith("400"))
				return default(T);
			return response.Data;
		}

		public string GetResponse()
		{
			return response;
		}
	}
}
