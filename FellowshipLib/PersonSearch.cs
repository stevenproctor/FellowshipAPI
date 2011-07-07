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

	public class PersonSearch : GetRequest<PersonSearchResults>
	{
		private const int MinimumNameParameterLength = 2;

		private string searchName = string.Empty;
		private int pageNumber;
		private string specifiedName;

		public PersonSearch(string name)
		{
			specifiedName = name;
			this.searchName = SanitizeName(specifiedName);
		}

		private static string SanitizeName(string name)
		{
			if (name == null)
				name = string.Empty;

			return name.PadLeft(MinimumNameParameterLength, '%');
		}

		public override void Find()
		{
			base.Find();

			if (Succeeded())
			{
				Result().SearchName = specifiedName;
			}
		}

		protected override void AddParameters(RestRequest request)
		{
			request.AddParameter("searchFor", searchName, ParameterType.GetOrPost);
			if (pageNumber > 0)
				request.AddParameter("page", pageNumber, ParameterType.GetOrPost);

		}

		protected override string GetResource()
		{
			return "People/Search";
		}

		public PersonSearch AtPage(int pageNumber)
		{
			this.pageNumber = pageNumber;
			return this;
		}
	}
}
