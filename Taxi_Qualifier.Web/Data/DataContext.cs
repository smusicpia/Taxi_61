using System.Threading;

using Microsoft.EntityFrameworkCore;

using Taxi_Qualifier.Web.Data.Entities;

namespace Taxi_Qualifier.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<TaxiEntity> Taxis { get; set; }
    }
}
