using System.Linq;
using System.Web.Mvc;
using ProjeAdi.Models;

namespace ProjeAdi.Controllers
{
    public class MuzikController : Controller
    {
        MuzikContext db = new MuzikContext();

        // Formu gösteren sayfa
        public ActionResult Index()
        {
            return View();

        }

        public ActionResult Liste()
        {
            var muzikler = db.Muzikler.ToList();
            return View(muzikler);
        }

        public ActionResult Duzenle(int id)
        {
            var muzik = db.Muzikler.Find(id);
            if (muzik == null)
            {
                return HttpNotFound();
            }
            return View(muzik);
        }

        // POST: /Muzik/Duzenle/5
        [HttpPost]
        public ActionResult Duzenle(Muzik muzik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(muzik).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Liste");
            }
            return View(muzik);
        }

        [HttpPost]
        public ActionResult Sil(int id)
        {
            var muzik = db.Muzikler.Find(id);
            if (muzik == null)
            {
                return HttpNotFound();
            }

            db.Muzikler.Remove(muzik);
            db.SaveChanges();

            return Json(new { success = true });
        }




        // AJAX ile formdan gelen veriyi kaydeden metod
        [HttpPost]
        public JsonResult MuzikEkle(Muzik muzik)
        {
            if (ModelState.IsValid)
            {
                db.Muzikler.Add(muzik);
                db.SaveChanges();

                return Json(new
                {
                    success = true,
                    mesaj = $"{muzik.SarkiIsmi} başarıyla eklendi!"
                });
            }

            return Json(new
            {
                success = false,
                mesaj = "Hata: Girdiğiniz verileri kontrol edin."
            });
        }
    }
}