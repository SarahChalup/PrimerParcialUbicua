using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDoble.Models
{
    public class Data
    {
        [Key]
        public DateTime datetime { get; set; }
        [Required]
        public String random { get; set; }
    }
}
