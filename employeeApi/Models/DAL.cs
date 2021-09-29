using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;
using Dapper;

namespace employeeApi.Models
{
    public class DAL
    {
        public static MySqlConnection DB;
        public static List<Employee> ReadAllEmployees()
        {
            return DB.GetAll<Employee>().ToList();
        }

        public static Employee ReadOneEmployee(int id)
        {
            return DB.Get<Employee>(id);
        }

        public static List<Employee> ReadAllByDeparment(string _dept)
        {
            var myParams = new { dept = _dept };
            string sql = "select * from employee where department = @dept";
            List<Employee> emps = DB.Query<Employee>(sql, myParams).ToList();
            return emps;
        }
        public static bool DeleteEmployee(int _id)
        {
            Employee temp = new Employee() { id = _id };
            DB.Delete<Employee>(temp);
            return true;
        }
        public static Employee AddEmployee(Employee emp)
        {
            DB.Insert<Employee>(emp);
            return emp;
        }

        public static Employee UpdateEmployee(Employee emp)
        {
            DB.Update<Employee>(emp);
            return emp;
        }
    }
}
