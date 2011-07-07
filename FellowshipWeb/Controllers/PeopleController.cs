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
			var results = query.Result();
			return View(results);
		}

		public ActionResult Details(string id)
		{
			var lookup = new PersonLookup(id);
			lookup.FindPerson();
			Person p = lookup.Result();
			return View(p);
		}

		public ActionResult Addresses(string id)
		{
			var lookup = new AddressLookupByPerson(id);
			lookup.Find();
			var addresses = lookup.Result();
			return View(addresses);
		}
	}
}
