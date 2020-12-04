using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Testing.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewRepository repo;
        
        public ReviewController(IReviewRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var reviews = repo.GetAllReviews();
            
            return View(reviews);
        }
    }
}
