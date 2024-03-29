﻿using DotNetCore8Api.Data;
using DotNetCore8Api.DTo;
using DotNetCore8Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DotNetCore8Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public CustomerController(ApplicationDbContext dbContext)
        {
            _dbContext=dbContext;
        }

        [HttpGet]
        public async Task<List<Customer>> Get()
        {
            return await _dbContext.Customers.OrderByDescending(c =>c.Id).ToListAsync();

        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllStudentsAsync()
        {
            var value = await _dbContext.Customers.OrderByDescending(c => c.Id).ToListAsync();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTo>> GetCustomer(int id)
        {
            var customer = await _dbContext.Customers 
                                          .FirstOrDefaultAsync(x => x.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            var customerDto = new CustomerDTo()
            {
                firstName = customer.firstName,
                lastName = customer.lastName,
                email = customer.email,
                zipcode = customer.zipcode,

                phone = customer.phone,
                birthDate = customer.birthDate,
                city = customer.city,
                state = customer.state,
                country = customer.country,
                gender = customer.gender,
            };

            Log.Information("Customer GetCustomer {@customer}", customer);
            //var municipioDto = MunicipioAdto(municipio);
            return customerDto;
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> Post(CustomerDTo customerDTo)
        {
            if (customerDTo == null)
            {
                throw new ArgumentNullException("Invalid data");
            }
            else
            {
                var customer = new Customer()
                {
                    firstName = customerDTo.firstName,
                    lastName = customerDTo.lastName,
                    email = customerDTo.email,
                    zipcode=customerDTo.zipcode,

                    phone = customerDTo.phone,
                    birthDate = customerDTo.birthDate,
                    city=customerDTo.city,
                    state=customerDTo.state,
                    country=customerDTo.country,
                    gender=customerDTo.gender,
                   
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    CreatedId = 100,
                    UpdatedId = 100
                };
                _dbContext.Customers.Add(customer);
                await _dbContext.SaveChangesAsync();

                Log.Information("Customer Create {@customer}", customer);

                return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);

            }

        }

        [HttpPut]
        public async Task<ActionResult<bool>> Put(Customer cust)
        {
            var customer = await _dbContext.Customers
                                          .FirstOrDefaultAsync(x => x.Id == cust.Id);

            if (customer == null)
            {
                return NotFound();
            }

            customer.firstName = cust.firstName;
            customer.lastName = cust.lastName;
            customer.birthDate = cust.birthDate;

            customer.email = cust.email;
            customer.gender = cust.gender;
            customer.phone = cust.phone;

            customer.city = cust.city;
            customer.country = cust.country;
            customer.zipcode = cust.zipcode;
            customer.state = cust.state;
            customer.UpdatedDate = DateTime.Now;
            customer.UpdatedId = 200;


            _dbContext.Customers.Update(customer);
            await _dbContext.SaveChangesAsync();

            Log.Information("Customer Put {@customer}", customer);

            //var municipioDto = MunicipioAdto(municipio);
            return true;
        }
    }
}
