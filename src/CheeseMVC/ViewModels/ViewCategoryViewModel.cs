using CheeseMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
    public class ViewCategoryViewModel
    {
        public CheeseCategory Category { get; set; }
        public List<Cheese> Cheeses { get; set; }

        public int CheeseID { get; set; }
        public int MenuID { get; set; }

        public ViewCategoryViewModel() { }
        public ViewCategoryViewModel(CheeseCategory category, List<Cheese> cheeses)
        {
            Category = category;
            Cheeses = cheeses;                        
        }
    }
}