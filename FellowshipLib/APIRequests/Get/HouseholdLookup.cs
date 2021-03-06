﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;

namespace FellowshipLib
{
	public class HouseholdLookup : GetRequest<People>
	{
		private const string HouseholdIdParameter = "HouseholdId";
		private const string Resource = "households/{" + HouseholdIdParameter + "}/people";

		private string householdId;

		public HouseholdLookup(string householdId)
		{
			this.householdId = householdId;
		}

		protected override void AddParameters(RestRequest request)
		{
			request.AddParameter(HouseholdIdParameter, householdId, ParameterType.UrlSegment);
		}

		protected override string GetResource()
		{
			return Resource;
		}
	}
}
