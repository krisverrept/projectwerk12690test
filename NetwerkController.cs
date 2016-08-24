using System.Linq;
using System.Threading;
using System.Web.Mvc;
using Netwerk.Models;

namespace Netwerk.Controllers
    {
    public class NetwerkController : Controller
    {
        // GET: Netwerk
        public ActionResult Admin()
        {
            ViewBag.Message = "Administratie";
            return View();
        }
        public ActionResult Vragen()
            {
            ViewBag.Message = "Veelgestelde vragen.";
            return View();
            }
        public ActionResult Documentatie()
            {
            ViewBag.Message = "Documentatie.";
            return View();
            }

        public ActionResult Overzicht()
            {
            ViewBag.Message = "Overzicht.";
            using (var context = new ApplicationDbContext())
                {
                ViewBag.TotPatients = context.Patients.SqlQuery(" SELECT * FROM dbo.Patients").Count();
                ViewBag.TotPartners = context.IntakeCenters.SqlQuery(" SELECT * FROM dbo.IntakeCenters").Count();
                }

            return View();
            }

        public ActionResult OverOns()
            {
            ViewBag.Message = "Over ons.";
            return View();
            }
        public ActionResult Partners()
            {
            ViewBag.Message = "Meewerkende ziekenhuizen.";
            return View();
            }
         public ActionResult Richtlijnen()
            {
            ViewBag.Message = "Richtlijnen.";
            return View();
            }

        }
}