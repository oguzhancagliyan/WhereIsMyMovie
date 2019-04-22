using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WhereIsMyMovieBusiness.Interfaces
{
    public interface IDatabase
    {
        Task<T>  GetAsync<T>(string key, bool zip) where T : class;

        T Get<T>(string key, bool zip) where T : class;

        Task SetAsync<T>(string key, T data, TimeSpan cacheTime, bool zip) where T : class;

        void Set<T>(string key, T data, TimeSpan cacheTime, bool zip) where T : class;

        Task<bool> IsExistAsync(string key);

        bool IsExist(string key);

        Task RemoveAsync(string key);

        void Remove(string key);
    }
}
