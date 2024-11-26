using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL4.DAL
{
    public class Reservation
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; } //Navigatonal

        public DateTime Reservationdate { get; set; }

        public int TableId { get; set; }

        public Table Table { get; set;  } //Nagivational


    }
}
