using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using storeManager.Data;
using storeManager.Models;
using storeManager.ViewModel;

namespace storeManager.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> objProductList = _db.Products;
            ViewBag.DbContext = _db;
            return View(objProductList);


        }


        //create get
        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new ProductCategoryViewModel

            {
                Categories = _db.Categories.ToList()
            };
            return View(viewModel);
        }

        //create post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductCategoryViewModel obj)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Add(obj.Product);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            obj.Categories = _db.Categories.ToList();
            return View(obj);
        }

        //edit get
        public IActionResult Edit(int? productid)
        {
            if (productid == null || productid == 0)
            {
                return NotFound();
            }

            var productFromDb = _db.Products.Find(productid);

            if (productid == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }

        //edit post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            if (product.productName == product.productCategory)
            {
                ModelState.AddModelError("CustomError", "Product Name and Product Category must not match!!");
            }
            if (ModelState.IsValid)
            {
                _db.Products.Update(product);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }
        //delete get
        public IActionResult Delete(int? prdid)
        {
            if (prdid == null || prdid == 0)
            {
                return NotFound();
            }

            var productFromDb = _db.Products.Find(prdid);

            if (prdid == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }

        //delete post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? prdid)
        {
            var obj = _db.Products.Find(prdid);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Products.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        // sell get
        public IActionResult Sell(int? sellid)
        {
            if (sellid == null || sellid == 0)
            {
                return NotFound();
            }

            var productFromDb = _db.Products.Find(sellid);

            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }

        // sell post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Sell(int sellid, string customerName, string contactNumber, string address)
        {
            var productFromDb = _db.Products.Find(sellid);

            if (productFromDb == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                productFromDb.productQuantity--;

                // Create a new Sales object and populate its properties
                var sales = new Sales
                {
                    CustomerName = customerName,
                    ContactNumber = contactNumber,
                    Address = address,
                    ProductName = productFromDb.productName,
                    Category = productFromDb.productCategory,
                    Total = productFromDb.productPrice
                };

                // Add and save the new Sales object to the database
                _db.Sales.Add(sales);
                _db.Products.Update(productFromDb);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productFromDb);
        }


        public IActionResult Search(string query)
        {
            var products = _db.Products
                .Where(p => p.productName.Contains(query))
                .ToList();

            return View(products);
        }


    }
}