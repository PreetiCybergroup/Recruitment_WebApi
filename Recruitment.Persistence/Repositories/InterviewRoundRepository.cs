using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using Recruitment.Application.Interfaces;
using Recruitment.Domain.Entities;

namespace Recruitment.Persistence.Repositories
{
    public class InterviewRoundRepository : IInterviewRoundRepository
    {
        public IMongoCollection<InterviewRound> DbSet { get; set; }

        public IMongoCollection<InterviewProcess> IpDbSet { get; set; }
        public IMongoCollection<Feeback> FeedbackDbset { get; set; }

        public IMongoCollection<InterviewRoundType> RoundDbset { get; set; }


        protected readonly IDbContext _context;

        public IMongoCollection<User> userDbset { get; set; }

        

        public InterviewRoundRepository(IDbContext context, IConfiguration configuration)
        {
            _context = context;
            var recruitdatabase = _context.MongoClient.GetDatabase(Environment.GetEnvironmentVariable("DatabaseName") ?? configuration.GetSection("MongoSettings").GetSection("RecruitmentDatabaseName").Value);
            DbSet = recruitdatabase.GetCollection<InterviewRound>("interviewround");

        }

        public async void Add(InterviewRound obj)
        {
            try
            {
                
                //var filter = Builders<User>.Filter.Eq(i=>i.Id, id);
                //var data = userDbset.Find(filterId).FirstOrDefaultAsync().GetAwaiter().GetResult();
                
                //var count = userDbset.CountDocuments(filter);
                await DbSet.InsertOneAsync(obj);
            }
            catch (Exception ex)
            { }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<IEnumerable<InterviewRound>> GetAll()
        {
            var all =  await DbSet.FindAsync(Builders<InterviewRound>.Filter.Empty);
            return all.ToList();
        }

        
        public async Task<InterviewRound> GetById(string interviewProcessId)
        {
           var filterId = Builders<InterviewRound>.Filter.Eq(i => i.InterviewProcessId, interviewProcessId);
           var info = await DbSet.FindAsync(filterId);
           return info.FirstOrDefault();
        }

        public async void Remove(string Id)
        {
            //TODO: Set Delete condition after UI part
            var filterId = Builders<InterviewRound>.Filter.Eq(i => i.Id, Id);
            await DbSet.DeleteOneAsync(filterId);
        }

        public async Task<bool> Update(InterviewRound obj)
        {
            bool result = false;
            var filterId = Builders<InterviewRound>.Filter.Eq(i => i.Id, obj.Id);

            var data = await DbSet.FindAsync(filterId);
            try
            {
                var interviewRound = data.FirstOrDefault();
                if (!string.IsNullOrEmpty(obj.FeedbackId))
                {
                    interviewRound.FeedbackId = obj.FeedbackId;
                }
                if(!string.IsNullOrEmpty(obj.Interviewer))
                { 
                    interviewRound.Interviewer = obj.Interviewer;
                }
                interviewRound.Date = obj.Date;
                result = Convert.ToBoolean(await DbSet.FindOneAndReplaceAsync(filterId, interviewRound));
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        
    }

    
}
