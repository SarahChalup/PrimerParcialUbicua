using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FncPar.Models
{
    class Data
    {
        [Key]
        public DateTime datetime { get; set; }
        [Required]
        public String random { get; set; }
    }
}
