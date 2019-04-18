using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ANWInventoryManagement.ViewModels
{
    public class AddUserViewModel
    {
        [Required]
        [Display(Name="User Barcode ID")]
        public int UserID { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public string Location { get; set; }
    }
}
