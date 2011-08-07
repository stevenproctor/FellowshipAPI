using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FellowshipLib
{
	public class People : List<Person>
	{
	}

	public class PersonSearchResults : List<Person>
	{
		public int PageNumber { get; set; }
		public int TotalRecords { get; set; }
		public int AdditionalPages { get; set; }
		public int TotalPages() { return PageNumber + AdditionalPages; }
		public string SearchName { get; set; }
	}

	public class Person
	{
		public string Id { get; set; }
		public string Prefix { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string Suffix { get; set; }
		public string GoesBy { get; set; }
		public string Gender { get; set; }
		public string DateOfBirth { get; set; }
		public string Employer { get; set; }
		public string HouseholdID { get; set; }
		public Occupation Occupation { get; set; }
		public string CreatedDate { get; set; }
		public string LastUpdatedDate { get; set; }
	}
}
