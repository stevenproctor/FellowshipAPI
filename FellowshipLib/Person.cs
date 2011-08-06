using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FellowshipLib
{
	public class People : List<Person>
	{
		public int PageNumber { get; set; }
		public int TotalRecords { get; set; }
		public int AdditionalPages { get; set; }
		public int TotalPages() { return PageNumber + AdditionalPages;  }
	}

	public class Person
	{
		public string Id { get; set; }
		public string Prefix { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string HouseholdId { get; set; }
	}
}
