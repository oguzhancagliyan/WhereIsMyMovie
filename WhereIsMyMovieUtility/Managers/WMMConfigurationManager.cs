using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace WhereIsMyMovieUtility.Managers
{
    public class WMMConfigurationManager
    {
        IConfiguration Configuration;
        private WMMConfigurationManager()
        {
        }
        public static WMMConfigurationManager Instance
        {
            get
            {
                return lazy.Value;
            }
        }
        public IConfiguration GetConfiguration() => Configuration;
        private static readonly Lazy<WMMConfigurationManager> lazy = new Lazy<WMMConfigurationManager>();
        public void Initialize(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public  string GetDatabaseConnection() => Configuration.GetConnectionString("DefaultConnection");
        public string GetRedisConnection() => Configuration.GetConnectionString("RedisConnectionString");
    }
}
