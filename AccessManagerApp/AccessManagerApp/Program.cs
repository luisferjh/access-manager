using AccessManagerApp.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AccessManagerApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Encrypter.EncryptPassword("123354435", out byte[] salt, out string hashed);
            CreateHostBuilder(args).Build().Run();          
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });        
    }
}
