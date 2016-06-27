using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orders.Models;
using DevExpress.Web.Mvc;


namespace Orders.Controllers
{
    public class OrdersController : Controller
    {
        private ReportEntities db = new ReportEntities();

        //
        // GET: /Orders/

        public ActionResult Index()
        {
            var order = db.WorkOrder.Include(o => o.Accounting).Include(o => o.Clients).Include(o => o.Dispatch).Include(o => o.Divisions).Include(o => o.JobStatus).Include(o => o.PMS).Include(o => o.Priority).Include(o => o.Requests).Include(o => o.Technician).Include(o => o.Citys);
            return View(order.ToList());
        }

        //
        // GET: /Orders/Details/5

        public ActionResult Details(int id = 0)
        {
            WorkOrder order = db.WorkOrder.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        //
        // GET: /Orders/Create

        public ActionResult Create()
        {
            ViewBag.accountingId = new SelectList(db.Accounting, "id", "inv");
            ViewBag.clientId = new SelectList(db.Clients, "id", "name");
            ViewBag.dispatchId = new SelectList(db.Dispatch, "id", "vendor");
            ViewBag.divisionId = new SelectList(db.Divisions, "id", "name");
            ViewBag.jobstatusId = new SelectList(db.JobStatus, "id", "name");
            ViewBag.pmsId = new SelectList(db.PMS, "id", "ecoDispatch");
            ViewBag.priorityId = new SelectList(db.Priority, "id", "name");
            ViewBag.requestId = new SelectList(db.Requests, "id", "name");
            ViewBag.technicianId = new SelectList(db.Technician, "id", "notesFromTech");
            ViewBag.cityId = new SelectList(db.Citys, "id", "name");
            ViewBag.materials = new SelectList(db.Material, "id", "name");
            return View();
        }

        //
        // POST: /Orders/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkOrder order)
        {
            if (ModelState.IsValid)
            {
                db.WorkOrder.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.accountingId = new SelectList(db.Accounting, "id", "inv", order.accountingId);
            ViewBag.clientId = new SelectList(db.Clients, "id", "name", order.clientId);
            ViewBag.dispatchId = new SelectList(db.Dispatch, "id", "vendor", order.dispatchId);
            ViewBag.divisionId = new SelectList(db.Divisions, "id", "name", order.divisionId);
            ViewBag.jobstatusId = new SelectList(db.JobStatus, "id", "name", order.jobstatusId);
            ViewBag.pmsId = new SelectList(db.PMS, "id", "ecoDispatch", order.pmsId);
            ViewBag.priorityId = new SelectList(db.Priority, "id", "name", order.priorityId);
            ViewBag.requestId = new SelectList(db.Requests, "id", "name", order.requestId);
            ViewBag.technicianId = new SelectList(db.Technician, "id", "notesFromTech", order.technicianId);
            ViewBag.cityId = new SelectList(db.Citys, "id", "name");
            ViewBag.materials = new SelectList(db.Material, "id", "name");
            return View(order);
        }

        //
        // GET: /Orders/Edit/5

        public ActionResult Edit(int id = 0)
        {
            WorkOrder order = db.WorkOrder.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.accountingId = new SelectList(db.Accounting, "id", "inv", order.accountingId);
            ViewBag.clientId = new SelectList(db.Clients, "id", "name", order.clientId);
            ViewBag.dispatchId = new SelectList(db.Dispatch, "id", "vendor", order.dispatchId);
            ViewBag.divisionId = new SelectList(db.Divisions, "id", "name", order.divisionId);
            ViewBag.jobstatusId = new SelectList(db.JobStatus, "id", "name", order.jobstatusId);
            ViewBag.pmsId = new SelectList(db.PMS, "id", "ecoDispatch", order.pmsId);
            ViewBag.priorityId = new SelectList(db.Priority, "id", "name", order.priorityId);
            ViewBag.requestId = new SelectList(db.Requests, "id", "name", order.requestId);
            ViewBag.technicianId = new SelectList(db.Technician, "id", "notesFromTech", order.technicianId);
            return View(order);
        }

        //
        // POST: /Orders/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WorkOrder order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.accountingId = new SelectList(db.Accounting, "id", "inv", order.accountingId);
            ViewBag.clientId = new SelectList(db.Clients, "id", "name", order.clientId);
            ViewBag.dispatchId = new SelectList(db.Dispatch, "id", "vendor", order.dispatchId);
            ViewBag.divisionId = new SelectList(db.Divisions, "id", "name", order.divisionId);
            ViewBag.jobstatusId = new SelectList(db.JobStatus, "id", "name", order.jobstatusId);
            ViewBag.pmsId = new SelectList(db.PMS, "id", "ecoDispatch", order.pmsId);
            ViewBag.priorityId = new SelectList(db.Priority, "id", "name", order.priorityId);
            ViewBag.requestId = new SelectList(db.Requests, "id", "name", order.requestId);
            ViewBag.technicianId = new SelectList(db.Technician, "id", "notesFromTech", order.technicianId);

            return View(order);
        }

        //
        // GET: /Orders/Delete/5

        public ActionResult Delete(int id = 0)
        {
            WorkOrder order = db.WorkOrder.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        //
        // POST: /Orders/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkOrder order = db.WorkOrder.Find(id);
            db.WorkOrder.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }










        Orders.Models.ReportEntities db1 = new Orders.Models.ReportEntities();

        [ValidateInput(false)]
        public ActionResult OrderMaterialsViewPartial()
        {
            var model = db1.OrderMaterials;
            return PartialView("_OrderMaterialsViewPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult OrderMaterialsViewPartialAddNew(Orders.Models.OrderMaterials item)
        {
            var model = db1.OrderMaterials;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db1.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_OrderMaterialsViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult OrderMaterialsViewPartialUpdate(Orders.Models.OrderMaterials item)
        {
            var model = db1.OrderMaterials;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db1.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_OrderMaterialsViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult OrderMaterialsViewPartialDelete(System.Int32 id)
        {
            var model = db1.OrderMaterials;
            if (id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                        model.Remove(item);
                    db1.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_OrderMaterialsViewPartial", model.ToList());
        }
    }
}