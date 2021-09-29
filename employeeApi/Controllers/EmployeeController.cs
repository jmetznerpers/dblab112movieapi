using employeeApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace employeeApi.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet("readall")]
        public List<Employee> readall()
        {
            return DAL.ReadAllEmployees();
        }

        [HttpGet("readone")]     //allows open query https://localhost:44330/api/employee/readone?id=3
        public Employee readOne(int id)
        {
            return DAL.ReadOneEmployee(id);
        }

        //[HttpGet("readone/{id}")]  //this way hardcodes the query  as in https://localhost:44330/api/employee/readone/3
        //public Employee readOne(int id)
        //{
        //    return DAL.ReadOneEmployee(id);
        //}


        [HttpGet("readbydepartment/{dept}")]
        public List<Employee> readbydepartment(string dept)
        {
            List<Employee> result = DAL.ReadAllByDeparment(dept);
            return result;
        }

        [HttpDelete("delete")]
        public bool deleteEmployee(int id)
        {
            return DAL.DeleteEmployee(id);
        }

        [HttpPost("add")]
        public Employee addEmployee(Employee emp)
        {
            return DAL.AddEmployee(emp);
        }

        [HttpPut("update")]
        public Employee updateEmployee(Employee emp)
        {
            return DAL.UpdateEmployee(emp);
        }
    }
}
