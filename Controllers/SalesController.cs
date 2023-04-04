using Microsoft.AspNetCore.Mvc;
using storeManager.Data;
using storeManager.Models;

namespace storeManager.Controllers
{
    public class SalesController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SalesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Sales> objSalesList = _db.Sales;
            return View(objSalesList);
        }

        //delete get
        public IActionResult Delete(int? salesid)
        {
            if (salesid == null || salesid == 0)
            {
                return NotFound();
            }

            var productFromDb = _db.Sales.Find(salesid);

            if (salesid == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }

        //delete post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? salesid)
        {
            var obj = _db.Sales.Find(salesid);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Sales.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

  

    }
}
