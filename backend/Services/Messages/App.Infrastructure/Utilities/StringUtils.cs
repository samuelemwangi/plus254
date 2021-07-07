using App.Application.Interfaces.Utilities;
using System.Linq;

/// <summary>
/// 
/// </summary>

namespace App.Infrastructure.Utilities
{
    public class StringUtils : IStringUtils
    {
        public string Capitalize(string message)
        {
            string[] messageArray = message.Split(' ');
            return string.Join(" ", messageArray.Where(s => s.Length > 0).Select(s => char.ToUpper(s[0]) + s[1..].ToLower()));
        }
    }
}
