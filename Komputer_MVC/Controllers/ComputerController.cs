using Komputer_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Komputer_MVC.Controllers
{
    public class ComputerController : Controller
    {
        private readonly IComputerService _computerService;

        public ComputerController(IComputerService computerService)
        {
            _computerService = computerService;
        }

        [AllowAnonymous]
        public IActionResult Index(int typeId = 0)
        {
            ViewBag.TypeId = typeId;
            if (typeId == 0)
            {
                return View(_computerService.FindAll());
            }

            else
            {
                return View(_computerService.FindByType(typeId));
            }
        }

        [AllowAnonymous]
        public IActionResult PagedIndex(int typeId = 0, int page = 1, int size = 2)
        {
            List<Computer> computers = new List<Computer>();
            if (typeId == 0)
            {
                computers = _computerService.FindAll();
            }

            else
            {
                computers = _computerService.FindByType(typeId);
            }
            
            ViewBag.TypeId = typeId;
            PagingList<Computer> pagingList = _computerService.FindPage(page, size, computers);
            return View(pagingList);    
            
        }


        [HttpGet]
        [Authorize(Roles = "user, admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "user, admin")]
        public IActionResult Create(Computer computer)
        {
            if (ModelState.IsValid)
            {
                _computerService.Add(computer);
                return RedirectToAction("PagedIndex");
            }
            else
            {
                return View(computer);
            }
        }

        [HttpGet]
        [Authorize(Roles = "admin")] // Dodać rolę jeszcze jakąś jak będzie
        public IActionResult Update(int id)
        {
            return View(_computerService.FindById(id));
        }

        [HttpPost]
        [Authorize(Roles = "admin")] // Dodać rolę jeszcze jakąś jak będzie
        public IActionResult Update(Computer computer)
        {
            if (ModelState.IsValid)
            {
                _computerService.Update(computer);
                return RedirectToAction("PagedIndex");
            }
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            return View(_computerService.FindById(id));
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(Computer computer)
        {
            _computerService.Delete(computer.ComputerId);
            return RedirectToAction("PagedIndex");
        }

        [HttpGet]
        [Authorize(Roles = "user, admin")] 
        public IActionResult Details(int id)
        {
            var model = _computerService.FindById(id);
            return model is null ? NotFound() : View(model);    
        }

    }
}
