using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5.Controllers
{
    public class ActionResultsController : Controller
    {
        // GET: ActionResults
        public ViewResult Index()
        {
            ViewBag.message = "This is Action Result ViewResult";
            return View();
        }

        public PartialViewResult Partial()
        {
            ViewBag.message = "This is Action Result Partial";
            if(TempData["message"] != null)
            {
                ViewBag.message = TempData["message"].ToString();
            }
            return PartialView("Index");
        }

        public RedirectResult RedirectResult()
        {
            TempData["message"] = "This is Redirect result.";
            return Redirect("PartialIndex");
        }

        public RedirectToRouteResult RedirectToRoute()
        {
            TempData["message"] = "This is Redirect to route result.";
            return RedirectToAction("PartialIndex");
        }

        public JsonResult JsonResult()
        {
            TempData["message"] = "This is Redirect to route result.";
            return Json(new { id=1, name="One"}, JsonRequestBehavior.AllowGet);
        }
    }
}