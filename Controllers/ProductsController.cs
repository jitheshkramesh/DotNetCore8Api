using DotNetCore8Api.Data;
using DotNetCore8Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace DotNetCore8Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ApplicationDbContext _dbContext;
        public ProductsController(ApplicationDbContext dbContext)
        {
            _dbContext= dbContext;
        }

        [HttpGet]
        public async Task<List<Product>> Get()
        {
            return await _dbContext.Product.ToListAsync();
            
        }
    }
}
