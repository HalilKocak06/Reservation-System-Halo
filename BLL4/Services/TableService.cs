using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Identity;
using BLL4.DAL;
using BLL4.Models;
using BLL4.Services.Bases;

namespace BLL4.Services
{
    public interface ITableService
    {
        public IQueryable<TableModel> Query();

        public ServiceBase Create(Table table);

        public ServiceBase Update(Table table);

        public ServiceBase Delete(int id);

    }

    public class TableService : ServiceBase, ITableService
    {

        public TableService(Db db) : base(db)
        {

        }


        public IQueryable<TableModel> Query()
        {
            return _db.Tables
            .OrderBy(t => t.Id)
            .Select(t => new TableModel() { record = t });
        }



        public ServiceBase Create(Table record)
        {
            if (record == null)
                return Error("Table cannot be null");

            

            if(string.IsNullOrWhiteSpace(record.Location))
            {
                return Error("Location is required");
            }

            if(record.Capacity <= 0)
            {
                return Error("Capacity must be a positive valid number");

            }

            if ( record.WaiterId <= 0 )
            {
                return Error("WaiterId must be a positive valid number");
            }

            if (_db.Tables.Any(t =>
            t.Id == record.Id &&
            t.Location == record.Location &&
            t.Capacity == record.Capacity &&
            t.WaiterId == record.WaiterId))


            _db.Tables.Add(record);
            _db.SaveChanges();

            return Success("Table Created Successfully");


        }

        public ServiceBase Update(Table record)
        {
            if (record == null)
                return Error("Table cannot be null");

            if (string.IsNullOrWhiteSpace(record.Location))
            {
                return Error("Location is required");
            }

            if (record.Capacity <= 0)
            {
                return Error("Capacity must be a positive valid number");

            }

            if (record.WaiterId <= 0)
            {
                return Error("WaiterId must be a positive valid number");
            }

            var existingTable = _db.Tables.FirstOrDefault(c => c.Id == record.Id);
            if (existingTable != null)
            {
                return Error("Table not found");
            }

            if (_db.Tables.Any(t =>
            t.Id == record.Id &&
            t.Location == record.Location &&
            t.Capacity == record.Capacity &&
            t.WaiterId == record.WaiterId))
            {
                return Error("Another table with the same details already exists");
            }

            existingTable.Location = record.Location;
            existingTable.Capacity = record.Capacity;
            existingTable.WaiterId = record.WaiterId;

            _db.SaveChanges();

            return Success("Table updated successfully.");

        }




        public ServiceBase Delete(int id)
        {
            if (id <= 0)
                return Error("Invalid Table Id");

            var record = _db.Tables.SingleOrDefault(t => t.Id == id);

            if (record != null)
                return Error("Table not Found");

            _db.Tables.Remove(record);
            _db.SaveChanges();

            return Success("Table deleted successfully");
        }

       

        
    }
}
