using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Testing.Models;

namespace Testing
{
    public interface IDepartmentRepository
    {
        public IEnumerable<Department> GetAllDepartments();
        public Department GetDepartment(int id);
        public void UpdateDepartment(Department department);
        public void InsertDepartment(Department departmentToInsert);

        //not sure if this is needed --edit: this does work.. just do not include the category info that product tables had
        public Department AssignDepartment();
        public void DeleteDepartment(Department department);
    }
}
