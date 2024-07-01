using PlataformaAED.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaAED.data.Repositories
{
    public interface IReservRepository
    {

        //GET ALL
        Task<IEnumerable<Reserv>> GetAllReserv();
        //GET by ID
        Task<Reserv> GetReservById(int id);
        //POST
        Task<bool> PostReserv(Reserv reserv);
        //PUT
        Task<bool> PutReserv(Reserv reserv);
        //DELETE
        Task<bool> DelReserv(int id);

    }
}
