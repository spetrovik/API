using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class CoffeeRepository : ICoffeeRepository
    {
        private readonly DataContext _context;
        public CoffeeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Coffee>> GetCoffeesAsync()
        {
            return await _context.Coffees!
             .Include(m => m.Ingridients).ToListAsync();
        }
        public async Task<IEnumerable<Ingridient>> GetIngridientsAsync()
        {
            return await _context.Coffees!.SelectMany(x => x.Ingridients!).ToListAsync();
        }
        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Coffee coffee)
        {
            _context.Entry(coffee).State = EntityState.Modified;
        }
    }
}