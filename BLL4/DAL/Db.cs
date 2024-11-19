using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BLL4.DAL
{
    public  class Db:DbContext
    {
        public Dbset<Customer> Customers { get; set; }
        public Dbset<Reservation> Reservations { get; set; }
        public Dbset<Table> Tables { get; set; }
        public Dbset<Waiter> Waiters { get; set; }
        public Dbset<Food> Foods { get; set; }

        public Db(DbContextOptions<Db> options) : base(options) { }
    }
}
