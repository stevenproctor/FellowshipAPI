using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FellowshipLib;
using FellowshipLib.Extensions;

namespace FellowshipWeb.Controllers
{
	public class PeopleController : Controller
	{
		//
		// GET: /People/

		public ActionResult Search(string name, int pageNumber = 1, int maxPageNumber = -1)
		{
			if (maxPageNumber != -1 && pageNumber > maxPageNumber)
				pageNumber = maxPageNumber;

			var query = new PersonSearch(name).AtPage(pageNumber);
			query.Search();
			var results = query.Results();
			return View(results);
		}

		public ActionResult Details(string personId)
		{
			Person p = new Person { Id = personId, FirstName = "john", LastName = "test", MiddleName = "Q", Prefix = "Mr", HouseholdId = "1234" };
			return View(p);
		}
	}
}
