using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Data;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMVC.Controllers
{
    public class SellersController : Controller
    {
        private SalesWebMVCContext _context;
        public SellersController(SalesWebMVCContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Seller.ToListAsync());
        }
    }
}
