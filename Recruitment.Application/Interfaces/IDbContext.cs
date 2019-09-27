using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Application.Interfaces
{
   public interface IDbContext:IDisposable
    {
        Task AddCommand(Func<Task> func);
        Task<int> SaveChanges();
        IMongoCollection<T> GetCollection<T>(string name);
        MongoClient MongoClient { get; set; }
    }
}
