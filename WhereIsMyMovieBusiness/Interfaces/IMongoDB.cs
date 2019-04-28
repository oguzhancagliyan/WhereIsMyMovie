using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WhereIsMyMovieBusiness.Interfaces
{
    public interface IMongoDB<T>
    {
        //void Connect(string connectionString);
        //void CloseConnection(string connectionString);
        T Get(string Id);


        List<T> GetAll();



        void Create(T instance);



        void CreateMany(List<T> createList);



        void Update(string Id, T instance);

        void UpdateMany(IDictionary<string, T> updateList);

        T UpdateManyAsync(IDictionary<string, T> updateList);
        void Delete(T instance);


        void DeleteMawny(List<T> deleteList);


        #region Async
        /// <summary>
        /// Get one result from an Id
        /// </summary>
        /// <typeparam name="T">Generic type </typeparam>
        /// <param name="Id">Id</param>
        /// <returns>T result</returns>
        Task<T> GetAsync(string Id);        
        Task<List<T>> Search(Expression<Func<T, bool>> expresion);
        /// <summary>
        /// GetAllList from MongoDb via async
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <returns>return all element from DB</returns>
        Task<List<T>> GetAllAsync();

        Task CreateAsync(T instance);

        Task CreateManyAsync(List<T> createList);

        Task DeleteAsync(T deleteItem);

        Task DeleteManyAsync(List<T> deleteList);
        #endregion


    }
}
