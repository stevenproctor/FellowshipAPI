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

	public class PersonQuery : GetRequest<People>
	{
		private const int MinimumNameParameterLength = 2;

		private string searchName = string.Empty;
		
		public PersonQuery WithNameOf(string name)
		{
			name = SanitizeName(name);
			this.searchName = name;
			return this;
		}

		private static string SanitizeName(string name)
		{
			if (name == null)
				name = string.Empty;

			return name.PadLeft(MinimumNameParameterLength);
		}

		public void Search()
		{
			Get();
		}

		protected override void AddParameters(RestRequest request)
		{
			request.AddParameter("searchFor", searchName, ParameterType.GetOrPost);
		}

		protected override string GetResource()
		{
			return "People/Search";
		}
	}
}
