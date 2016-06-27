using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace Orders.Controllers
{
    public class MaterialsController : Controller
    {
        //
        // GET: /Materials/

        public ActionResult Index()
        {
            return View();
        }




        Orders.Models.ReportEntities db = new Orders.Models.ReportEntities();

        [ValidateInput(false)]
        public ActionResult MaterialsViewPartial()
        {
            var model = db.Material;
            return PartialView("_MaterialsViewPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult MaterialsViewPartialAddNew(Orders.Models.Material item)
        {
            var model = db.Material;
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
            return PartialView("_MaterialsViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MaterialsViewPartialUpdate(Orders.Models.Material item)
        {
            var model = db.Material;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.Material_id == item.Material_id);
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
            return PartialView("_MaterialsViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MaterialsViewPartialDelete(System.Int32 id)
        {
            var model = db.Material;
            if (id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.Material_id == id);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_MaterialsViewPartial", model.ToList());
        }
    }
}
