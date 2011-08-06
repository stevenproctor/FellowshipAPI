using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FellowshipLib;

namespace FellowshipWeb.Controllers
{
    public class PeopleController : Controller
    {
        //
        // GET: /People/

        public ActionResult Search(string name)
        {
			var query = new PersonQuery().WithNameOf(name);
			query.Search();
			var results = query.Results();
            return View(results);
        }

    }
}
