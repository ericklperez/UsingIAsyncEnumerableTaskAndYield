using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UsingIAsyncEnumerableTaskYield
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbContext):base(dbContext)
        {
            
        }
        public DbSet<Modelo> Modelo { get; set; }
    }
}
