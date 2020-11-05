using System.Net;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Dess.Api
{
  public class Program
  {
    public static void Main(string[] args)
    {
      CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
      .ConfigureWebHostDefaults(webBuilder =>
      {
        webBuilder.UseStartup<Startup>();
        webBuilder.UseUrls("http://localhost:5000");

        // foreach (var ip in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
        //   webBuilder.UseUrls($"http://{ip.ToString()}:5000");
      });
  }
}