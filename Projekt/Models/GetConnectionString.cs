/// Connection string
using Microsoft.Extensions.Configuration;
using System.IO;
namespace Projekt.Models
{
/// <summary>
/// Connection string
/// Lacznik z baza danych
/// </summary>

    public class GetConnectionString
    {
        public static string ConString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var config = builder.Build();
            string constring = config.GetConnectionString("BDW");
            return constring;
        }
    }
}
