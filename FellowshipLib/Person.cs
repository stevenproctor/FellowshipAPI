﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FellowshipLib
{
	public class People : List<person>
	{
		public int PageNumber { get; set; }
		public int TotalRecords { get; set; }
		public int AdditionalPages { get; set; }
	}

	public class person
	{
		public string Id { get; set; }
		public string Prefix { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}
