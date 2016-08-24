using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Netwerk.Models;
using PagedList;


namespace Netwerk.Controllers
{
    public class MocsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Mocs
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
            {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
                {
                page = 1;
                }
            else
                {
                searchString = currentFilter;
                }

            ViewBag.CurrentFilter = searchString;

            var patients = from p in db.Patients select p;


            if (!String.IsNullOrEmpty(searchString))
                {
                patients = patients.Where(p => p.MocTypeId.ToString().Contains(searchString));
                }

            switch (sortOrder)
                {
                case "name_desc":
                    patients = patients.OrderByDescending(p => p.Id);
                    break;
                case "Date":
                    patients = patients.OrderBy(p => p.Id);
                    break;
                case "date_desc":
                    patients = patients.OrderByDescending(p => p.Id);
                    break;
                default:
                    patients = patients.OrderBy(p => p.Id);
                    break;
                }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            ViewBag.IntakeCenterId = new SelectList(db.IntakeCenters, "IntakeCenterId", "IntakeCenterName");
            ViewBag.NwId = patients.ToString();
            return View(patients.ToPagedList(pageNumber, pageSize));
            }

        // GET: Mocs/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moc moc = db.Mocs.Find(id);
            if (moc == null)
            {
                return HttpNotFound();
            }
            return View(moc);
        }

        // GET: Mocs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mocs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MocDate,MocTypeId," +
                                                   "CtId,CnId,CmId,PtId,PnId,PmId,FsValue,PtValue,HsValue," +
                                                   "TreatmentDecision,TherapyDone,MedicalHistory,OncologyHistory," +
                                                   "CurrentMedicalDiagnose,MbvValue,MbvDate,MbvConclusion")] Moc moc)
        {
            if (ModelState.IsValid)
            {
                db.Mocs.Add(moc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(moc);
        }

        // GET: Mocs/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moc moc = db.Mocs.Find(id);
            if (moc == null)
            {
                return HttpNotFound();
            }
            return View(moc);
        }

        // POST: Mocs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MocDate,MocTypeId,NetwerkId,FirstName,LastName,BirthDate,CtId,CnId,CmId,PtId,PnId,PmId,FsValue,PtValue,HsValue,TreatmentDecision,TherapyDone,MedicalHistory,OncologyHistory,CurrentMedicalDiagnose,MbvValue,MbvDate,MbvConclusion")] Moc moc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(moc);
        }

        // GET: Mocs/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moc moc = db.Mocs.Find(id);
            if (moc == null)
            {
                return HttpNotFound();
            }
            return View(moc);
        }

        // POST: Mocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Moc moc = db.Mocs.Find(id);
            db.Mocs.Remove(moc);
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
