﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ANWInventoryManagement.Models;
using ANWInventoryManagement.ViewModels;
using ANWInventoryManagement.Data;

namespace ANWInventoryManagement.Controllers
{
    public class InventoryController : Controller
    {
        private readonly InventoryManagementDbContext _context;

        public InventoryController(InventoryManagementDbContext dbContext)
        {
            _context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            InventoryViewModel inventoryViewModel = new InventoryViewModel
            {
                Categories = categories
            };

            return View(inventoryViewModel);
        }

        [HttpPost]
        public IActionResult Index(InventoryViewModel inventoryViewModel)
        {

            //var checkedOutItems = _context.CheckOuts.Where(i => i.UserID == inventoryViewModel.UserSearch).OrderByDescending(i => i.CheckOutTime).ToList();
            //var checkedInItems = _context.CheckIns.Where(i => i.UserID == inventoryViewModel.UserSearch).OrderByDescending(i => i.CheckInTime).ToList();
            //var user = _context.Users.Where(i => i.UserID == inventoryViewModel.UserSearch).FirstOrDefault();
            //var categories = _context.Categories.ToList();
            //var currentlyCheckedOutItems = _context.Items.Where(i => i.CheckedOutToID == inventoryViewModel.UserSearch).ToList();

            //InventoryViewModel userPageViewModel = new InventoryViewModel
            //{
            //    CheckedIn = checkedInItems,
            //    CheckedOut = checkedOutItems,
            //    User = user,
            //    Categories = categories,
            //    CheckedOutByUser = currentlyCheckedOutItems
            //};

            //return View("UserPage", inventoryViewModel.UserSearch);
            //return Redirect("/Inventory/UserPage/" + inventoryViewModel.UserSearch);

            if (inventoryViewModel.UserSearch >= 1)
            {
                return RedirectToAction("UserPage", "Inventory", new { id = inventoryViewModel.UserSearch });
            }

            if (inventoryViewModel.ItemSearch != null)
            {
                return RedirectToAction("ItemPage", "Inventory", new { barcode = inventoryViewModel.ItemSearch });
            }


           
            return View();
        }

        public IActionResult UserList()
        {
            var userList = _context.Users.ToList();
            InventoryViewModel inventoryViewModel = new InventoryViewModel
            {
                UserList = userList
            };

            return View(inventoryViewModel);
        }

        public IActionResult AddItem()
        {
            IEnumerable<Category> addItemCategories = _context.Categories.ToList();
            var categories = _context.Categories.ToList();

            return View(new InventoryViewModel(addItemCategories, categories));
        }

        [HttpPost]
        public IActionResult AddItem(InventoryViewModel addItemViewModel)
        {
            if (ModelState.IsValid)
            {
                Category category = _context.Categories.Where(i => i.ID == addItemViewModel.CategoryID).FirstOrDefault();
                var categoryName = category.Name;
                var categoryID = category.ID;

                DateTime purchaseDate = addItemViewModel.PurchaseDate;

                if (purchaseDate == DateTime.MinValue)
                {
                    purchaseDate = DateTime.Today;
                }

                var dupItem = _context.Items.Where(i => i.ItemID == addItemViewModel.ItemID).FirstOrDefault();

                if (dupItem == null)
                {
                    Item newItem = new Item
                    {
                        Name = addItemViewModel.DeviceName,
                        ItemID = addItemViewModel.BarcodeID,
                        PurchaseDate = purchaseDate,
                        Category = categoryName,
                        CategoryID = categoryID,
                        CheckedOut = false
                    };

                    _context.Items.Add(newItem);
                    _context.SaveChanges();
                    return Redirect("/Inventory");

                }
                else
                {
                    ViewBag.message = "Duplicate Barcode";
                    return View(addItemViewModel);
                }

                
            }

            IList<Category> categories = _context.Categories.ToList();

            InventoryViewModel inventoryViewModel = new InventoryViewModel
            {
                Categories = categories
            };
            return View(inventoryViewModel);
        }

        public IActionResult AddUser()
        {
            var categories = _context.Categories.ToList();

            InventoryViewModel inventoryViewModel = new InventoryViewModel
            {
                Categories = categories
            };
            return View(inventoryViewModel);
        }

        [HttpPost]
        public IActionResult AddUser(InventoryViewModel addUserViewModel)
        {
            if (ModelState.IsValid)
            {
                var dupUser = _context.Users.Where(i => i.UserID == addUserViewModel.UserID).FirstOrDefault();

                if (dupUser != null)
                {
                                    User newUser = new User
                {
                    Name = addUserViewModel.DeviceName,
                    UserID = addUserViewModel.UserID,
                    Location = addUserViewModel.Location
                };

                _context.Users.Add(newUser);
                _context.SaveChanges();

                return Redirect("/Inventory");
                }

            }
            var categories = _context.Categories.ToList();

            InventoryViewModel inventoryViewModel = new InventoryViewModel
            {
                Categories = categories
            };
            return View(inventoryViewModel);
        }

        public IActionResult AddCategory()
        {
            var categories = _context.Categories.ToList();

            InventoryViewModel addCategoryViewModel = new InventoryViewModel
            {
                Categories = categories
            };
            return View(addCategoryViewModel);
        }

        [HttpPost]
        public IActionResult AddCategory(InventoryViewModel addCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                Category newCategory = new Category
                {
                    Name = addCategoryViewModel.CategoryName
                };

                _context.Categories.Add(newCategory);
                _context.SaveChanges();

                return Redirect("/Inventory");
            }

            var categories = _context.Categories.ToList();

            InventoryViewModel inventoryViewModel = new InventoryViewModel
            {
                Categories = categories
            };
            return View(inventoryViewModel);
        }

        public IActionResult CheckIn()
        {
            var categories = _context.Categories.ToList();

            InventoryViewModel inventoryViewModel = new InventoryViewModel
            {
                Categories = categories
            };
            return View(inventoryViewModel);
        }

        [HttpPost]
        public IActionResult CheckIn(InventoryViewModel checkInViewModel)
        {
            if (ModelState.IsValid)
            {
                Item item = _context.Items.Where(b => b.ItemID == checkInViewModel.CheckInDeviceBarcode).FirstOrDefault();
                User user = _context.Users.Where(u => u.UserID == checkInViewModel.CheckInUser).FirstOrDefault();

                item.CheckedOut = false;
                item.LastCheckIn = DateTime.Now;

                CheckIn newCheckIn = new CheckIn
                {
                    CheckInTime = DateTime.Now,
                    Comment = checkInViewModel.CheckInComment,
                    UserID = user.UserID,
                    DeviceID = item.ItemID,
                    DeviceCategory = item.Category,
                    DeviceName = item.Name
                };

                item.CheckedOutToID = 99999;
                item.CheckedOutToName = null;
                _context.CheckIns.Add(newCheckIn);
                _context.SaveChanges();
                

                return Redirect("/Inventory");
            }
            var categories = _context.Categories.ToList();

            InventoryViewModel inventoryViewModel = new InventoryViewModel
            {
                Categories = categories
            };

            return View(inventoryViewModel);
        }

        public IActionResult CheckOut()
        {
            var categories = _context.Categories.ToList();

            InventoryViewModel inventoryViewModel = new InventoryViewModel
            {
                Categories = categories
            };

            return View(inventoryViewModel);
        }

        [HttpPost]
        public IActionResult CheckOut(InventoryViewModel checkOutViewModel)
        {
            if (ModelState.IsValid)
            {
                Item item = _context.Items.Where(i => i.ItemID == checkOutViewModel.CheckOutDeviceBarcode).FirstOrDefault();
                User user = _context.Users.Where(i => i.UserID == checkOutViewModel.CheckOutUser).FirstOrDefault();

                CheckOut newCheckOut = new CheckOut
                {
                    CheckOutTime = DateTime.Now,
                    Comment = checkOutViewModel.CheckOutComment,
                    UserID = user.UserID,
                    DeviceID = item.ItemID,
                    DeviceCategory = item.Category,
                    DeviceName = item.Name,
                    UserName = user.Name
                };

                item.CheckedOut = true;
                item.CheckedOutToID = user.UserID;
                item.CheckedOutToName = user.Name;
                item.LastCheckOut = DateTime.Now;

                _context.CheckOuts.Add(newCheckOut);
                _context.SaveChanges();

                return Redirect("/Inventory");
            }

            var categories = _context.Categories.ToList();

            InventoryViewModel inventoryViewModel = new InventoryViewModel
            {
                Categories = categories
            };
            return View(inventoryViewModel);
        }

        public IActionResult Category(int id)
        {
            var availableItems = _context.Items.Where(c => c.CategoryID == id && c.CheckedOut == false).ToList();
            var checkedOutItems = _context.Items.Where(c => c.CategoryID == id && c.CheckedOut == true).ToList();
            var category = _context.Categories.Where(c => c.ID == id).FirstOrDefault();
            var categories = _context.Categories.ToList();

            if (category != null)
            {
                InventoryViewModel viewCategoryViewModel = new InventoryViewModel
                {
                    AvailableItems = availableItems,
                    CheckedOutItems = checkedOutItems,
                    Category = category,
                    Categories = categories
                };

                return View(viewCategoryViewModel);
            }

            return Redirect("/Inventory");
        }

        
        public IActionResult UserPage(int id)
        {
            var checkedOutItems = _context.CheckOuts.Where(i => i.UserID == id).OrderByDescending(i => i.CheckOutTime).ToList();
            var checkedInItems = _context.CheckIns.Where(i => i.UserID == id).OrderByDescending(i => i.CheckInTime).ToList();
            var user = _context.Users.Where(i => i.UserID == id).FirstOrDefault();
            var categories = _context.Categories.ToList();
            var currentlyCheckedOutItems = _context.Items.Where(i => i.CheckedOutToID == id).ToList();

            InventoryViewModel userPageViewModel = new InventoryViewModel
            {
                CheckedIn = checkedInItems,
                CheckedOut = checkedOutItems,
                User = user,
                Categories = categories,
                CheckedOutByUser = currentlyCheckedOutItems
            };

            return View(userPageViewModel);
        }

        //public IActionResult ItemPage(InventoryViewModel inventoryViewModel)
        //{
        //    var checkOuts = _context.CheckOuts.Where(i => i.DeviceID == inventoryViewModel.ItemID).OrderByDescending(i => i.CheckOutTime).ToList();
        //    var checkIns = _context.CheckIns.Where(i => i.DeviceID == inventoryViewModel.ItemID).OrderByDescending(i => i.CheckInTime).ToList();

        //    InventoryViewModel itemPageViewModel = new InventoryViewModel
        //    {
        //        CheckOuts = checkOuts,
        //        CheckIns = checkIns
        //    };

        //    return View(itemPageViewModel);
        //}

        
        public IActionResult ItemPage(string barcode)
        {
            var checkOuts = _context.CheckOuts.Where(i => i.DeviceID == barcode).OrderByDescending(i => i.CheckOutTime).ToList();
            var checkIns = _context.CheckIns.Where(i => i.DeviceID == barcode).OrderByDescending(i => i.CheckInTime).ToList();
            var item = _context.Items.Where(i => i.ItemID == barcode).FirstOrDefault();


            InventoryViewModel itemPageViewModel = new InventoryViewModel
            {
                CheckOuts = checkOuts,
                CheckIns = checkIns
            };


            if (item == null)
            {
                ViewBag.message = "Barcode does not exist";
                return View(itemPageViewModel);
            }
            else
            {
                return View(itemPageViewModel);
            }


        }

        public IActionResult ResetDb()
        {
            foreach (var item in _context.Items)
            {
                _context.Items.Remove(item);
            }

            _context.SaveChanges();
            return Redirect("/Inventory");

        }

        public IActionResult UploadDb()
        {
            var csvLogic = new CSVLogic(_context);
            //csvLogic.UploadItems();
            csvLogic.UploadUsers();
            return Redirect("/Inventory");
        }

        public IActionResult DeleteItem()
        {
            var categories = _context.Categories.ToList();

            InventoryViewModel inventoryViewModel = new InventoryViewModel
            {
                Categories = categories
            };

            return View(inventoryViewModel);
        }

        [HttpPost]
        public IActionResult DeleteItem(InventoryViewModel inventoryViewModel)
        {
            Item item = _context.Items.Where(i => i.ItemID == inventoryViewModel.ItemID).FirstOrDefault();
            _context.Remove(item);
            _context.SaveChanges();
            return Redirect("/Inventory/Index");

        }
    }
}