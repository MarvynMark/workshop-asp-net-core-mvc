using SalesWebMvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;

namespace SalesWebMvc.Controllers {
    public class SellersController : Controller {
        private readonly SellerService _SellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService) {
            _SellerService = sellerService;
            _departmentService = departmentService;
        }
        public IActionResult Index() {
            var list = _SellerService.FindAll();
            return View(list);
        }
        public IActionResult Create() {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Seller seller) {
            _SellerService.Isert(seller);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id) {
            if (id == null) {
                return NotFound();
            }
            var obj = _SellerService.FindById(id.Value);
            if (obj == null) {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id) {
            _SellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id) {
            if (id == null) {
                return NotFound();
            }
            var obj = _SellerService.FindById(id.Value);
            if (obj == null) {
                return NotFound();
            }
            return View(obj);
        }
    }
}
