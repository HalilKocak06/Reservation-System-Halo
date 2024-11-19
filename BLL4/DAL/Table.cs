using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL4.DAL
{
    public class Table
    {
        public int Id { get; set; }

        public int Capacity { get; set; }

        public string Location { get; set; }

        public int WaiterId { get; set; }

        public Waiter Waiter { get; set; }

        public ICollection<Food> Foods { get; set; }


    }
}
