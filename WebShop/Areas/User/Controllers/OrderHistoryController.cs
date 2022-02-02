using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebShop.Models;
using WebShop.Areas.User;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace WebShop.Areas.User
{
    [Authorize(Roles = "User")]
    [Area("User")]
    public class OrderHistoryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public OrderHistoryController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            List<ApplicationUser> users = _context.Users.ToList();
            List<OrderModel> orders = _context.Order.ToList();
            List<ProductModel> products = _context.Product.ToList();
            List<ProductOrderModel> UserOrders = _context.ProductOrder.Where(o => o.Order.User.Id == userId).ToList();
            return View(UserOrders);
        }
    }
}
