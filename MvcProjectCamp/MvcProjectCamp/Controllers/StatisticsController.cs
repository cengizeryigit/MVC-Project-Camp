using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class StatisticsController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        Context context= new Context();
        
        public ActionResult Index()
        {
            Statistics s = new Statistics();

            s.TotalCategoryCount = cm.GetList().ToList().Count; //Toplam kategori sayısı

            s.SoftwareCategoryCount=context.Headings.Count(x=>x.CategoryID==17); //Başlık tablosunda "yazılım" kategorisine ait başlık sayısı Yazılım==17

            s.WriterCount = context.Writers.Count(x => x.WriterName.ToLower().Contains("a")); //Yazar adında 'a' harfi geçen yazar sayısı

            s.MaximumCategoryCountName =                                                //En fazla başlığa sahip kategori adı
                cm.GetList().Where(b => b.CategoryID == context.Headings.ToList()
                .GroupBy(x => x.CategoryID).ToList().OrderBy(c => c.Count()).Last().Key)
                .FirstOrDefault().CategoryName;

            s.DifCategoryStatus =                                                   //Kategori tablosunda durumu true olan kategoriler 
                cm.GetList().Where(x => x.CategoryStatus == true).Count() -         //ile false olan kategoriler arasındaki sayısal fark
                cm.GetList().Where(y => y.CategoryStatus == false).Count();

            return View(s);
        }
    }
}