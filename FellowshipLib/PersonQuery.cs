﻿using System;
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

	public class PersonQuery : GetRequest<PeopleSearchResults>
	{
		private const int MinimumNameParameterLength = 2;

		private string searchName = string.Empty;
		private int pageNumber;
		private string specifiedName;

		public PersonQuery(string name)
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

		public void Search()
		{
			Get();
			Results().SearchName = specifiedName;
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

		public PersonQuery AtPage(int pageNumber)
		{
			this.pageNumber = pageNumber;
			return this;
		}
	}
}
