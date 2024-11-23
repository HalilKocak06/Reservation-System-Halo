using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class ReservationService : ServiceBase
    {
    }
}
