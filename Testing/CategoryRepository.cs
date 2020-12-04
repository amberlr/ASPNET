using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Testing.Models;

namespace Testing
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbConnection _conn;
        public CategoryRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return _conn.Query<Category>("SELECT * FROM categories;");
        }

        public Category GetCategory(int id)
        {
            return _conn.QuerySingle<Category>("SELECT * FROM categories WHERE CategoryID = @id",
                new { id = id });
        }

        public void UpdateCategory(Category category)
        {
            _conn.Execute("UPDATE categories SET Name = @name WHERE CategoryID = @id",
                new { name = category.Name, id = category.CategoryID });
        }

        public void InsertCategory(Category categoryToInsert)
        {
            _conn.Execute("INSERT INTO categories (NAME, DEPARTMENTID) VALUES (@name, @departmentID);",
                new { name = categoryToInsert.Name, departmentID = categoryToInsert.DepartmentID });
        }

        //need to get departmentIDs as well.. should I add the department names at some point?
        public IEnumerable<Department> GetDepartments()
        {
            return _conn.Query<Department>("SELECT * FROM departments;");
        }
        public Category AssignDepartment()
        {
            var departmentList = GetDepartments();
            var category = new Category();
            category.Departments = departmentList;

            return category;
        }

        public void DeleteCategory(Category category)
        {
            _conn.Execute("DELETE FROM products WHERE CategoryID = @id;",
                                       new { id = category.CategoryID });
            _conn.Execute("DELETE FROM categories WHERE CategoryID = @id;",
                                       new { id = category.CategoryID });
        }
    }
}
