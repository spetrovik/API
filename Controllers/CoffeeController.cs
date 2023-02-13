using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CoffeeController : Controller
    {
        private readonly ICoffeeRepository? _coffeeRepository;
      //  private readonly IMapper? _mapper;
        public CoffeeController(ICoffeeRepository coffeeRepository)
        {
            this._coffeeRepository = coffeeRepository;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coffee>>> GetCoffees()
        {
            var coffees = await _coffeeRepository!.GetCoffeesAsync();

            return Ok(coffees);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingridient>>> GetIngridients()
        {
            var ingridients = await _coffeeRepository!.GetIngridientsAsync();

            return Ok(ingridients);
        }
    }
}