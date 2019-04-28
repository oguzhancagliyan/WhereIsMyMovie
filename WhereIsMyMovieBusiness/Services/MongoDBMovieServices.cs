using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WhereIsMyMovieBusiness.Datas;
using WhereIsMyMovieBusiness.Interfaces;

namespace WhereIsMyMovieBusiness.Services
{
    public class MongoDBMovieServices : IMongoDB<Movie>
    {

        private readonly IMongoCollection<Movie> _movies;
        private readonly MongoClient client;
        private readonly IMongoDatabase database;
        public MongoDBMovieServices(IConfiguration config)
        {
            try
            {
                client = new MongoClient(config.GetConnectionString("MoviestoreDb"));
                database = client.GetDatabase("MoviestoreDb");
                _movies = database.GetCollection<Movie>("Movies");
            }
            catch (NullReferenceException ex)
            {

                throw ex;
            }
            catch (MongoConnectionException ex)
            {
                throw ex;
            }
            catch (MongoConfigurationException ex)
            {
                throw ex;
            }

        }
        public void Create(Movie instance)
        {
            _movies.InsertOne(instance);
        }

        public async Task CreateAsync(Movie instance)
        {
            await _movies.InsertOneAsync(instance);
        }

        public void CreateMany(List<Movie> createList)
        {
            _movies.InsertMany(createList);
        }

        public async Task CreateManyAsync(List<Movie> createList)
        {
            try
            {
                await _movies.InsertManyAsync(createList);
            }
            catch (MongoBulkWriteException ex)
            {
                throw ex;
            }
            catch (MongoWriteException ex)
            {
                throw ex;
            }

        }

        public void Delete(Movie instance)
        {
            try
            {
                _movies.DeleteOne(movie => movie.Id == instance.Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteAsync(Movie deleteItem)
        {
            try
            {
                await _movies.DeleteOneAsync(movie => movie.Id == deleteItem.Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteManyAsync(List<Movie> deleteList)
        {
            try
            {
                await _movies.DeleteManyAsync(movie => (deleteList).Contains(movie));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteMawny(List<Movie> deleteList)
        {
            throw new NotImplementedException();
        }

        public Movie Get(string Id)
        {
            return _movies.Find(a => a.Id == Id).FirstOrDefault();
        }

        public List<Movie> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Movie>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public Task<List<Movie>> Search(Expression<Func<Movie, bool>> expresion)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetAsync(string Id)
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
