using App.Common.Interfaces;
using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Persistence.DBSeed
{
    public class SeedDB
    {
        
        private static readonly Dictionary<int, Category> Categories = new Dictionary<int, Category>();

        private  static readonly string _systemUser = "System";
        private static readonly string _systemUsermail = "no-reply@app.com";

        public static void Tables(AppDbContext appDbContext, IDateTime dateTime)
        {
            
            SeedCategories(appDbContext, dateTime);
            SeedNotifications(appDbContext, dateTime);
        }
        

        private static void SeedCategories(AppDbContext _appDbContext, IDateTime _dateTime)
        {
            Categories.Add(1,
              new Category
              {
                  CategoryName = "Phones",
                  Description = "Phones",
                  Deleted = 0,
                  CreatedBy = _systemUser,
                  CreatedDate = _dateTime.Now,
                  LastEditedBy = _systemUser,
                  LastEditedDate = _dateTime.Now,
                  Products = new[]
                  {
                      new Product
                      {

                          ProductName = "Iphone X",
                          QuantityPerUnit = "25g",
                          UnitPrice = 120000,
                          UnitsInStock = 4,
                          UnitsOnOrder = 1,
                          ReorderLevel = 2,
                          Discontinued = false,
                          CreatedBy = _systemUser,
                          CreatedDate = _dateTime.Now,
                          LastEditedBy = _systemUser,
                          LastEditedDate = _dateTime.Now,
                          Deleted = 0,


                      },
                      new Product
                      {
                          ProductName = "Samsung Galaxy S8+",
                          QuantityPerUnit = "25g",
                          UnitPrice = 120000,
                          UnitsInStock = 5,
                          UnitsOnOrder = 2,
                          ReorderLevel = 2,
                          Discontinued = false,
                          CreatedBy = _systemUser,
                          CreatedDate = _dateTime.Now,
                          LastEditedBy = _systemUser,
                          LastEditedDate = _dateTime.Now,
                          Deleted = 0,

                      },
                      new Product
                     {
                        ProductName = "Lenovo S1 Lite",
                        QuantityPerUnit = "125g",
                        UnitPrice = 25000,
                        UnitsInStock = 5,
                        UnitsOnOrder = 2,
                        ReorderLevel = 2,
                        Discontinued = false,
                        CreatedBy = _systemUser,
                        CreatedDate = _dateTime.Now,
                        LastEditedBy = _systemUser,
                        LastEditedDate = _dateTime.Now,
                        Deleted = 0,
                     }
                  }
              });

            Categories.Add(2,
              new Category
              {
                  CategoryName = "Laptops",
                  Description = "Best Laptops",
                  Deleted = 0,
                  CreatedBy = _systemUser,
                  CreatedDate = _dateTime.Now,
                  LastEditedBy = _systemUser,
                  LastEditedDate = _dateTime.Now,
                  Products = new[]
                  {
                      new Product
                      {

                          ProductName = "HP 250 G6 Core i3 Notebook",
                          QuantityPerUnit = "1800g",
                          UnitPrice = 120000,
                          UnitsInStock = 4,
                          UnitsOnOrder = 1,
                          ReorderLevel = 2,
                          Discontinued = false,
                          CreatedBy = _systemUser,
                          CreatedDate = _dateTime.Now,
                          LastEditedBy = _systemUser,
                          LastEditedDate = _dateTime.Now,
                          Deleted = 0,


                      },
                      new Product
                      {
                          ProductName = "Lenovo ThinkPad T470",
                          QuantityPerUnit = "1600g",
                          UnitPrice = 120000,
                          UnitsInStock = 5,
                          UnitsOnOrder = 2,
                          ReorderLevel = 2,
                          Discontinued = false,
                          CreatedBy = _systemUser,
                          CreatedDate = _dateTime.Now,
                          LastEditedBy = _systemUser,
                          LastEditedDate = _dateTime.Now,
                          Deleted = 0,

                      },
                      new Product
                     {
                        ProductName = "Lenovo ThinkPad T480",
                        QuantityPerUnit = "1580g",
                        UnitPrice = 25000,
                        UnitsInStock = 5,
                        UnitsOnOrder = 2,
                        ReorderLevel = 2,
                        Discontinued = false,
                        CreatedBy = _systemUser,
                        CreatedDate = _dateTime.Now,
                        LastEditedBy = _systemUser,
                        LastEditedDate = _dateTime.Now,
                        Deleted = 0,
                     }
                  }
              });

            foreach(var category in Categories.Values)
            {
                _appDbContext.Categories.Add(category);
            }

            _appDbContext.SaveChanges();
        }

        private static void SeedNotifications(AppDbContext _appDbContext, IDateTime _dateTime)
        {
            var notifications = new[]
            {
                new Notification
                {
                    From = _systemUsermail,
                    To = "sammiemwangi4@gmail.com",
                    Subject = "Initial App Email",
                    Body = "<!DOCTYPE html><html><head><title></title></head><body>Hi Sam<br/> I hope you are good.<br/>Just testing sending this mail. Good day!</body></html>",
                    CreatedBy = _systemUser,
                    CreatedDate = _dateTime.Now,
                    LastEditedBy = _systemUser,
                    LastEditedDate  = _dateTime.Now,
                    Deleted = 0
                }
            };

            _appDbContext.Notifications.AddRange(notifications);
            _appDbContext.SaveChanges();

        }
    }  
}
