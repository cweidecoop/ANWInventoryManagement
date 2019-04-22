using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANWInventoryManagement.Models
{
    public class Item
    {
        public int ID { get; set; }
        public string ItemID { get; set; }
        public string Name { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Category { get; set; }
        public int CategoryID { get; set; }
        public bool CheckedOut { get; set; }
        public int CheckedOutToID { get; set; }
        public string CheckedOutToName { get; set; }
        public DateTime LastCheckOut { get; set; }
        public DateTime LastCheckIn { get; set; }
        public string WindowsKey { get; set; }

    }
}
