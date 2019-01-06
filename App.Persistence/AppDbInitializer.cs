using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Reflection;
using System.Linq;

namespace App.Persistence
{
    public class AppDbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            var initializer = new AppDbInitializer();
            context.Database.EnsureCreated();
             
            //For MSSQLServer 
            initializer.SeedDBUsingSQLScripts(context, GetSQLScriptDirectoryFullPath("DBViews"));
            
            // If Table has records do not seed
            if (!context.Notifications.Any())
                initializer.SeedDBUsingSQLScripts(context, GetSQLScriptDirectoryFullPath("SeedDBTables"));
        }

        private static string GetSQLScriptDirectoryFullPath(string targetFolder)
        {
            return Directory.GetCurrentDirectory() + string.Format("{0}..{0}App.Persistence{0}DBScripts{0}{1}", Path.DirectorySeparatorChar, targetFolder);
        }

        private void SeedDBUsingSQLScripts(AppDbContext context, string targetDirectory)
        {
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
            {
                context.Database.ExecuteSqlCommand(File.ReadAllText(fileName));
            }
        }

    }
}
