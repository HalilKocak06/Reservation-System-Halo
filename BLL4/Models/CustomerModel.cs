using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL4.DAL;

namespace BLL4.Models
{
    public class CustomerModel
    {
        public Customer Record { get; set; }

        public string Name => Record.Name;

        public string Surname => Record.Surname;

        public int PhoneNumber => Record.PhoneNumber;

        public string Email => Record.Email;




    }
}
