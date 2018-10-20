using MVC5.Models;
using MVC5.Services;
using System;
using System.Web.Mvc;

namespace MVC5.Controllers
{
    public class AssessmentController : Controller
    {
        [HttpGet, ActionName("Index")]
        public ActionResult GetAllAssessments()
        {
            DataAccess dataAccess = new DataAccess();
            return View(dataAccess.GetAllAssessments());
        }

        [HttpGet, ActionName("Details")]
        public ActionResult GetDetailsById(Int32 id)
        {
            DataAccess dataAccess = new DataAccess();
            return View(dataAccess.GetDetailsById(id));
        }

        [HttpGet, ActionName("Edit")]
        public ActionResult EditAssessmentById(Int32 id)
        {
            DataAccess dataAccess = new DataAccess();
            return View(dataAccess.GetDetailsById(id));
        }

        [HttpPost, ActionName("Edit")]
        public ActionResult EditAssessmentById(Assessment assessment)
        {
            DataAccess dataAccess = new DataAccess();
            dataAccess.EditDetailsById(assessment);
            return RedirectToAction("Index");
        }

        [HttpGet, ActionName("Create")]
        public ActionResult CreateAssessment()
        {
            return View();
        }

        [HttpPost, ActionName("Create")]
        public ActionResult CreateAssessment(Assessment assessment)
        {
            DataAccess dataAccess = new DataAccess();
            dataAccess.CreateAssessment(assessment);
            return RedirectToAction("Index");
        }

        [HttpGet, ActionName("Delete")]
        public ActionResult DeleteAssessment(Int32 id)
        {
            DataAccess dataAccess = new DataAccess();
            dataAccess.DeleteAssessment(id);
            return RedirectToAction("Index");
        }
    }
}