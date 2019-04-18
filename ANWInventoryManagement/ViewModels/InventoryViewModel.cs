using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ANWInventoryManagement.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ANWInventoryManagement.ViewModels
{
    public class InventoryViewModel
    {
        public IList<Category> Categories { get; set; }

        [Display(Name = "User Search")]
        public int UserSearch { get; set; }

        public User User { get; set; }
        public List<CheckOut> CheckedOut { get; set; }
        public List<CheckIn> CheckedIn { get; set; }

        public IList<Item> AvailableItems { get; set; }
        public IList<Item> CheckedOutItems { get; set; }
        public Category Category { get; set; }

        [Required]
        [Display(Name ="Category Name")]
        public string CategoryName { get; set; }

        [Required]
        [Display(Name = "Device Barcode")]
        public string CheckInDeviceBarcode { get; set; }

        [Required]
        [Display(Name = "User Barcode")]
        public int CheckInUser { get; set; }

        [Display(Name ="Comment")]
        public string CheckInComment { get; set; }

        [Required]
        [Display(Name = "Repair Needed?")]
        public string CheckInForRepair { get; set; }

        [Required]
        [Display(Name ="Device Barcode")]
        public string CheckOutDeviceBarcode { get; set; }

        [Required]
        [Display(Name = "User Barcode")]   
        public int CheckOutUser { get; set; }

        [Display(Name = "Comment")]
        public string CheckOutComment { get; set; }

        [Required]
        [Display(Name = "User Barcode ID")]
        public int UserID { get; set; }

        [Required]
        [Display(Name ="Name")]
        public string UserName { get; set; }

        public string Location { get; set; }

        [Required]
        [Display(Name ="Device")]
        public string DeviceName { get; set; }

        [Required]
        [Display(Name ="Barcode ID")]  
        public string BarcodeID { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        [Display(Name = "Purchase Date")]
        public DateTime PurchaseDate { get; set; }  

        public Category AddItemCategory { get; set; }
        public List<SelectListItem> AddItemCategories { get; set; }

        public IList<Item> CheckedOutByUser { get; set; }

        public InventoryViewModel() { }

        public InventoryViewModel(IEnumerable<Category> categories, IList<Category> navCategories)
        {
            AddItemCategories = new List<SelectListItem>();
            IList<Category> Categories = navCategories;

            foreach (var category in categories)
            {
                AddItemCategories.Add(new SelectListItem
                {
                    Value = ((int)category.ID).ToString(),
                    Text = category.Name.ToString()
                });
            }
        }
    }
}
