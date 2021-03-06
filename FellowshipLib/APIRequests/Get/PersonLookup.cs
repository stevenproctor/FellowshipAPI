﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;

namespace FellowshipLib
{
	public class PersonLookup : GetRequest<Person>
	{
		private const string IdParameterName = "Id";
		private const string Resource = "People/{" + IdParameterName + "}";
		private string personId;

		public PersonLookup(string personId)
		{
			this.personId = personId;
		}

		protected override void AddParameters(RestRequest request)
		{
			request.AddParameter(IdParameterName, personId, ParameterType.UrlSegment);
		}

		protected override string GetResource()
		{
			return Resource;
		}
	}
}
