using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UsingIAsyncEnumerableTaskYield
{
    internal class Manage
    {
        public async IAsyncEnumerable<IEnumerable<Modelo>> GetModels(int numeroPagina, int cantidadRegistros)
        {
            var context = new DataContext(new DbContextOptionsBuilder<DataContext>()
                .UseSqlServer("Server=.;Database=AdventureWorks2022_Restored;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options);
            
            var count = 1;
            while (count<=numeroPagina)
            {
                var query = @$"
                DBCC DROPCLEANBUFFERS;
                DECLARE @PageNumber INT = {count}; -- Número de página
                DECLARE @PageSize INT = {cantidadRegistros}; -- Cantidad de registros por página
                WITH CTE AS (
                    SELECT 
                        SOD.SalesOrderDetailID,
                        p.Name AS ProductName,
                        CAST(sod.OrderQty AS INT) AS TotalQuantitySold,
                        sod.LineTotal AS TotalRevenue
                    FROM  
                        Production.Product p
                    JOIN Sales.SalesOrderDetail sod ON p.ProductID = sod.ProductID
                    JOIN Sales.SalesOrderHeader soh ON sod.SalesOrderID = soh.SalesOrderID
                )
                SELECT *
                FROM CTE
                ORDER BY SalesOrderDetailID,ProductName DESC,TotalQuantitySold,TotalRevenue DESC
                OFFSET (@PageNumber - 1) * @PageSize ROWS
                FETCH NEXT @PageSize ROWS ONLY
                OPTION (MAXDOP 1);
            ";
                count++;
                yield return await context.Modelo.FromSqlRaw(query).ToListAsync();
            }
        }

        public IEnumerable<Modelo> GetModelsList()
        {
            List<Modelo> models = new List<Modelo>();
            models.Add(new Modelo
            {
                SalesOrderDetailID = 1,
                ProductName = "Naroly",
                TotalQuantitySold = 10,
                TotalRevenue = 100
            });
            models.Add(new Modelo
            {
                SalesOrderDetailID = 1,
                ProductName = "Reyning",
                TotalQuantitySold = 10,
                TotalRevenue = 100
            });

            models.Add(new Modelo
            {
                SalesOrderDetailID = 1,
                ProductName = "Erick",
                TotalQuantitySold = 10,
                TotalRevenue = 100
            });

            models.Add(new Modelo
            {
                SalesOrderDetailID = 1,
                ProductName = "Eduardo",
                TotalQuantitySold = 10,
                TotalRevenue = 100
            });

            models.Add(new Modelo
            {
                SalesOrderDetailID = 1,
                ProductName = "Pamela",
                TotalQuantitySold = 10,
                TotalRevenue = 100
            });

            models.Add(new Modelo
            {
                SalesOrderDetailID = 1,
                ProductName = "Omar",
                TotalQuantitySold = 10,
                TotalRevenue = 100
            });

            models.Add(new Modelo
            {
                SalesOrderDetailID = 1,
                ProductName = "Keury",
                TotalQuantitySold = 10,
                TotalRevenue = 100
            });

            models.Add(new Modelo
            {
                SalesOrderDetailID = 1,
                ProductName = "Elier",
                TotalQuantitySold = 10,
                TotalRevenue = 100
            });

            models.Add(new Modelo
            {
                SalesOrderDetailID = 1,
                ProductName = "Hugo",
                TotalQuantitySold = 10,
                TotalRevenue = 100
            });

            models.Add(new Modelo
            {
                SalesOrderDetailID = 1,
                ProductName = "Christofer",
                TotalQuantitySold = 10,
                TotalRevenue = 100
            });

            models.Add(new Modelo
            {
                SalesOrderDetailID = 1,
                ProductName = "David",
                TotalQuantitySold = 10,
                TotalRevenue = 100
            });

            models.Add(new Modelo
            {
                SalesOrderDetailID = 1,
                ProductName = "Emmanuel",
                TotalQuantitySold = 10,
                TotalRevenue = 100
            });

            models.Add(new Modelo
            {
                SalesOrderDetailID = 1,
                ProductName = "Victor",
                TotalQuantitySold = 10,
                TotalRevenue = 100
            });

            models.Add(new Modelo
            {
                SalesOrderDetailID = 1,
                ProductName = "Raymond",
                TotalQuantitySold = 10,
                TotalRevenue = 100
            });

            models.Add(new Modelo
            {
                SalesOrderDetailID = 1,
                ProductName = "Jahaziel",
                TotalQuantitySold = 10,
                TotalRevenue = 100
            });

            models.Add(new Modelo
            {
                SalesOrderDetailID = 1,
                ProductName = "Rosa",
                TotalQuantitySold = 10,
                TotalRevenue = 100
            });

            models.Add(new Modelo
            {
                SalesOrderDetailID = 1,
                ProductName = "Enjher",
                TotalQuantitySold = 10,
                TotalRevenue = 100
            });

            Thread.Sleep(16000);

            return models;
        }
    }
}
