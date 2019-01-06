using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Reflection;

namespace App.Persistence
{
    public class AppDbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            var initializer = new AppDbInitializer();
            context.Database.EnsureCreated();
            initializer.CreateDBViews(context);
        }

        private void CreateDBViews(AppDbContext context)
        {
            var targetDirectory = Directory.GetCurrentDirectory() + string.Format("{0}..{0}App.Persistence{0}DBViews", Path.DirectorySeparatorChar);

            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
            {                
                context.Database.ExecuteSqlCommand(File.ReadAllText(fileName));
            }
        }
    }
}
