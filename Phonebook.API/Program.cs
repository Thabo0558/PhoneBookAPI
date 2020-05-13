using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Phonebook.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string logFileName = string.Format("./Logs/PhonebookAPI-{0}-log.txt", DateTime.Now.ToString("yyyy-MM-dd"));
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((builderContext, config) => 
                {
                    IHostingEnvironment environment = builderContext.HostingEnvironment;
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);                   
                })                
                .UseStartup<Startup>();
    }
}
