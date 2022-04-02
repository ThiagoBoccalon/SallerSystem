using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Data;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Models;

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

        // GET: Sellers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sellers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,BirthDate,BaseSalary,Department")] Seller seller)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seller);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(seller);
        }
    }
}
