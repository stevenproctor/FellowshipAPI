using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FellowshipLib;

namespace FellowshipWeb.Controllers
{
	public class HouseholdController : Controller
	{
		public ActionResult Details(string id)
		{
			var lookup = new HouseholdLookup(id);
			lookup.Find();
			var household = lookup.Result();
			return View(household);
		}

	}
}
