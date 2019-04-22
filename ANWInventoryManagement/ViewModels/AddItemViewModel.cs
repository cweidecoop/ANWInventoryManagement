using ANWInventoryManagement.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ANWInventoryManagement.ViewModels
{
    public class AddItemViewModel
    {
        
        [Display(Name = "Device")]
        public string Name { get; set; }

        
        [Display(Name = "Barcode ID")]
        public string BarcodeID { get; set; }

        
        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        
        [Display(Name = "Purchase Date")]
        public DateTime PurchaseDate { get; set; }

        public Category Category { get; set; }
        public List<SelectListItem> Categories { get; set; }

        public AddItemViewModel() { }

        public AddItemViewModel(IEnumerable<Category> categories)
        {
            Categories = new List<SelectListItem>();

            foreach (var category in categories)
            {
                Categories.Add(new SelectListItem
                {
                    Value = ((int)category.ID).ToString(),
                    Text = category.Name.ToString()
                });
            }
        }
    }
}
