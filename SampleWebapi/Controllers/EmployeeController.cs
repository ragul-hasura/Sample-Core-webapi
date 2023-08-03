using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleWebapi.Database;
using SampleWebapi.Models;
//using SampleWebapi.Models;

namespace SampleWebapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        //private readonly ILogger<EmployeeController> _logger;

        private readonly EmployeeDbContext employeeDbContext;

        public EmployeeController(EmployeeDbContext employeeDb)
        {
            this.employeeDbContext = employeeDb;
        }

        //[HttpGet("~/GetAddress")]
        //public IEnumerable<Address> Get()
        //{
        //    using (var context = new AdventureDbContext())
        //    {
        //        List<Address> result = new List<Address>();
        //        result = context.Addresses.ToList();
        //        return result;


        //    }
        //}

        //[HttpGet("~/GetLoginDetails")]

        //public IEnumerable<Customer> GetLogin(Customer cust)
        //{
        //    using (var context = new AdventureDbContext())
        //    {
        //        List<Customer> result = new List<Customer>();
        //        result = context.Customers.Where(res => res.CustomerId <= 50).ToList();
        //        return result;


        //    }
        //}


        [HttpGet]
        public async Task<IActionResult> GetEmployee()
        {
            var employee = await employeeDbContext.Employees.ToListAsync();
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody]Employee emp)
        {
            Random objRandom = new Random();
            emp.EmployeeId = objRandom.Next(10000, 99999);
            await employeeDbContext.Employees.AddAsync(emp);
            await employeeDbContext.SaveChangesAsync();
            return Ok("employee saved successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(Employee emp)
        {
            await employeeDbContext.Employees.AddAsync(emp);
            await employeeDbContext.SaveChangesAsync();
            return Ok("employee saved successfully");
        }
    }
}
