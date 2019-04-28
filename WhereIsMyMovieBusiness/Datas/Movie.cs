using MongoDB.Bson.Serialization.Attributes;

namespace WhereIsMyMovieBusiness.Datas
{
    public class Movie
    {
        [BsonId]
        public string Id { get; set; }

    }
}
