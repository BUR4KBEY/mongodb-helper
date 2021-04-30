using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MongoDBHelper
{
    public class MongoDBMethods<T>
    {
        private IMongoCollection<T> Collection;

        public MongoDBMethods(string table)
        => Collection = new MongoClient().GetDatabase("Your Database Name").GetCollection<T>(table);

        public async Task Insert(T data)
        => await Collection.InsertOneAsync(data);

        public async Task Insert(T[] data)
        => await Collection.InsertManyAsync(data);

        public async Task<T> FindOne(Expression<Func<T, bool>> filter)
        => await Collection.FindAsync(filter).Result.FirstOrDefaultAsync();

        public async Task<List<T>> Find(Expression<Func<T, bool>> filter)
        => await Collection.FindAsync(filter).Result.ToListAsync();

        public async Task<List<T>> ListAll()
        => await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();

        public async Task Update(Expression<Func<T, bool>> filter, T data)
        => await Collection.ReplaceOneAsync(filter, data);

        public async Task DeleteOne(Expression<Func<T, bool>> filter)
        => await Collection.DeleteOneAsync(filter);

        public async Task DeleteMany(Expression<Func<T, bool>> filter)
        => await Collection.DeleteManyAsync(filter);

        public async Task DeleteAll()
        => await Collection.DeleteManyAsync(new BsonDocument());
    }
}
