using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL4.DAL;

namespace BLL4.Models
{
    public class ReservationModel
    {
        public Reservation Record { get; set; }  // Reservation id zaten burada tutuluyor.

        public int CustomerId => Record.CustomerId; //Record Reservation'ın nesnesi olduğu için Name'e kolay bir şekilde ulaşmasını sağlar.Ayrıca Buralara nagivatonal olmayanları eklememiz gerekiyor.

        public DateTime Reservationdate => Record.Reservationdate;   // buradaki DATETIME kısmını sor.variable olarak bu mu string mi ?

        public int TableId => Record.TableId;





    }
}
