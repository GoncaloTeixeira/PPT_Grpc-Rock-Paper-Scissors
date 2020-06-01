using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.SqlServer;

namespace PPT_Grpc
{
    public class Program
    {
        public static void Main(string[] args)
        {
          
            var connectionStringBuilder = new SqlConnectionStringBuilder();

            connectionStringBuilder.DataSource = "./PPTDataBase.db";
            using (var connection = new SqlConnection(connectionStringBuilder.ConnectionString))
            {
                //connection.Open();
               
            }

            CreateHostBuilder(args).Build().Run();
        }

        // Additional configuration is required to successfully run gRPC on macOS.
        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
