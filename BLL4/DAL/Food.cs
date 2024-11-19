using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL4.DAL
{
    public class Food
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public ICollection<Table> Tables { get; set; }




    }
}
