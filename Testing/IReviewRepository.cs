using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Testing.Models;

namespace Testing
{
    public interface IReviewRepository
    {
        public IEnumerable<Review> GetAllReviews();
    }
}
