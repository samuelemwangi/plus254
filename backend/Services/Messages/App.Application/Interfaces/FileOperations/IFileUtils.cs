using System.Threading.Tasks;

/// <summary>
/// 
/// </summary>

namespace App.Application.Interfaces.FileOperations
{
    public interface IFileUtils
    {
        Task<string> ReadFileAsync(string filepath);
    }

}
