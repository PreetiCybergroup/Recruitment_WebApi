using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Application.Interfaces
{
   public  interface IMongoRepository<TEntity> : IDisposable where TEntity : class
    {
        IMongoCollection<TEntity> DbSet { get; }
        void Add(TEntity obj);
        Task<TEntity> GetById(string id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<bool> Update(TEntity obj);
        void Remove(string id);
        
    }
    
}
