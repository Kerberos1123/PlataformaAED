using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaAED.model
{
    public class Reserv //Model for Reservations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int res_id { get; set; }

        [Required]
        [MaxLength(255)]
        public string res_name { get; set; }

        [Required]
        [MaxLength(255)]
        public string res_customer { get; set; }

        [Required]
        [MaxLength(255)]
        public string res_date { get; set; }

        [ForeignKey("SportArea")]
        public int res_sportArea { get; set; }

       // public virtual SportArea SportArea { get; set; }


    }
}
