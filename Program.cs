using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using UniscanServer.DataAccess;

namespace UniscanServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args) 
                .UseKestrel(options => {
                    options.Listen(IPAddress.Loopback, 5000);
                    // Uncomment line below to enable HTTPS at Kestrel's level. (Also uncomment "//app.UseHttpsRedirection();" in Startup.cs)
                    // You will need to configure the certificate that gets used.. (Better option is using apache's ProxyPass with letsencrypt if hosting?)
                    //options.Listen(IPAddress.Loopback, 5001, listenOptions => { listenOptions.UseHttps("certificate.pfx", "topsecret"); } );
                }).UseStartup<Startup>();
    }
}
