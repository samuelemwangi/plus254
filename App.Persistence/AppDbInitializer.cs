using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using App.Common.Interfaces;
using App.Persistence.DBSeed;

namespace App.Persistence
{
    public class AppDbInitializer
    {
        public static void Initialize(AppDbContext context, IDateTime dateTime)
        {
            var initializer = new AppDbInitializer();

            context.Database.EnsureCreated();

            if (!context.Notifications.Any())
                SeedDB.Tables(context, dateTime);

            //Run DB Scripts
            initializer.SeedDBUsingSQLScripts(context, GetSQLScriptDirectoryFullPath("DBViews"));

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
