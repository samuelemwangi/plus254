using App.Application.Interfaces.FileOperations;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace App.Infrastructure.FileOperations
{
    public class FileUtils : IFileUtils
    {
        private readonly ILogger<FileUtils> _fileUtilsLogger;
        public FileUtils(ILogger<FileUtils> fileUtilsLogger)
        {
            _fileUtilsLogger = fileUtilsLogger;
        }
        public async Task<string> ReadFileAsync(string filePath)
        {

            string fileText = "";

            try
            {
                if (!File.Exists(filePath)) throw new Exception(filePath + "does not exist");

                using StreamReader str = new(filePath);
                fileText = await str.ReadToEndAsync();

            }
            catch (Exception e)
            {
                _fileUtilsLogger.LogError(e.Message);
            }

            return fileText;

        }
    }
}
