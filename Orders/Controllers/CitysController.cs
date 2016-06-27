using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace Orders.Controllers
{
    public class CitysController : Controller
    {
        //
        // GET: /Citys/

        public ActionResult Index()
        {
            return View();
        }


        Orders.Models.ReportEntities db = new Orders.Models.ReportEntities();

        [ValidateInput(false)]
        public ActionResult CitysViewPartial()
        {
            var model = db.Citys;
            return PartialView("_CitysViewPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CitysViewPartialAddNew(Orders.Models.Citys item)
        {
            var model = db.Citys;
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
            return PartialView("_CitysViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CitysViewPartialUpdate(Orders.Models.Citys item)
        {
            var model = db.Citys;
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
            return PartialView("_CitysViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CitysViewPartialDelete(System.Int32 id)
        {
            var model = db.Citys;
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
            return PartialView("_CitysViewPartial", model.ToList());
        }
    }
}
