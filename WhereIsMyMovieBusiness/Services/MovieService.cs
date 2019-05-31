using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WhereIsMyMovieBusiness.Datas;
using WhereIsMyMovieBusiness.Interfaces;
using WhereIsMyMovieUtility.Managers;

namespace WhereIsMyMovieBusiness.Services
{
    public class MovieService : IMovieServices
    {
        private IMongoDB<Movie> _mongoDb;
        public MovieService(IMongoDB<Movie> mongoDB)
        {
            _mongoDb = mongoDB;
        }
        public async Task<List<Movie>> GetMovie(string title)
        {

            var result = await _mongoDb.GetByTitleAsync(title);
            if (result == null)
                return await RequestManager.Instance.GetAsyncWithStream<List<Movie>>("", "", TimeSpan.FromSeconds(20));
            else
                return result;

        }

        public List<Movie> GetMovie(DateTime startdate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
    }
}
