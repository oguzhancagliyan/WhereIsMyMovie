using System;
using System.Collections.Generic;
using System.Text;
using WhereIsMyMovieBusiness.Datas;

namespace WhereIsMyMovieBusiness.Services
{
    public interface IMovieServices
    {
        List<Movie> GetMovie(string title);
        List<Movie> GetMovie(DateTime startdate, DateTime endDate);

    }
}
