using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using ANWInventoryManagement.Data;


namespace ANWInventoryManagement.Models
{
    public class CSVLogic
    {
        private InventoryManagementDbContext _context;

        public CSVLogic(InventoryManagementDbContext dbContext)
        {
            _context = dbContext;
        }

        public void UploadUsers()
        {
            using (var reader = new StreamReader(@"C:\Users\Curtis Weide - IT\source\repos\ANWInventoryManagement\ANWInventoryManagement\Files\ID Card LIST - Sheet3.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var lines = reader.ReadLine();
                    var values = lines.Split(',');

                    var duplicateEntry = _context.Users.Where(i => i.UserID == int.Parse(values[3])).FirstOrDefault();

                    if (duplicateEntry == null)
                    {
                        User newUser = new User()
                        {
                            UserID = int.Parse(values[3]),
                            Name = values[0] + " " + values[1]
                        };

                        _context.Users.Add(newUser);
                    }
                }
                _context.SaveChanges();
            }
        }

        public void UploadItems()
        {
            //Ipad Inventory
            using (var reader = new StreamReader(@"FILELOCATION"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    Category category = _context.Categories.Where(c => c.Name == "iPad").FirstOrDefault();

                    var duplicateEntry = _context.Items.Where(i => i.ItemID == values[1]).FirstOrDefault();

                    if (duplicateEntry == null)
                    {
                        Item newItem = new Item()
                        {
                            ItemID = values[1],
                            Name = values[0],
                            Category = category.Name,
                            CategoryID = category.ID,
                        };

                        _context.Items.Add(newItem);
                    }
                }
            }

            using (var reader = new StreamReader(@"asldkfjsdf"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    Category category = _context.Categories.Where(c => c.Name == "Computer").FirstOrDefault();

                    var duplicateEntry = _context.Items.Where(i => i.ItemID == values[1]).FirstOrDefault();

                    if (duplicateEntry == null)
                    {
                        Item newItem = new Item()
                        {
                            ItemID = values[1],
                            Name = values[0],
                            Category = category.Name,
                            CategoryID = category.ID
                        };

                        _context.Items.Add(newItem);
                    }
                }
            }

            _context.SaveChanges();
        }
    }
}
