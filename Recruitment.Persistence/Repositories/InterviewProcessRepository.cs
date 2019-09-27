using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Recruitment.Application.Interfaces;
using Recruitment.Domain.Entities;

namespace Recruitment.Persistence.Repositories
{
    public class InterviewProcessRepository : IInterviewProcessRepository
    {
        
        protected readonly IDbContext _context;

        public IMongoCollection<InterviewProcess> DbSet { get; set;} //=> throw new NotImplementedException();

        public IMongoCollection<InterviewRound> recruitDbset { get; }
       
       public InterviewProcessRepository(IDbContext context, IConfiguration configuration) 
        {
            _context = context;
            var database = _context.MongoClient.GetDatabase(Environment.GetEnvironmentVariable("DatabaseName") ?? configuration.GetSection("MongoSettings").GetSection("RecruitmentDatabaseName").Value);
            DbSet = database.GetCollection<InterviewProcess>("interviewprocess");
            recruitDbset = database.GetCollection<InterviewRound>("interviewround");
        }

         

        public async void Add(InterviewProcess obj)
        {
         try
            {
              await DbSet.InsertOneAsync(obj);
            }
            catch(Exception ex)
            { }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }


        public  async Task<InterviewProcess> GetById(string Id)
        {
            var data = await DbSet.FindAsync(Builders<InterviewProcess>.Filter.Eq(_ip => _ip.Id, Id));
            return data.FirstOrDefault();
        }

        public  async Task<IEnumerable<InterviewProcess>> GetAll()
        {
            var all = await DbSet.FindAsync(Builders<InterviewProcess>.Filter.Empty);
            return all.ToList();
        }

        public async Task<bool> Update(InterviewProcess obj)
        {
            bool result = false;
            var filterId = Builders<InterviewProcess>.Filter.Eq(i => i.Id, obj.Id);
            
            var data = await DbSet.FindAsync(filterId);
            try { 
               var interviewProcess = data.FirstOrDefault();
                if(!string.IsNullOrEmpty(obj.FeedbackStatus))
                {
                    interviewProcess.FeedbackStatus = obj.FeedbackStatus;
                }
                   interviewProcess.EndDate = obj.EndDate;
                result = Convert.ToBoolean( await DbSet.FindOneAndReplaceAsync(filterId, interviewProcess));
            }
            catch(Exception ex)
            {
            }
            return result;
        }

        public async void Remove(string Id)
        {
           var filterId = Builders<InterviewProcess>.Filter.Eq(i => i.Id, Id);
            
            if (filterId != null)
            {
                var interviewround = Builders<InterviewRound>.Filter.Eq(i => i.InterviewProcessId, Id);

                
                if (interviewround != null)
                {
                    await recruitDbset.DeleteManyAsync(interviewround);
                    
                }
                await DbSet.DeleteOneAsync(filterId);
                
            }

        }

    }
}
