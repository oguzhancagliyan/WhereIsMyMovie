using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WhereIsMyMovieBusiness.Interfaces;

namespace WhereIsMyMovieBusiness.Cache
{
    public class RedisProvider : IDatabase
    {
        public  T Get<T>(string key, bool zip) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync<T>(string key, bool zip) where T : class
        {
            throw new NotImplementedException();
        }

        public bool IsExist(string key)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistAsync(string key)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(string key)
        {
            throw new NotImplementedException();
        }

        public void Set<T>(string key, T data, TimeSpan cacheTime, bool zip) where T : class
        {
            throw new NotImplementedException();
        }

        public Task SetAsync<T>(string key, T data, TimeSpan cacheTime, bool zip) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
