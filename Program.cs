using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

//https://channel9.msdn.com/Blogs/MVP-VisualStudio-Dev/EF-Core-Quick-Starts-ASPNET-Core-in-Visual-Studio-2017

namespace ScheduleService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}