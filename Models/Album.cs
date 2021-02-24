using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Mom3._2.Models
{
    public class Album
    {
        //properties
        public int AlbumId { get; set; }
        [Required (ErrorMessage ="Du måste ange en artist")]
        public string Artist { get; set; }
        [Required(ErrorMessage ="Du måste skriva namnet på albumet")]
        [DisplayName("Titel")]
        public string AlbumTitle { get; set; }

        [DisplayName("Tillgänglig")]
        public bool Available { get; set; } = true;

        public ICollection<Loan> Loans { get; set; }
         
    }
}
