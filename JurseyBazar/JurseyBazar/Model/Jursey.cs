using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JurseyBazar.Model
{
    public class Jursey
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string  Name { get; set; }
        [Required]
        public string TeamsName { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int  Quantity { get; set; }
        
    }
}
