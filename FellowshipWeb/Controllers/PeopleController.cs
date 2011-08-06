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

        public ActionResult Search(string name)
		{
			ViewBag.SearchCriteria = name.SafeTrim();
			var query = new PersonQuery().WithNameOf(name);
			query.Search();
			var results = query.Results();
            return View(results);
        }

    }
}
