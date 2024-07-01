using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaAED.model
{
    public class SportArea //Model fro the sport designated area
    {
        //Annotations for ORM(Object-Relational Mapping)

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int sa_id { get; set; }

        [Required]
        [MaxLength(255)]
        public string sa_location { get; set; }

        [Required]
        [MaxLength(255)]
        public string sa_customer_name { get; set; }

    }
}
