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

			var getRequest = new PersonSearch(name).AtPage(pageNumber);
			return GetActionResult(getRequest);
		}

		public ActionResult Details(string id)
		{
			var getRequest = new PersonLookup(id);
			return GetActionResult(getRequest);
		}

		public ActionResult Addresses(string id)
		{
			var getRequest = new AddressLookupByPerson(id);
			return GetActionResult(getRequest);
		}

		private ActionResult GetActionResult<T>(GetRequest<T> getRequest) where T : new()
		{
			getRequest.Find();

			if (!getRequest.Succeeded())
			{
				ModelState.AddModelError("error", getRequest.GetMessages());
				return View();
			}

			return View(getRequest.Result());

		}
	}
}
