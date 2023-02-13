using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Ingridients")]
    public class Ingridient
    {
 
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? IngridientQuantity { get; set;}

        public Coffee? Coffee {get; set;}
        
        public int CoffeeId { get; set; }

    }
    
}