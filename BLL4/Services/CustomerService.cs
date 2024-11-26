using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL4.DAL;
using BLL4.Models;
using BLL4.Services.Bases;

namespace BLL4.Services
{
    public interface ICustomerService
    {
        public IQueryable<CustomerModel> Query();

        public ServiceBase Create(Customer customer);

        public ServiceBase Update(Customer customer);

        public ServiceBase Delete(int id);
    }
    public class CustomerService : ServiceBase, ICustomerService
    {
        public CustomerService(Db db) : base(db)
        {

        }

        public IQueryable<CustomerModel> Query()
        {
            return _db.Customers
            .OrderBy(s => s.Id)
            .Select(s => new CustomerModel() { Record = s });
        }


        public ServiceBase Create(Customer record)
        {
            if (record == null)
                return Error("Customer cannot be null");

            if (string.IsNullOrWhiteSpace(record.Name) || string.IsNullOrWhiteSpace(record.Surname))
            {
                return Error("Name and Surname are required");
            }

            if (string.IsNullOrWhiteSpace(record.Email))
            {
                return Error("Email are required");
            }

            if (record.PhoneNumber <= 0)
            {
                return Error("Phone number must be a valid positive number");
            }

            if (_db.Customers.Any(r =>

                r.Name == record.Name &&
                r.Surname == record.Surname &&
                r.Email == record.Email &&
                r.PhoneNumber == record.PhoneNumber))

                _db.Customers.Add(record);
            _db.SaveChanges();
            return Success("Reservation Created Successfully.");

        }

        public ServiceBase Update(Customer record)
        {
            if (record == null)
                return Error("Customer cannot be null");

            if (string.IsNullOrWhiteSpace(record.Name) || string.IsNullOrWhiteSpace(record.Surname))
            {
                return Error("Name and Surname are required");
            }

            if (string.IsNullOrWhiteSpace(record.Email))
            {
                return Error("Email is required");
            }

            if (record.PhoneNumber <= 0)
            {
                return Error("Phone number must be a valid positive number");
            }

            var existingCustomer = _db.Customers.FirstOrDefault(c => c.Id == record.Id);
            if (existingCustomer == null)
            {
                return Error("Customer not found.");
            }

            //Checking
            if (_db.Customers.Any(c =>
                c.Id != record.Id &&
                c.Name == record.Name &&
                c.Surname == record.Surname &&
                c.Email == record.Email &&
                c.PhoneNumber == record.PhoneNumber))
            {
                return Error("Another customer with the same details already exists.");
            }

            // Updating...
            existingCustomer.Name = record.Name;
            existingCustomer.Surname = record.Surname;
            existingCustomer.PhoneNumber = record.PhoneNumber;
            existingCustomer.Email = record.Email;

            _db.SaveChanges();

            return Success("Customer updated successfully.");
        }

        public ServiceBase Delete(int id)
        {
            if (id <= 0)
                return Error("Invalid Reservation ID.");

            var record = _db.Customers.SingleOrDefault(c => c.Id == id);

            if (record == null)
                return Error("Customer not found!");

            _db.Customers.Remove(record);
            _db.SaveChanges();

            return Success("Customer deleted successfully");
        }
    }
}
