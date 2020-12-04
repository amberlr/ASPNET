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
    }
}
