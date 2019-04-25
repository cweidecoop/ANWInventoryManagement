using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ANWInventoryManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace ANWInventoryManagement.ViewModels
{
    public class UserPageViewModel
    {
        [BindProperty(SupportsGet=true)]
        public User User { get; set; }
        public List<CheckOut> CheckedOut { get; set; }
        public List<CheckIn> CheckedIn { get; set; }

        //COMMENT

    }
}
