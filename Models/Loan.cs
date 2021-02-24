using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mom3._2.Models
{
    public class Loan
    {
        public int LoanId { get; set; }
        [Required(ErrorMessage = "Du måste välja datum när du vill låna skivan")]
        [DataType(DataType.Date)]
        [DisplayName("Utlåningsdatum")]
        public DateTime LoanDate { get; set; }
        [Required(ErrorMessage ="Vem är du?")]
        [DisplayName("Utlånad till")]
        [MinLength(2, ErrorMessage = "Namnet måste bestå av minst två bokstäver")]
        public string FriendName { get; set; }
        
        //FK from album
        [Required(ErrorMessage ="Du måste välja en skiva")]
        [DisplayName("Albumets titel")]
        public int AlbumId { get; set;  }
        public Album Album { get; set; }

    }
}
