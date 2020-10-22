using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TAIClientSearch.Models;

namespace TAIClientSearch.Controllers
{
    public class ClientsController : Controller
    {
        private ClientDBContext db = new ClientDBContext();

        // GET: Clients
        public ActionResult Index(string gender, string searchString, string dateString, string state, string face, string firstString, string policyString, string sortOrder)
        {
            // DropDownList data for Gender
            // Returns 'M' or 'F'
            var GenderLst = new List<string>();

            var GenderQry = from d in db.Clients
                            orderby d.Gender
                            select d.Gender;

            GenderLst.AddRange(GenderQry.Distinct());
            ViewBag.gender = new SelectList(GenderLst);

            // DropDownList data for State
            // Returns state list based on database data via ViewBag
            var StateLst = new List<string>();

            var StateQry = from d in db.Clients
                           orderby d.IssueState
                           select d.IssueState;

            StateLst.AddRange(StateQry.Distinct());
            ViewBag.state = new SelectList(StateLst);

            // DropDownList data for Face Amount
            // Returns face amount list based on database data via ViewBag
            var FaceLst = new List<string>();

            var FaceQry = from d in db.Clients
                          orderby d.FaceAmount
                          select d.FaceAmount;

            FaceLst.AddRange(FaceQry.Distinct());
            ViewBag.face = new SelectList(FaceLst);




            // Search criteria for textbox controls LastName, FirstName, PolicyNumber
            var search = from m in db.Clients
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                search = search.Where(s => s.LastName.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(firstString))
            {
                search = search.Where(s => s.FirstName.Contains(firstString));
            }

            if (!String.IsNullOrEmpty(policyString))
            {
                search = search.Where(s => s.PolicyNumber.Contains(policyString));
            }

            // Search criteria for dropdownlist control for Face Amount
            if (!String.IsNullOrEmpty(face))
            {
                search = search.Where(s => s.FaceAmount.Contains(face));
            }




            // If dropdownlist for Gender and State return null, then lists all available queries
            if (!String.IsNullOrEmpty(gender))
            {
                search = search.Where(x => x.Gender.Contains(gender));
            }

            if (!String.IsNullOrEmpty(state))
            {
                search = search.Where(x => x.IssueState.Contains(state));
            }


            return View(search);

        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,LastName,FirstName,Gender,DateOfBirth,Company,PolicyNumber,IssueState,FaceAmount")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LastName,FirstName,Gender,DateOfBirth,Company,PolicyNumber,IssueState,FaceAmount")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
