using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace betaNana.Models
{
    public class QuoteDetail : EntityBase
    {
       // [ForeignKey("QuoteId")]
        [Required]
        public int QuoteId { get; set; }

        [MaxLength(250)] 
        public string SampleText { get; set; }

        //Navigation Properties
        public Quote Quote { get; set; }

    }
}
