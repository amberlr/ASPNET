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

    }
}
