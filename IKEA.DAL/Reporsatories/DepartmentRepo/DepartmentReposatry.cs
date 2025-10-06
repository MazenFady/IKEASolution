using IKEA.DAL.Context;
using IKEA.DAL.Models.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IKEA.DAL.Reporsatories.DepartmentRepo
{
   
    public class DepartmentReposatry : IDepartmentReposatry 
    {
        private readonly ApplicationDBContext _context;

        public DepartmentReposatry(ApplicationDBContext context)
        {
            _context = context;

        }
        public IEnumerable<Department> GetAll(bool WithTracking=false)
        {
            if (WithTracking)
                return _context.Departments.ToList();
            else
                return _context.Departments.AsNoTracking().ToList();    
        }

        public Department GetById(int id)
        {
            var Department = _context.Departments.Find(id);
            return Department;
        }

        public int Add(Department department)
        {
          _context.Departments.Add(department);
            return _context.SaveChanges();
        }
        public int Update(Department department)
        {
            _context.Departments.Update(department);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
           var department = _context.Departments.Find(id);
            _context.Departments.Remove(department);
            return _context.SaveChanges();
        }

       
      
    }
}
