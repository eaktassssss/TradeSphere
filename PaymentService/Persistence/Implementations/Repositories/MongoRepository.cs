using MongoDB.Driver;
using PaymentService.Application.Interfaces.Repositories;
using PaymentService.Domain.Common;
using System.Linq.Expressions;
using TradeSphere.Shared.Configurations.Mongo;

namespace PaymentService.Persistence.Implementations.Repositories
{
    public class MongoRepository<T> : IMongoRepository<T, string> where T : BaseEntity, new()
    {
        IMongoCollection<T> _collection;
        protected MongoRepository(IMongoConfiguration mongoConfiguration)
        {
            var client = new MongoClient(mongoConfiguration.ConnectionString);
            var db = client.GetDatabase(mongoConfiguration.DatabaseName);
            _collection = db.GetCollection<T>(mongoConfiguration.CollectionName);
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            return predicate == null
       ? _collection.AsQueryable().AsEnumerable().ToList()
       : _collection.AsQueryable().Where(predicate).ToList();

        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _collection.Find(predicate).FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<T> InsertAsync(T entity)
        {
            var options = new InsertOneOptions { BypassDocumentValidation = false };
            await _collection.InsertOneAsync(entity, options);
            return entity;
        }

        public async Task<T> UpdateAsync(string id, T entity)
        {
            return await _collection.FindOneAndReplaceAsync(x => x.Id == id, entity);
        }

        public async Task<T> UpdateAsync(T entity, Expression<Func<T, bool>> predicate)
        {
            return await _collection.FindOneAndReplaceAsync(predicate, entity);
        }

        public async Task<T> DeleteAsync(T entity)
        {
            return await _collection.FindOneAndDeleteAsync(x => x.Id == entity.Id);
        }

        public async Task<T> DeleteAsync(string id)
        {
            return await _collection.FindOneAndDeleteAsync(x => x.Id == id);
        }

        public async Task<T> DeleteAsync(Expression<Func<T, bool>> filter)
        {
            return await _collection.FindOneAndDeleteAsync(filter);
        }
    }
}
