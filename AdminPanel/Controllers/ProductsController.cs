using System.Web.Mvc;
using AdminPanel.Models;
using Parse;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Web;
using System.IO;
using System.Net.Http;

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
            try
            {
                var product = new ParseObject("Product");

                product["mTitle"] = fc["mTitle"];
                product["mPrice"] = float.Parse(fc["mPrice"]);
                product["mQuantity"] = float.Parse(fc["mQuantity"]);
                product["mManufacture"] = fc["mManufacture"];

                product["mSalePrice"] = float.Parse(fc["mSalePrice"]);
                product["mOldPrice"] = float.Parse(fc["mOldPrice"]);

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
            }
            catch (Exception e)
            {

            }

            return RedirectToAction("ProductsList");
        }

        #region[Edit Product]
        public async Task<ActionResult> EditProduct(string id)
        {
            try
            {
                ParseQuery<ParseObject> q = ParseObject.GetQuery("Product");
                ParseObject p = await q.GetAsync(id);

                Product product = new Product();
                product.ProductId = p.ObjectId;
                product.mTitle = p.Get<string>("mTitle");
                product.mPrice = p.Get<float>("mPrice");
                product.mQuantity = p.Get<float>("mQuantity");
                product.mManufacture = p.Get<string>("mManufacture");
                product.mSalePrice = p.Get<float>("mSalePrice");
                product.mOldPrice = p.Get<float>("mOldPrice");

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
                return View(product);
            }
            catch (ParseException e)
            {
                return View();
            }
           
        }

        [HttpPost]
        public async Task<ActionResult> EditProduct(string id, FormCollection fc)
        {
            try
            {
                ParseQuery<ParseObject> query = ParseObject.GetQuery("Product");
                ParseObject product = await query.GetAsync(id);

                product["mTitle"] = fc["mTitle"];
                product["mPrice"] = float.Parse(fc["mPrice"]);
                product["mQuantity"] = float.Parse(fc["mQuantity"]);
                product["mManufacture"] = fc["mManufacture"];

                product["mSalePrice"] = float.Parse(fc["mSalePrice"]);
                product["mOldPrice"] = float.Parse(fc["mOldPrice"]);

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
            }
            catch (Exception e)
            {

            }

            return RedirectToAction("ProductsList");
        }

        #endregion

        public async Task<ActionResult> DeleteProduct(string id)
        {
            ParseQuery<ParseObject> query = ParseObject.GetQuery("Product");
            ParseObject product = await query.GetAsync(id);

            await product.DeleteAsync();
            return RedirectToAction("ProductsList");
        }

        public async Task<ActionResult> ProductsList()
        {
            ParseQuery<ParseObject> query = ParseObject.GetQuery("Product");

            IEnumerable<ParseObject> products = await query.FindAsync();

            List<Product> _products = new List<Product>();

            foreach (ParseObject p in products)
            {
                Product product = new Product();


                product.mTitle = p.Get<string>("mTitle");
                product.mPrice = p.Get<float>("mPrice");
                product.mQuantity = p.Get<float>("mQuantity");
                product.mManufacture = p.Get<string>("mManufacture");
                product.mSalePrice = p.Get<float>("mSalePrice");
                product.mOldPrice = p.Get<float>("mOldPrice");

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