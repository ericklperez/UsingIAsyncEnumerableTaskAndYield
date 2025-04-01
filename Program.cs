namespace UsingIAsyncEnumerableTaskYield
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var manager = new ManageDataAccess();

            var data = manager.GetData(2,1000);
            

            await foreach (var itemList in data)
            {
                foreach(var dataInfo in itemList)
                {
                    Console.WriteLine($"SalesOrderDetailID: {dataInfo. SalesOrderDetailID} - ProductName: {dataInfo.ProductName} - TotalQuantitySold: {dataInfo.TotalQuantitySold} - TotalRevenue: {dataInfo.TotalRevenue}");
                }

            }

        }
    }
}
