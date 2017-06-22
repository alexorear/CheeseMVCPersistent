using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using System.Collections.Generic;
using CheeseMVC.ViewModels;
using CheeseMVC.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CheeseMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CheeseDbContext context;

        public CategoryController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<CheeseCategory> cheeseCategories = context.Categories.ToList();
            return View(cheeseCategories);
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
                CheeseCategory newCategory = new CheeseCategory
                {
                    Name = addCategoryViewModel.Name
                };

                context.Categories.Add(newCategory);
                context.SaveChanges();
                return Redirect("/Category");
            }

            return View(addCategoryViewModel);
        }

        public IActionResult ViewCategory(int id)
        {
            List<Cheese> cheeses = context
                .Cheeses
                .Where(c => c.CategoryID == id)
                .ToList();

            CheeseCategory category = context.Categories.Single(c => c.ID == id);

            return View(new ViewCategoryViewModel(category, cheeses));
        }
    }
}
