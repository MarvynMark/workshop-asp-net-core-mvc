using SalesWebMvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers {
    public class SellersController : Controller {
        private readonly SellerService _SellerService;

        public SellersController(SellerService sellerService) {
            _SellerService = sellerService;
        }
        public IActionResult Index() {
            var list = _SellerService.FindAll();
            return View(list);
        }
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Seller seller) {
            _SellerService.Isert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
