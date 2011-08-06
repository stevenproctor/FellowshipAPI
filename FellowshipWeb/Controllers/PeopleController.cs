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

			ViewBag.SearchCriteria = name.SafeTrim();
			var query = new PersonQuery(name).AtPage(pageNumber);
			query.Search();
			var results = query.Results();
            return View(results);
        }
    }
}
