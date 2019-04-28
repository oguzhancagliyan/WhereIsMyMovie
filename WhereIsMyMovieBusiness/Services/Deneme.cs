using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WhereIsMyMovieBusiness.Datas;
using WhereIsMyMovieBusiness.Interfaces;

namespace WhereIsMyMovieBusiness.Services
{
    public class Deneme : IMongoDB<Movie>
    {
        public void Create(Movie instance)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(Movie instance)
        {
            throw new NotImplementedException();
        }

        public void CreateMany(List<Movie> createList)
        {
            throw new NotImplementedException();
        }

        public Task CreateManyAsync(List<Movie> createList)
        {
            throw new NotImplementedException();
        }

        public void Delete(Movie instance)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Movie deleteItem)
        {
            throw new NotImplementedException();
        }

        public Task DeleteManyAsync(List<Movie> deleteList)
        {
            throw new NotImplementedException();
        }

        public void DeleteMawny(List<Movie> deleteList)
        {
            throw new NotImplementedException();
        }

        public Movie Get(string Id)
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Movie>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetAsync(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Movie>> Search(Expression<Func<Movie, bool>> expresion)
        {
            throw new NotImplementedException();
        }

        public void Update(string Id, Movie instance)
        {
            throw new NotImplementedException();
        }

        public void UpdateMany(IDictionary<string, Movie> updateList)
        {
            throw new NotImplementedException();
        }

        public Movie UpdateManyAsync(IDictionary<string, Movie> updateList)
        {
            throw new NotImplementedException();
        }
    }
}
