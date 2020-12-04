using System;
using System.Collections.Generic;

//4th portion of exercise to allow users to create new products
namespace Testing.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public int DepartmentID { get; set; }
        
        //I think I need this for when I do category table since the departmentID from departments is a column in categories
        public IEnumerable<Department> Departments { get; set; }
    }
}