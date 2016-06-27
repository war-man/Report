using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace Orders.Controllers
{
    public class JobStatusController : Controller
    {
        //
        // GET: /JobStatus/

        public ActionResult Index()
        {
            return View();
        }


        Orders.Models.ReportEntities db = new Orders.Models.ReportEntities();

        [ValidateInput(false)]
        public ActionResult JobStatusViewPartial()
        {
            var model = db.JobStatus;
            return PartialView("_JobStatusViewPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult JobStatusViewPartialAddNew(Orders.Models.JobStatus item)
        {
            var model = db.JobStatus;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_JobStatusViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult JobStatusViewPartialUpdate(Orders.Models.JobStatus item)
        {
            var model = db.JobStatus;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_JobStatusViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult JobStatusViewPartialDelete(System.Int32 id)
        {
            var model = db.JobStatus;
            if (id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_JobStatusViewPartial", model.ToList());
        }
    }
}
