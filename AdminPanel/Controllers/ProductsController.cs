using System.Web.Mvc;
using AdminPanel.Models;
using Parse;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AdminPanel.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products

        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(FormCollection fc)
        {
            var product = new ParseObject("Product");
            product["mTitle"] = fc["mTitle"];
            product["mPrice"] = fc["mPrice"];
            product["mQuantity"] = fc["mQuantity"];
            product["mManufacture"] = fc["mManufacture"];
            product["ReturningOrder"] = fc["ReturningOrder"];
            product["salePrice"] = fc["salePrice"];
            product["oldPrice"] = fc["oldPrice"];

            await product.SaveAsync();

            return RedirectToAction("ProductsList");
        }

        #region[Edit Product]
        public async Task<ActionResult> EditProduct(string id)
        {
            ParseQuery<ParseObject> q = ParseObject.GetQuery("Product");
            ParseObject product = await q.GetAsync(id);

            return View(product);
        }

        [HttpPost]
        public async Task<ActionResult> EditProduct(string ObjectId, FormCollection fc)
        {
            var query = new ParseQuery<ParseObject>("Product");
            ParseObject product = await query.GetAsync(ObjectId);

            product["mTitle"] = fc["mTitle"];
            product["mPrice"] = fc["mPrice"];
            product["mQuantity"] = fc["mQuantity"];
            product["mManufacture"] = fc["mManufacture"];
            product["ReturningOrder"] = fc["ReturningOrder"];
            product["salePrice"] = fc["salePrice"];
            product["oldPrice"] = fc["oldPrice"];

            await product.SaveAsync();

            return RedirectToAction("ProductsList");
        }

        #endregion

        public async Task<ActionResult> ProductsList()
        {
            ParseQuery<ParseObject> query = ParseObject.GetQuery("Product");
            IEnumerable<ParseObject> products = await query.FindAsync();

            List<Product> _products = new List<Product>();

            foreach (ParseObject p in products)
            {
                Product product = new Product();
                product.ProductId = p.ObjectId;
                product.mTitle = p.Get<string>("mTitle");
                product.mPrice = p.Get<float>("mPrice");
                product.mQuantity = p.Get<float>("mQuantity");
                product.mManufacture = p.Get<string>("mManufacture");
                product.salePrice = p.Get<float>("salePrice");
                product.oldPrice = p.Get<float>("oldPrice");

                _products.Add(product);
            }

            return View(_products);
        }
    }
}