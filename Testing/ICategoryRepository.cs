using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Testing.Models;

namespace Testing
{
    public interface ICategoryRepository
    {
        //display all categories
        public IEnumerable<Category> GetAllCategories();
        //view one at a time
        public Category GetCategory(int id);

        //update
        public void UpdateCategory(Category category);

        //create
        public void InsertCategory(Category categoryToInsert);

        //since categories has a DepartmentID column.. we have to call out to that
        //this may not apply to all tables
        public IEnumerable<Department> GetDepartments();
        public Category AssignDepartment();

        //delete
        public void DeleteCategory(Category category);
    }
}
