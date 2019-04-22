using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using ProtoBuf;
using StackExchange.Redis;
using WhereIsMyMovieUtility.Managers;

namespace WhereIsMyMovieBusiness.Redis
{
    public sealed class RedisCacheManager
    {
        private static readonly Lazy<RedisCacheManager> lazy = new Lazy<RedisCacheManager>(() =>
        {
            string redisConnectionString = WMMConfigurationManager.Instance.GetRedisConnection();
            ConfigurationOptions options = ConfigurationOptions.Parse(redisConnectionString);
            options.AllowAdmin = true;
            var connection = ConnectionMultiplexer.Connect(options);
            return new RedisCacheManager(connection);

        }, true);

        public static RedisCacheManager Instance
        {
            get
            {
                return lazy.Value;
            }
        }
        private RedisCacheManager()
        {

        }
        private RedisCacheManager(ConnectionMultiplexer connection)
        {
            Connection = connection;            
        }
        public ConnectionMultiplexer Connection { get; private set; }

        public IDatabase Database
        {
            get { return Connection.GetDatabase(); }
        }
        public T DeSerializeData<T>(RedisValue data, bool zip = false)
        {
            if (!data.IsNullOrEmpty)
            {
                if (zip)
                {
                    using (var ms = new MemoryStream(data))
                    using (var gzip = new GZipStream(ms, CompressionMode.Decompress, true))
                    {
                        return Serializer.Deserialize<T>(gzip);
                    }
                }
                else
                {
                    using (var stream = new MemoryStream(data))
                    {
                        return Serializer.Deserialize<T>(stream);
                    };
                }
            }
            else
            {
                return default(T);
            }
        }
        public byte[] SerializeData<T>(T data, bool zip = false)
        {
            if (data != null)
            {
                if (zip)
                {
                    using (var ms = new MemoryStream())
                    {
                        using (GZipStream gzip = new GZipStream(ms, CompressionMode.Compress, true))
                        using (var bs = new BufferedStream(gzip, 64 * 1024))
                        {
                            Serializer.Serialize(bs, data);
                        }

                        return ms.ToArray();
                    }
                }
                else
                {
                    using (var stream = new MemoryStream())
                    {
                        Serializer.Serialize(stream, data);
                        return stream.ToArray();
                    }
                }
            }
            else
            {
                return null;
            }
        }
        public T DeSerializeData<T>(byte[] data, bool zip = false)
        {
            if (data != null && data.Length > 0)
            {
                if (zip)
                {
                    using (var ms = new MemoryStream(data))
                    using (var gzip = new GZipStream(ms, CompressionMode.Decompress, true))
                    {
                        return Serializer.Deserialize<T>(gzip);
                    }
                }
                else
                {
                    using (var stream = new MemoryStream(data))
                    {
                        return Serializer.Deserialize<T>(stream);
                    };
                }
            }
            else
            {
                return default(T);
            }
        }
    }
}
