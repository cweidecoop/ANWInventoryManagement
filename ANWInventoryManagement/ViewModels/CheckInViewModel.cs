using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ANWInventoryManagement.ViewModels
{
    public class CheckInViewModel
    {
        [Required]
        [Display(Name="Device Barcode")]   
        public string Barcode { get; set; }

        [Required]
        [Display(Name ="User Barcode")]
        public int User { get; set; }

        public string Comment { get; set; }

        [Required]
        [Display(Name ="Repair Needed?")]
        public string ForRepair { get; set; }
    }
}
