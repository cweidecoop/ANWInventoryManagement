using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ANWInventoryManagement.Models;

namespace ANWInventoryManagement.ViewModels
{
    public class ViewCategoryViewModel
    {
        public IList<Item> AvailableItems { get; set; }
        public IList<Item> CheckedOutItems { get; set; }
        public Category Category { get; set; }
    }
}
