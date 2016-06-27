using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using Orders.Models;

namespace Orders.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            
            return View();    
        }



        Orders.Models.ReportEntities db = new Orders.Models.ReportEntities();

        [ValidateInput(false)]
        public ActionResult OrderViewPartial()
        {
            var model = db.WorkOrder;
            return PartialView("_OrderViewPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult OrderViewPartialAddNew(WorkOrder item)
        {
            var model = db.WorkOrder;
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
            return PartialView("_OrderViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult OrderViewPartialUpdate(WorkOrder item)
        {
            var model = db.WorkOrder;
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
            return PartialView("_OrderViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult OrderViewPartialDelete(System.Int32 id)
        {
            var model = db.WorkOrder;
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
            return PartialView("_OrderViewPartial", model.ToList());
        }
    }
}