using MongoDB.Bson.Serialization.Attributes;
using System;

namespace WhereIsMyMovieBusiness.Datas
{
    public class Movie
    {
        [BsonId]
        public string Id { get; set; }

        public string Name { get; set; }
        public DateTime PubDate { get; set; }
        public Authors Author { get; set; }

    }
}
