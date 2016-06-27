using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace Orders.Controllers
{
    public class RequestsController : Controller
    {
        //
        // GET: /Requests/

        public ActionResult Index()
        {
            return View();
        }


        Orders.Models.ReportEntities db = new Orders.Models.ReportEntities();

        [ValidateInput(false)]
        public ActionResult RequestView1Partial()
        {
            var model = db.Requests;
            return PartialView("_RequestView1Partial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult RequestView1PartialAddNew(Orders.Models.Requests item)
        {
            var model = db.Requests;
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
            return PartialView("_RequestView1Partial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult RequestView1PartialUpdate(Orders.Models.Requests item)
        {
            var model = db.Requests;
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
            return PartialView("_RequestView1Partial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult RequestView1PartialDelete(System.Int32 id)
        {
            var model = db.Requests;
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
            return PartialView("_RequestView1Partial", model.ToList());
        }
    }
}
