using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;

namespace GrpcServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        // Additional configuration is required to successfully run gRPC on macOS.
        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(options =>
                    {
                        // when running under MAC TLS with HTTP/2 is not supported so we need to send to http without tls
                        // options.Listen(System.Net.IPAddress.Parse("127.0.0.1"), 5000, o => o.Protocols =
                        //     HttpProtocols.Http2);
                        // options.Listen(System.Net.IPAddress.Parse("127.0.0.1"), 5001, o => o.UseHttps());
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}