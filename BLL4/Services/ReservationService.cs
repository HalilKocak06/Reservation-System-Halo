using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Identity;
using BLL4.DAL;
using BLL4.Models;
using BLL4.Services.Bases;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace BLL4.Services
{
    public interface IReservationService
    {
        public IQueryable<ReservationModel> Query();

        public ServiceBase Create(Reservation reservation);

        public ServiceBase Update(Reservation reservation);

        public ServiceBase Delete(int id);

    }
    public class ReservationService : ServiceBase,IReservationService
    {
        public ReservationService(Db db) : base(db)
        {
        }

        public IQueryable<ReservationModel> Query()
        {
            return _db.Reservations
            .OrderBy(s => s.CustomerId)
            .Select(s => new ReservationModel() { Record = s });
        }


        public ServiceBase Create(Reservation record)
        {
            if (record == null)
                return Error("Reservation cannot be null");


            if (string.IsNullOrWhiteSpace(record.CustomerId.ToString()))
                return Error("Customer ID is required.");

            if (record.Reservationdate == default(DateTime))
                return Error("Reservation date is required.");

            if (_db.Reservations.Any(r =>

                r.CustomerId == record.CustomerId &&
                r.Reservationdate == record.Reservationdate &&
                r.TableId == record.TableId))

                record.CustomerId = record.CustomerId; //trim işlemi.
    
            _db.Reservations.Add(record);
            _db.SaveChanges(); //commit to db
            return Success("Reservation Created Successfully.");
        }

        public ServiceBase Update(Reservation record)
        {
            if (record == null)
                return Error("Reservation cannot be null.");
            
            if (record.Id <= 0)
                return Error("Invalid reservation ID.");
            
            var existingRecord = _db.Reservations.FirstOrDefault(r => r.Id == record.Id);

            if (existingRecord == null)
                return Error("Reservation not found.");

            if (string.IsNullOrWhiteSpace(record.CustomerId.ToString()))
                return Error("Customer ID is required.");

            if (record.Reservationdate == default(DateTime))
                return Error("Reservation date is required.");

            if(_db.Reservations.Any( r=>
                r.Id != record.Id &&
                r.CustomerId == record.CustomerId &&
                r.Reservationdate == record.Reservationdate &&
                r.TableId == record.TableId))
            {
                return Error("A conflicting reservation already exists.");
            }

            existingRecord.CustomerId = record.CustomerId;
            existingRecord.Reservationdate = record.Reservationdate;
            existingRecord.TableId = record.TableId;

            _db.SaveChanges();
            return Success("Reservation Updated Successfully");

        }

        public ServiceBase Delete(int id)
        {
            if (id <= 0)
                return Error("Invalid Reservation ID.");

            var record = _db.Reservations.SingleOrDefault(r => r.Id == id);

            if (record == null)
                return Error("Reservation Not Found!");

            _db.Reservations.Remove(record);

            _db.SaveChanges();

            return Success("Reservation deleted successfully.");

        }

       
       
    }
}
