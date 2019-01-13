using App.Common.Interfaces;
using App.Domain.Entities;
using System.Collections.Generic;

namespace App.Persistence.DBSeed
{
    public class SeedDB
    {

        private static readonly Dictionary<int, ProductCategory> Categories = new Dictionary<int, ProductCategory>();

        private static readonly string _systemUser = "System";
        private static readonly string _systemUsermail = "no-reply@app.com";

        public static void Tables(AppDbContext appDbContext, IDateTime dateTime)
        {

            SeedCategories(appDbContext, dateTime);
            SeedNotifications(appDbContext, dateTime);
        }


        private static void SeedCategories(AppDbContext _appDbContext, IDateTime _dateTime)
        {
            Categories.Add(1,
              new ProductCategory
              {
                  CategoryName = "Aquaculture",
                  CategoryDescription = "Products from Fish Farming ",
                  Deleted = 0,
                  CreatedBy = _systemUser,
                  CreatedDate = _dateTime.Now,
                  LastEditedBy = _systemUser,
                  LastEditedDate = _dateTime.Now,
                  Products = new[]
                  {
                      new Product
                      {

                          ProductName = "Omena",
                          ProductDescription = "Small Fish",
                          CreatedBy = _systemUser,
                          CreatedDate = _dateTime.Now,
                          LastEditedBy = _systemUser,
                          LastEditedDate = _dateTime.Now,
                          Deleted = 0,


                      },
                      new Product
                      {
                          ProductName = "Tilapia",
                          ProductDescription = "God fish",
                          CreatedBy = _systemUser,
                          CreatedDate = _dateTime.Now,
                          LastEditedBy = _systemUser,
                          LastEditedDate = _dateTime.Now,
                          Deleted = 0,

                      }
                  }
              });

            Categories.Add(2,
              new ProductCategory
              {
                  CategoryName = "Floriculture",
                  CategoryDescription = "Flowers",
                  Deleted = 0,
                  CreatedBy = _systemUser,
                  CreatedDate = _dateTime.Now,
                  LastEditedBy = _systemUser,
                  LastEditedDate = _dateTime.Now,
                  Products = new[]
                  {
                      new Product
                      {

                          ProductName = "Roses",
                          ProductDescription = "Roses",
                          CreatedBy = _systemUser,
                          CreatedDate = _dateTime.Now,
                          LastEditedBy = _systemUser,
                          LastEditedDate = _dateTime.Now,
                          Deleted = 0,


                      }

                  }
              });

            foreach (var category in Categories.Values)
            {
                _appDbContext.ProductCategories.Add(category);
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
