using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANWInventoryManagement.Models
{
    public class CheckOut
    {
        public int ID { get; set; }
        public DateTime CheckOutTime { get; set; }
        public int UserID { get; set; }
        public string DeviceID { get; set; }
        public string DeviceName { get; set; }
        public string DeviceCategory { get; set; }
        public string Comment { get; set; }
        public string UserName { get; set; }

    }
}
