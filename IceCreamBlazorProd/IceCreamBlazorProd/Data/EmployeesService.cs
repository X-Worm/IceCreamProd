using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IceCreamBlazorProd.Data
{
    public class EmployeesService
    {
        private readonly ApplicationDbContext _db;

        public EmployeesService(ApplicationDbContext db)
        {
            _db = db;
        }

        // CRUD

        // get
        public List<Employee> GetEmployees()
        {
            var empList = _db.Employees.ToList();
            return empList;
        }

        // insert
        public void Create(Employee emp)
        {
            _db.Add(emp);
            _db.SaveChanges();
        }

        // delete
        public void Delete(Employee emp)
        {
            _db.Employees.Remove(emp);
            _db.SaveChanges();
        }

        // update
        public void Update(Employee emp)
        {
            _db.Employees.Update(emp);
            _db.SaveChanges();
        }

        // get by id
        public Employee GetById(int id)
        {
            return _db.Employees.ToList().Where(item => item.EmployeeId == id).FirstOrDefault();
            
        }
    }
}
