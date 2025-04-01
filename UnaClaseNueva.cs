using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UsingIAsyncEnumerableTaskYield
{
    internal class UnaClaseNueva
    {
        public static async Task Main(string[] asd)
        {
            Manage manage = new Manage();

            //var task1 = Task.Run(() => {
            //    Console.WriteLine("Primera lista sin yield");
            //    var datalistModels = manage.GetModelsList();
            //    foreach (var data in datalistModels)
            //    {
            //        Console.WriteLine($"ProductID: {data.SalesOrderDetailID} - ProductName: {data.ProductName} - TotalQuantitySold: {data.TotalQuantitySold} - TotalRevenue: {data.TotalRevenue}");
            //    }
            //});

            //await task1;
            Console.Write("");
            var task2 = Task.Run(async () => {
                Console.WriteLine("Segunda lista con yield");
                var dataList = manage.GetModels(100,100);
                await foreach (var dataListYield in dataList)
                {
                    foreach (var data in dataListYield.ToList())
                    {
                        Console.WriteLine($"ProductID: {data.SalesOrderDetailID} - ProductName: {data.ProductName} - TotalQuantitySold: {data.TotalQuantitySold} - TotalRevenue: {data.TotalRevenue}");
                    }
                }
            });

            await task2;

        }
    }
}
