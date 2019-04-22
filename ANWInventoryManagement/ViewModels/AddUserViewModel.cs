using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ANWInventoryManagement.ViewModels
{
    public class AddUserViewModel
    {
        
        [Display(Name="User Barcode ID")]
        public int UserID { get; set; }

        
        [Display(Name = "Name")]
        public string Name { get; set; }

        public string Location { get; set; }
    }
}
