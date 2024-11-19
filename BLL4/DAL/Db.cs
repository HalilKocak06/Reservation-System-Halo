using Microsoft.EntityFrameworkCore;

namespace BLL4.DAL
{
    public  class Db:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Waiter> Waiters { get; set; }
        public DbSet<Food> Foods { get; set; }

        public Db(DbContextOptions<Db> options) : base(options) { }
    }
}
