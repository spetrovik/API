using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Coffee
    {
        public int Id { get; set; }

        public string? Name  { get; set; }
        
        public ICollection<Ingridient>? Ingridients {get; set;}
  
    }
}