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

            //DESCOMENTAR CODIGO SI CUENTA CON BASE DE DATOS ADVENTUREWORKS_2022
            //Console.WriteLine("Lista con yield y base de datos");
            //var dataList = manage.GetModelsWithYieldAndDatabase(100,100);
            //await foreach (var dataListYield in dataList)
            //{
            //    foreach (var data in dataListYield.ToList())
            //    {
            //        Console.WriteLine($"ProductID: {data.SalesOrderDetailID} - ProductName: {data.ProductName} - TotalQuantitySold: {data.TotalQuantitySold} - TotalRevenue: {data.TotalRevenue}");
            //    }
            //}

            Console.WriteLine("Lista con yield y sin base de datos. Se observa cómo se obtienen los datos mientras se procesa sin esperar a que se lean todos.");
            var dataList = manage.GetModelsListWithYield();
            await foreach (var data in dataList)
            {
                Console.WriteLine($"ProductID: {data.SalesOrderDetailID} - ProductName: {data.ProductName} - TotalQuantitySold: {data.TotalQuantitySold} - TotalRevenue: {data.TotalRevenue}");
            }

            Console.WriteLine("Lista sin yield. Se observa de que se tiene que esperar que se termine de procesar todos los datos hasta que responda.");
            var datalistModels = await manage.GetModelsListWithoutYield();
            foreach (var data in datalistModels)
            {
                Console.WriteLine($"ProductID: {data.SalesOrderDetailID} - ProductName: {data.ProductName} - TotalQuantitySold: {data.TotalQuantitySold} - TotalRevenue: {data.TotalRevenue}");
            }

            Console.Write("--------------------------------------");
            Console.Read();

        }
    }
}
