using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using System.Collections.Generic;
using CheeseMVC.ViewModels;
using CheeseMVC.Data;
using System.Linq;

namespace CheeseMVC.Controllers
{
    public class CatagoryController : Controller
    {
        private readonly CheeseDbContext context;

        public CatagoryController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Add()
        {
            AddCategoryViewModel addCategoryViewModel = new AddCategoryViewModel();
            return View(addCategoryViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCategoryViewModel addCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                CheeseCategory newCatagory = new CheeseCategory
                {
                    Name = addCategoryViewModel.Name
                };

                context.SaveChanges();
                return Redirect("/Category");
            }

            return View(addCategoryViewModel);
        }
    }
}
