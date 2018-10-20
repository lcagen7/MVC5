using MVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5.Controllers
{
    [RoutePrefix("AS")]
    public class ActionSelectorsController : Controller
    {
        private List<ASelector> ASelectorList = new List<ASelector>()
        {
            new ASelector() {ID=1, Name="One"},
            new ASelector() {ID=2, Name="Two"}
        };

        [Route("GetMessage1")]
        public string GetMessage1()
        {
            return "This is message 1";
        }

        [NonAction]
        public string GetMessage2()
        {
            return "This is message 2";
        }

        // GET: ActionSelectors
        public ActionResult Index()
        {
            return View(ASelectorList);
        }

        // GET: Details/5
        public ActionResult Details(int id)
        {
            return View(ASelectorList[0]);
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Edit/5
        [HttpGet]
        [Route("Get/{id}")]
        public ActionResult Edit(int id)
        {
            return View(ASelectorList[0]);
        }

        // POST: Edit/5
        [HttpPost]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Delete/5
        public ActionResult Delete(int id)
        {
            return View(ASelectorList[0]);
        }

        // POST: Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [ActionName("AS_About")]
        [Route("AS_About")]
        public ActionResult About()
        {
            //Have to specify the name or otherwise view engine will search for AS_About.
            return View("About");
        }

        [Route("AS_About_2")]
        public ActionResult About2()
        {
            //Have to specify the name or otherwise view engine will search for AS_About.
            return View("About");
        }
    }
}
