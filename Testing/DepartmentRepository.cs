using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Testing.Models;

namespace Testing
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _conn;

        public DepartmentRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<Department> GetAllDepartments()
        {
            return _conn.Query<Department>("SELECT * FROM departments;");
        }
        public Department GetDepartment(int id)
        {
            return _conn.QuerySingle<Department>("SELECT * FROM departments WHERE DepartmentID = @id",
                new { id = id });
        }
        public void UpdateDepartment(Department department)
        {
            _conn.Execute("UPDATE departments SET Name = @name WHERE DepartmentID = @id",
                new { name = department.Name, id = department.DepartmentID });
        }
        public void InsertDepartment(Department departmentToInsert)
        {
            _conn.Execute("INSERT INTO departments (NAME) VALUES (@name);",
                new { name = departmentToInsert.Name });
        }

        //not sure if this is needed --edit: this does work.. just do not include the category info that product tables had
        public Department AssignDepartment()
        {
            var department = new Department();
            return department;
        }

        //categories uses departmentID so I need to delete it from there as well
        public void DeleteDepartment(Department department)
        {
            _conn.Execute("DELETE FROM categories WHERE DepartmentID = @id;",
                                       new { id = department.DepartmentID });
            _conn.Execute("DELETE FROM departments WHERE DepartmentID = @id;",
                                       new { id = department.DepartmentID });
        }

    }
}
