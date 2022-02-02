using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebShop.Models;

namespace WebShop.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ProductModelController : Controller
    {
        private readonly AppDbContext _context;
        public ProductModelController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/ProductModel
        public async Task<IActionResult> Index()
        {
            List<ApplicationUser> list = _context.Users.ToList();
            return View(await _context.Product.ToListAsync());
        }

        // GET: Admin/ProductModel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productModel = await _context.Product
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (productModel == null)
            {
                return NotFound();
            }

            return View(productModel);
        }

        // GET: Admin/ProductModel/Create
        public IActionResult Create()
        {
            return View();
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

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productModel = _context.Product.FirstOrDefault(m => m.ProductId == id);
            if (productModel == null)
            {
                return NotFound();
            }

            return View(productModel);
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
            return View(productModel);
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

        // GET: Admin/ProductModel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productModel = await _context.Product
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (productModel == null)
            {
                return NotFound();
            }

            return View(productModel);
        }

        // POST: Admin/ProductModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productModel = await _context.Product.FindAsync(id);
            _context.Product.Remove(productModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductModelExists(int id)
        {
            return _context.Product.Any(e => e.ProductId == id);
        }
    }
}
