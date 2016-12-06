using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace soruSor.servis.Controllers
{
    public class KullaniciController:Controller

    {
        soruSorEntities db = new soruSorEntities();
        [HttpPost]
        public JsonResult Giris(string id,string sifre)
        {
            var kullanici = db.kullanici.Where(a => a.kullaniciAd == id && a.kullaniciSifre == sifre).FirstOrDefault();
            if(kullanici==null)
            {
                return Json("Kullanici Adı veya Sifre Hatalı");
            }
            else
            {
                Session["kullaniciId"] = kullanici.kullaniciId;
                Session["Ad"] = kullanici.Ad;
                Session["Soyad"] = kullanici.Soyad;
                return Json(true);
            }
        }
        [HttpPost]
        public JsonResult Kaydol(string kullaniciAd, string kullaniciSifre,string isim,string soyisim)
        {
            try
            {
                soruSor.servis.kullanici kullanici = new kullanici();
                kullanici.Ad = isim;
                kullanici.Soyad = soyisim;

                kullanici.kullaniciAd = kullaniciAd;
                kullanici.kullaniciSifre = kullaniciSifre;

                db.kullanici.Add(kullanici);
                db.SaveChanges();
                return Json(true);

            }
            catch (Exception)
            {
                return Json("Hata");
            }
        }
    }

}