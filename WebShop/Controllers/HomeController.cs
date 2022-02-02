using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebShop.Models;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.tool.xml;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        { 
            _context = context;
        }

        public IActionResult Index()
        {
            ProductViewModel listProductViewModel = new ProductViewModel
            {
                ListProductView = _context.Product.ToList(),
                ListCart = GetCartProducts()
            };

            if (TempData["shortMessage"] != null)
            {
                ViewBag.Message = TempData["shortMessage"].ToString();
            }
            return View(listProductViewModel);
        }

        [HttpPost]
        public IActionResult Index(ProductViewModel productModel)
        {
            if (productModel.Filter == "" || productModel.Filter == null)
            {
                productModel.ListProductView = _context.Product.ToList();
                productModel.ListCart = GetCartProducts();
            }
            else
            {
                productModel.ListProductView.Clear();
                foreach (var p in _context.Product.ToList())
                {
                    if (p.ProductName.Contains(productModel.Filter, StringComparison.OrdinalIgnoreCase))
                    {
                        productModel.ListProductView.Add(p);
                    }
                }
            }
            return View(productModel);
        }

        private List<ProductModel> GetCartProducts()
        {
            List<ProductModel> cartProducts = new List<ProductModel>();
            if (HttpContext.Session.Get("cart") != null)
            {
                List<CartDetail> cartProductIds = HttpContext.Session.GetObjectFromJson<List<CartDetail>>("cart");
               // string listIds = HttpContext.Session.GetString("cart");
                foreach (var id in cartProductIds)//(List<string>)HttpContext.Session.GetString("cart").Split(",").ToList())
                {
                    cartProducts.Add(_context.Product.Find(Convert.ToInt32(id.ProductId)));
                }
                return cartProducts;
            }
            else
            {
                return cartProducts;
            }
        }

        //[Authorize]
        public IActionResult BuyClicked(int productId)
        {
            List<CartDetail> cartProductIds = new List<CartDetail>();
            if (HttpContext.Session.Get("cart") == null)
            {
                CartDetail product = new CartDetail(productId.ToString());
                cartProductIds.Add(product);

                HttpContext.Session.SetObjectAsJson("cart", cartProductIds);
                ViewBag.cart = cartProductIds.Count();
                HttpContext.Session.SetString("cartCount", cartProductIds.Count().ToString());
            }
            else
            {
                cartProductIds = HttpContext.Session.GetObjectFromJson<List<CartDetail>>("cart");
                CartDetail product = new CartDetail(productId.ToString());
                cartProductIds.Add(product);
                HttpContext.Session.SetObjectAsJson("cart", cartProductIds);
                ViewBag.cart = cartProductIds.Count();
                HttpContext.Session.SetString("cartCount", cartProductIds.Count().ToString());
            }

            TempData["shortMessage"] = $"Added to shopping cart";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ResetCartProducts()
        {
            HttpContext.Session.Remove("cart");
            HttpContext.Session.Remove("cartCount");
            return RedirectToAction("Index");
        }
        public IActionResult EditClicked(int productId)
        {
            ProductModel product = new ProductModel();
            product = _context.Product.Find(productId);
            return PartialView("_partialEdit", product);
        }

        public IActionResult CreateClicked()
        {
            ProductModel product = new ProductModel();
            return PartialView("_partialCreateProduct", product);
        }

        [HttpGet]
        public IActionResult GetCarttInfo()
        {
            ProductViewModel listProductViewModel = new ProductViewModel
            {
                ListProductView = _context.Product.ToList(),
                ListCart = GetCartProducts()
            };
            return PartialView("_partialShoppingCart", listProductViewModel);
        }

        private ApplicationUser GetUserDetails()
        {
            ApplicationUser[] user = _context.Users.Where(u => u.Email == HttpContext.User.Identity.Name).ToArray();
            return user[0];
        }

        [Authorize]
        [HttpGet]
        public IActionResult ProceedToPayment()
        {
            ProductOrderViewModel proceedToPayment = new ProductOrderViewModel
            { ListCartProduct = GetCartProducts() };
            proceedToPayment.NewOrder = new OrderModel()
            {
                Date = DateTime.Now,
                User = GetUserDetails(),
            };
            proceedToPayment.UserDetails = GetUserDetails();
            return PartialView("_ProceedOrderPayment", proceedToPayment);
        }

        [Authorize]
        [HttpPost]
        public FileResult Export(string ReceiptHtml)
        {
            MemoryStream memoryStream = new MemoryStream();            
            using (MemoryStream stream = new System.IO.MemoryStream())
            {
                StringReader sr = new StringReader(ReceiptHtml);
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();
                return File(stream.ToArray(), "application/pdf", "Receipt.pdf");
            }            
        }

        [Authorize]
        [HttpGet]
        public IActionResult NewConfirmedOrder()
        {
            ProductOrderViewModel confirmedOrder = new ProductOrderViewModel
            { ListCartProduct = GetCartProducts() };
            confirmedOrder.NewOrder = new OrderModel()
            {
                Date = DateTime.Now,
                User = GetUserDetails()
            };
            confirmedOrder.UserDetails = GetUserDetails();
            try
            {
                _context.Order.Add(confirmedOrder.NewOrder);
                _context.SaveChanges();

                ProductOrderModel productOrder = new ProductOrderModel();
                foreach (var product in confirmedOrder.ListCartProduct.GroupBy(p => p.ProductId))
                {
                    productOrder.Quantity = product.Count();
                    productOrder.ProductId = product.First().ProductId;
                    productOrder.OrderId = confirmedOrder.NewOrder.OrderId;
                    _context.ProductOrder.Add(productOrder);
                    _context.SaveChanges();
                }

                IActionResult actionResult = ResetCartProducts();
                return PartialView("_OrderReceipt", confirmedOrder);
            }
            catch
            {
                return NotFound();
            }
        }
        public ProductOrderModel newProductOrder(OrderModel order, ProductModel product, int quantity)
        {
            ProductOrderModel addProductOrder = new ProductOrderModel
            {
                Order = order,
                Product = product,
                Quantity = quantity,
            };
            return addProductOrder;
        }

        [Authorize]
        [HttpGet]
        public IActionResult BacktoCart()
        {
            return RedirectToAction("GetCarttInfo");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Proceed()
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CartSummary()
        {
            if (HttpContext.Session.GetString("cartCount") != null)
                ViewData["CartCount"] = HttpContext.Session.GetString("cartCount");

            return PartialView("_partialCartSummary");
        }

        public IActionResult RemoveFromCart(int productId)
        {  
            List<CartDetail> cartProductIds = HttpContext.Session.GetObjectFromJson<List<CartDetail>>("cart");

            foreach (var group in cartProductIds.GroupBy(p=>p.ProductId))
            {
                if (group.First().ProductId== productId.ToString())
                    cartProductIds.Remove(group.First());
            }

            HttpContext.Session.SetObjectAsJson("cart", cartProductIds);
            ViewBag.cart = cartProductIds.Count();
            HttpContext.Session.SetString("cartCount", cartProductIds.Count().ToString());
            //update viewmodel
            ProductViewModel listProductViewModel = new ProductViewModel
            {
                ListProductView = _context.Product.ToList(),
                ListCart = GetCartProducts()
            };
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetProductInfo(int productId)
        {
            ProductModel product = new ProductModel();
            product = _context.Product.Find(productId);
            return PartialView("_partialProductInfo", product);
        }

        // POST: Admin/ProductModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("ProductId,ProductName,Price,Description,ImageName")] ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductModelExists(productModel.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadImage([Bind("ProductId,ProductName,Price,Description,ImageName")] ProductModel productModel, IFormFile ImageName)
        {
            if (ModelState.IsValid)
            {
                var filename = ContentDispositionHeaderValue.Parse(ImageName.ContentDisposition).FileName.Trim('"');
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", ImageName.FileName);
                using (System.IO.Stream stream = new FileStream(path, FileMode.Create))
                {
                    await ImageName.CopyToAsync(stream);
                }
                productModel.ImageName = filename;
                _context.Update(productModel);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        private bool ProductModelExists(int id)
        {
            return _context.Product.Any(e => e.ProductId == id);
        }

        // POST: Admin/ProductModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductName,Price,Description")] ProductModel productModel, IFormFile ImageName)
        {
            var filename = ContentDispositionHeaderValue.Parse(ImageName.ContentDisposition).FileName.Trim('"');
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", ImageName.FileName);
            using (System.IO.Stream stream = new FileStream(path, FileMode.Create))
            {
                await ImageName.CopyToAsync(stream);
            }
            productModel.ImageName = filename;
            _context.Add(productModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int productId)
        {
            ProductModel product = new ProductModel();
            product = _context.Product.Find(productId);
            return PartialView("_partialDeleteProduct", product);
        }

        public async Task<IActionResult> DeleteConfirmed(int ProductId)
        {
            var productModel = await _context.Product.FindAsync(ProductId);
            _context.Product.Remove(productModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
