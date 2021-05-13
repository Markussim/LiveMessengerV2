using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveMessenger
{
    public class Program 
    {
        public static void Main(string[] args)
        {
            ConnectToDB.connectToMongo(); //Connectes to MongoDB Server
            FleckConnection.start(); //Starts the Websocket Server
            CreateHostBuilder(args).Build().Run(); //Starts the Razor Project.
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => //FROM INIT OF PROJECT
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
