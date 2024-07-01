using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaAED.model
{
    public class Reservation //Model for Reservations
    {
        //Mirrors table columns, has to have same names

        public int res_id { get; set; }
        public string res_name { get; set; }

        public string res_location { get; set; }

        public string res_date { get; set; }

        public string res_customer { get; set; }

    }
}
