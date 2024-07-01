using PlataformaAED.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaAED.data.Repositories
{
    public interface ISportAreaRepository
    {

        //GET ALL
        Task<IEnumerable<SportArea>> GetAllSportAreas();
        //GET by ID
        Task<SportArea> GetSportAreaById(int id);
        //POST
        Task<bool> PostSportArea(SportArea sportArea);
        //PUT
        Task<bool> PutSportArea(SportArea sportArea);
        //DELETE
        Task<bool> DelSportArea(int id);

    }
}
