using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL4.DAL;

namespace BLL4.Models
{
    public class TableModel
    {
        public Table record { get; set; }

        public int Capacity => record.Capacity;

        public string Location => record.Location;

        public int WaiterId => record.WaiterId;

    
    }
}
