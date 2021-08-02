using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Local_Produce_Initial_Verson.DAO;
using Local_Produce_Initial_Verson.Models;

namespace Local_Produce_Initial_Verson
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FarmersMarket test = new FarmersMarket();
            FarmersMarketSqlDao testDao = new FarmersMarketSqlDao();
            testDao.PopulateFarmersMarket();
            //CreateHostBuilder(args).Build().Run();

        
        }

       /* public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
       */
    }
}
