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
	abstract class GetRequest<T> where T : new()
	{
		internal T Search()
		{
			var request = new RestRequest(Method.GET);
			request.Resource = GetResource() + ".xml";
			request.RequestFormat = DataFormat.Xml;
			AddParameters(request);
			var apiRequest = new FellowshipAPI();
			return apiRequest.SendRequest<T>(request);
		}

		private void AddParameters(RestRequest request)
		{
			foreach (Parameter parameter in GetParameters())
			{
				request.AddParameter(parameter);
			}
		}

		protected abstract IEnumerable<Parameter> GetParameters();
		protected abstract string GetResource();
	}

	class PersonQuery : GetRequest<People>
	{
		private string searchName = string.Empty;
		private string searchResponse;
		internal PersonQuery WithNameOf(string name)
		{
			this.searchName = HttpUtility.UrlEncode(name);
			return this;
		}

		protected override IEnumerable<Parameter> GetParameters()
		{
			var parameters = new List<Parameter>();
			var parameter = new Parameter();
			parameter.Name = "searchFor";
			parameter.Value = searchName;
			parameter.Type = ParameterType.GetOrPost;
			parameters.Add(parameter);
			return parameters;
		}

		protected override string GetResource()
		{
			return "People/Search";
		}

		internal string GetResponse()
		{
			return searchResponse;
		}
	}

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
