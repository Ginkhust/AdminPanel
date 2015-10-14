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
            
            product["salePrice"] = fc["salePrice"];
            product["oldPrice"] = fc["oldPrice"];

            product["mScreenSize"] = fc["mScreenSize"];
            product["mScreenResolution"] = fc["mScreenResolution"];
            product["mCPU"] = fc["mCPU"];
            product["mRAM"] = fc["mRAM"];
            product["mROM"] = fc["mROM"];
            product["mMemoryCard"] = fc["mMemoryCard"];
            product["mCamera"] = fc["mCamera"];
            product["mSim"] = fc["mSim"];
            product["mOS"] = fc["mOS"];
            product["mPin"] = fc["mPin"];
            product["mWeight"] = fc["mWeight"];

            product["mSize"] = fc["mSize"];
            product["mConnectionPort"] = fc["mConnectionPort"];
            product["mGuarantee"] = fc["mGuarantee"];


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
            ParseQuery<ParseObject> query = ParseObject.GetQuery("Product");
            ParseObject product = await query.GetAsync(ObjectId);

            product["mTitle"] = fc["mTitle"];
            product["mPrice"] = fc["mPrice"];
            product["mQuantity"] = fc["mQuantity"];
            product["mManufacture"] = fc["mManufacture"];
            product["salePrice"] = fc["salePrice"];
            product["oldPrice"] = fc["oldPrice"];

            product["mScreenSize"] = fc["mScreenSize"];
            product["mScreenResolution"] = fc["mScreenResolution"];
            product["mCPU"] = fc["mCPU"];
            product["mRAM"] = fc["mRAM"];
            product["mROM"] = fc["mROM"];
            product["mMemoryCard"] = fc["mMemoryCard"];
            product["mCamera"] = fc["mCamera"];
            product["mSim"] = fc["mSim"];
            product["mOS"] = fc["mOS"];
            product["mPin"] = fc["mPin"];
            product["mWeight"] = fc["mWeight"];

            product["mSize"] = fc["mSize"];
            product["mConnectionPort"] = fc["mConnectionPort"];
            product["mGuarantee"] = fc["mGuarantee"];

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

                product.mScreenResolution = p.Get<string>("mScreenResolution");
                product.mScreenSize = p.Get<string>("mScreenSize");
                product.mCPU = p.Get<string>("mCPU");
                product.mRAM = p.Get<string>("mRAM");
                product.mROM = p.Get<string>("mROM");
                product.mMemoryCard = p.Get<string>("mMemoryCard");
                product.mCamera = p.Get<string>("mCamera");
                product.mSim = p.Get<string>("mSim");
                product.mOS = p.Get<string>("mOS");
                product.mPin = p.Get<string>("mPin");
                product.mWeight = p.Get<string>("mWeight");

                product.mSize = p.Get<string>("mSize");
                product.mConnectionPort = p.Get<string>("mConnectionPort");
                product.mGuarantee = p.Get<string>("mGuarantee");
                _products.Add(product);
            }

            return View(_products);
        }
    }
}