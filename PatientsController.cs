using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Netwerk.Models;
using PagedList;

namespace Netwerk.Controllers
    {
    public class PatientsController : Controller
        {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Patients
        public ActionResult IndexPatients(string sortOrder, string currentFilter, string searchString, int? page)
            {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "BirthDate" ? "date_desc" : "Date";

            var patients = from p in db.Patients select p;
            
            if (searchString != null)
                {
                page = 1;
                }
            else
                {
                searchString = currentFilter;
                }

            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
                {
                patients = patients.Where(p => p.LastName.Contains(searchString));
                }

            switch (sortOrder)
                {
                case "name_desc":
                    patients = patients.OrderByDescending(p => p.LastName);
                    break;
                case "Date":
                    patients = patients.OrderBy(p => p.BirthDate);
                    break;
                case "date_desc":
                    patients = patients.OrderByDescending(p => p.BirthDate);
                    break;
                default:
                    patients = patients.OrderByDescending(p => p.NetwerkId);
                    break;
                }
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            //var ic = (from it in db.IntakeCenters
            //    join pt in db.Patients 
            //    on it.IntakeCenterId equals pt.IntakeCenterId
            //    select new { IntakeCenterSelect = it.IntakeCenterName});
           

           
            return View(patients.ToPagedList(pageNumber, pageSize));
           
            }
       

        // GET: Mocs
        public ActionResult IndexMocs(string sortOrder, string currentFilter, string searchString, int? page)
            {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "BirthDate" ? "date_desc" : "Date";

            var patients = from p in db.Patients select p; 
            
            if (searchString != null)
                {
                page = 1;
                }
            else
                {
                searchString = currentFilter;
                }

            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
                {
                patients = patients.Where(p => p.LastName.Contains(searchString));
                }

            switch (sortOrder)
                {
                case "name_desc":
                    patients = patients.OrderByDescending(p => p.LastName);
                    break;
                case "Date":
                    patients = patients.OrderBy(p => p.BirthDate);
                    break;
                case "date_desc":
                    patients = patients.OrderByDescending(p => p.BirthDate);
                    break;
                default:
                    patients = patients.OrderByDescending(p => p.NetwerkId);
                    break;
                }
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            var ic = (from it in db.IntakeCenters
                      join pt in db.Patients
                      on it.IntakeCenterId equals pt.IntakeCenterId
                      select new { IntakeCenterSelect = it.IntakeCenterName });
            foreach (var group in ic)
                {
                ViewBag.Intake = group.IntakeCenterSelect;

                }
           
            //ViewBag.Intake = ic.FirstOrDefault();

            //var q = (from it in db.IntakeCenters.Include(it => it.IntakeCenterName)
            //         join pt in db.Patients on it.IntakeCenterId equals pt.IntakeCenterId
            //         select new { a = it.IntakeCenterName }).ToString().ToList();

            return View(patients.ToPagedList(pageNumber, pageSize));
            //return View(viewModel);
            }

        

        // GET: Patients/Details/5
        public ActionResult Details(int? id)
            {
            if (id == null)
                {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
                {
                return HttpNotFound();
                }
            return View(patient);
            }

        // GET: Patients/Create
        // [Authorize(Roles ="canEdit")]
        public ActionResult CreatePatients(FormCollection form)
        {
            
            ViewBag.IntakeCenterId = new SelectList(db.IntakeCenters, "IntakeCenterId", "IntakeCenterName");
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "GenderName");
            ViewBag.Country = new SelectList(db.Countries, "Id", "CountryName");

            return View();
            }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // [Authorize(Roles = "canEdit")]
        public ActionResult CreatePatients([Bind(Include = "NetwerkId,NationalNumber,FirstName,LastName," +
                                                   "Address,PostCode,City,Country," +
                                                   "GenderId,BirthDate,MortalDate,PatientPhone,PatientMail," +
                                                   "HomeDoctor,ContactHomeDoctor," +
                                                   "IntakeCenterId,IntakeNumber,IntakeDoctor," +
                                                   "IntakeDoctorMail")] Patient patient, FormCollection form)
            {
            try
                {
                if (ModelState.IsValid)
                    {
                    db.Patients.Add(patient);
                    db.SaveChanges();
                    return RedirectToAction("IndexPatients");
                    }
                }
            catch (DataException /* dex */)
                {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Fout bij opslaan, probeer opnieuw.");
                }
            ViewBag.IntakeCenterId = new SelectList(db.IntakeCenters, "IntakeCenterId", "IntakeCenterName");
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "GenderName");
            ViewBag.Country = new SelectList(db.Countries, "Id", "CountryName");
            return View(patient);
            }




        // GET: Mocs/Create
        // [Authorize(Roles ="canEdit")]
        public ActionResult CreateMocs(FormCollection form, int? id)
            {
            ViewBag.IntakeDoctor = new SelectList(db.IntakeDoctors, "IntakeDoctorId", "IntakeDoctorName");
            ViewBag.NetworkDoctor = new SelectList(db.NetworkDoctors, "NetworkDoctorId", "NetworkDoctorName");
            return View();
            }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // [Authorize(Roles = "canEdit")]
        public ActionResult CreateMocs([Bind(Include = "NetwerkId,MocDate,MocType,CtId,CnId,CmId" +
                                                   "PtId,PnId,PmId,FsValue,PtValue,HsValue" +
                                                   "TreatmentDecision,TherapyDone,MedicalHistory,OncologyHistory" +
                                                   "CurrentMedicalDiagnose, MbvValue, MbvDate," +
                                                       " MbvConclusion")] Patient patient, FormCollection form)
            {
            try
                {
                if (ModelState.IsValid)
                    {
                    db.Patients.Add(patient);
                    db.SaveChanges();
                    return RedirectToAction("IndexPatients");
                    }
                }
            catch (DataException /* dex */)
                {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Fout bij opslaan, probeer opnieuw.");
                }
            ViewBag.IntakeCenterId = new SelectList(db.IntakeCenters, "IntakeCenterId", "IntakeCenterName");
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "GenderName");
            ViewBag.Country = new SelectList(db.Countries, "Id", "CountryName");
            ViewBag.IntakeDoctor = new SelectList(db.IntakeDoctors, "IntakeDoctorId", "IntakeDoctorName");
            ViewBag.NetworkDoctor = new SelectList(db.NetworkDoctors, "NetworkDoctorId", "NetworkDoctorName");
            return View(patient);
            }













        // GET: Patients/Edit/5
        //[Authorize(Roles = "canEdit")]
        public ActionResult EditPatients(int? id)
            {
            if (id == null)
                {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
                {
                return HttpNotFound();
                }
            ViewBag.IntakeCenterId = new SelectList(db.IntakeCenters, "IntakeCenterId", "IntakeCenterName", patient.IntakeCenterId);
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "GenderName", patient.GenderId);
            ViewBag.Country = new SelectList(db.Countries, "Id", "CountryName", patient.Country);
            return View(patient);
            }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPatients([Bind(Include ="NetwerkId,NationalNumber,FirstName,LastName," +
                                                   "Address,PostCode,City,Country,"+
                                                   "GenderId,BirthDate,MortalDate,PatientPhone,PatientMail," +
                                                   "HomeDoctor,ContactHomeDoctor," +
                                                   "IntakeCenterId,IntakeNumber,IntakeDoctor," +
                                                   "IntakeDoctorMail")] Patient patient, FormCollection form)
            {
            try
                {
                if (ModelState.IsValid)
                    {
                    db.Entry(patient).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("IndexPatients");
                    }
                }
            catch (DataException /* dex */)
                {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Fout bij opslaan, probeer opnieuw.");
                }
            ViewBag.IntakeCenterId = new SelectList(db.IntakeCenters, "IntakeCenterId", "IntakeCenterName", patient.IntakeCenterId);
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "GenderName", patient.GenderId);
            ViewBag.Country = new SelectList(db.Countries, "Id", "CountryName", patient.Country);

            return View(patient);
            }

        // GET: Mocs/Edit/5
        //[Authorize(Roles = "canEdit")]
        public ActionResult EditMocs(int? id)
            {
            if (id == null)
                {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
                {
                return HttpNotFound();
                }
            ViewBag.IntakeCenterId = new SelectList(db.IntakeCenters, "IntakeCenterId", "IntakeCenterName", patient.IntakeCenterId);
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "GenderName", patient.GenderId);
            ViewBag.Country = new SelectList(db.Countries, "Id", "CountryName", patient.Country);
            ViewBag.IntakeDoctor = new SelectList(db.IntakeDoctors, "IntakeDoctorId", "IntakeDoctorName");
            ViewBag.NetworkDoctor = new SelectList(db.NetworkDoctors, "NetworkDoctorId", "NetworkDoctorName");
            ViewBag.TypeMoc = new SelectList(db.MocTypes, "MocTypeid", "MocName");
            ViewBag.ListFS = new SelectList(db.ListFss, "FsId", "FsValue");
            ViewBag.ListHS = new SelectList(db.ListHses, "HsId", "HsValue");
            ViewBag.ListPS = new SelectList(db.ListPss, "PsId", "PsValue");
            ViewBag.ListTnm = new SelectList(db.ListTnms, "TnmId", "TnmValue");
            ViewBag.GradeECOG = new SelectList(db.Ecogs, "EcId", "EcGrade");
            ViewBag.Mbv = new SelectList(db.ListMbvs, "MbvId", "MbvValue");
            return View(patient);
            }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMocs([Bind(Include ="NetwerkId,MocDate,MocType,CtId,CnId,CmId" +
                                                   "PtId,PnId,PmId,FsValue,PtValue,HsValue" +
                                                   "TreatmentDecision,TherapyDone,MedicalHistory,OncologyHistory" +
                                                   "CurrentMedicalDiagnose, MbvValue, MbvDate," +
                                                   " MbvConclusion")] Patient patient, FormCollection form)
            {
            try
                {
                if (ModelState.IsValid)
                    {
                    db.Entry(patient).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("IndexPatients");
                    }
                }
            catch (DataException /* dex */)
                {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Fout bij opslaan, probeer opnieuw.");
                }
            ViewBag.IntakeCenterId = new SelectList(db.IntakeCenters, "IntakeCenterId", "IntakeCenterName", patient.IntakeCenterId);
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "GenderName", patient.GenderId);
            ViewBag.Country = new SelectList(db.Countries, "Id", "CountryName", patient.Country);
            ViewBag.IntakeDoctor = new SelectList(db.IntakeDoctors, "IntakeDoctorId", "IntakeDoctorName");
            ViewBag.NetworkDoctor = new SelectList(db.NetworkDoctors, "NetworkDoctorId", "NetworkDoctorName");
            ViewBag.TypeMoc = new SelectList(db.MocTypes, "MocTypeid", "MocName");
            return View(patient);
            }





















        // GET: Patients/Delete/5
        public ActionResult Delete(int? id)
            {
            if (id == null)
                {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
                {
                return HttpNotFound();
                }
            return View(patient);
            }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
            {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
            db.SaveChanges();
            return RedirectToAction("IndexPatients");
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
