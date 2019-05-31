using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WhereIsMyMovieBusiness.Datas;
using WhereIsMyMovieBusiness.Dtos;
using WhereIsMyMovieBusiness.Interfaces;

namespace WhereIsMyMovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMongoDB<Movie> _mongoClient;
        public MovieController(IMongoDB<Movie> mongoDB)
        {
            _mongoClient = mongoDB;
        }
        public ActionResult<MovieResponseDto> Get(int Id)
        {
            GeneralResponse<MovieResponseDto> response = new GeneralResponse<MovieResponseDto>();

            var result = _mongoClient.Get(Id.ToString());
            if (result == null)
            {
                response.Error = new ErrorDto
                {
                    ErrorCode = System.Net.HttpStatusCode.NotFound,
                    ErrorMessage = "The movie that you looking for is not in the store.",
                };
                return NotFound(response);
            }
            else
            {
                response.Data = new MovieResponseDto
                {
                    MovieName = result.Name,
                    PublishDate = result.PubDate,

                };
                return Ok(response);
            }

        }
    }
}