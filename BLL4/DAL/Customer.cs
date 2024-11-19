using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL4.DAL
{
    internal class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public int PhoneNumber { get; set; }

        public string Email { get; set; }

        public ICollection<Reservation> Reservations { get; set; }

    }
}
