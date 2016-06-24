using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orders.Models;

namespace Orders.Controllers
{
    public class OrdersController : Controller
    {
        private ReportEntities db = new ReportEntities();

        //
        // GET: /Orders/

        public ActionResult Index()
        {
            var order = db.Order.Include(o => o.Accounting).Include(o => o.Clients).Include(o => o.Dispatch).Include(o => o.Divisions).Include(o => o.JobStatus).Include(o => o.PMS).Include(o => o.Priority).Include(o => o.Requests).Include(o => o.Technician);
            return View(order.ToList());
        }

        //
        // GET: /Orders/Details/5

        public ActionResult Details(int id = 0)
        {
            Order order = db.Order.Find(id);
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
            return View();
        }

        //
        // POST: /Orders/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                db.Order.Add(order);
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
        // GET: /Orders/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Order order = db.Order.Find(id);
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
        public ActionResult Edit(Order order)
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
            Order order = db.Order.Find(id);
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
            Order order = db.Order.Find(id);
            db.Order.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}