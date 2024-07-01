using PlataformaAED.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaAED.data.Repositories
{
    public interface IResRepository
    {
        //GET ALL
        Task<IEnumerable<Reservation>> GetAllReservations();
        //GET by ID
        Task<Reservation> GetRes(int id);
        //POST
        Task<bool> PostRes(Reservation res);
        //PUT
        Task<bool> UpdateRes(Reservation res);
        //DELETE
        Task<bool> DeleteRes(int id);

    }
}
