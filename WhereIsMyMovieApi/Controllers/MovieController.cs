using Microsoft.AspNetCore.Mvc;
using WhereIsMyMovieBusiness.Datas;
using WhereIsMyMovieBusiness.Interfaces;
using WhereIsMyMovieBusiness.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WhereIsMyMovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IMongoDB<Movie> _mongoClient;
        public MovieController(IMongoDB<Movie> mongoDB)
        {
            _mongoClient = mongoDB;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            //_mongoClient.Create(new Movie
            //{
            //    Id = "1"
            //});
          var result =  _mongoClient.Get("1");
            string aa = "aaa";
            return View();
        }        

    }
}
