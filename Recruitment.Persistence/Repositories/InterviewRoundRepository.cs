using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Recruitment.Application.Interfaces;
using Recruitment.Domain.Entities;

namespace Recruitment.Persistence.Repositories
{
    public class InterviewRoundRepository : IInterviewRoundRepository
    {
        public IMongoCollection<InterviewRound> DbSet { get; set; }

        public IMongoDatabase mongoDatabase { get; set; }

        protected readonly IDbContext _context;


        public InterviewRoundRepository(IDbContext context, IConfiguration configuration)
        {
            _context = context;
            mongoDatabase = _context.MongoClient.GetDatabase(Environment.GetEnvironmentVariable("DatabaseName") ?? configuration.GetSection("MongoSettings").GetSection("RecruitmentDatabaseName").Value);
            DbSet = mongoDatabase.GetCollection<InterviewRound>("interviewround");
        }

        public async void Add(InterviewRound obj)
        {
            if (obj != null)
            {
                await DbSet.InsertOneAsync(obj);
            }
            else
                throw new Exception("Add details of interview round");
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<IEnumerable<InterviewRound>> GetAll()
        {
            var all = await DbSet.FindAsync(Builders<InterviewRound>.Filter.Empty);
            return all.ToList();
        }

        public async Task<IEnumerable<InterviewRound>> GetAll(string interviewProcessId)
        {
            var filterId = Builders<InterviewRound>.Filter.Eq(i => i.InterviewProcessId, interviewProcessId);
            var details = await DbSet.FindAsync(filterId);
            var all = await DbSet.FindAsync(Builders<InterviewRound>.Filter.Empty);
            return all.ToList();
        }

        public async Task<InterviewRound> GetById(string id)
        {
            //var interviewers = mongoDatabase.GetCollection<Interviewer>("interviewer").AsQueryable();
            //var interviewRounds = DbSet.AsQueryable();
            //var query_result = interviewRounds.Join(interviewers, ir=>ir.InterviewerId, ip=>ip.UserName, (interviewRound, interviewer)=> new { name = interviewers.n})
            //// var query = from interviewRound in DbSet.AsQueryable().Join<Interviewer.> 
            ////where interviewRound.interviewerid = "fdsfdsf"
            ////select interviewRound;

            //comments.Aggregate()
            //                           .Lookup<Comment, User, CommentWithUsers>(
            //                                users,
            //                                x => x.participants,
            //                                x => x.Id,
            //                                x => x.Users).ToList();
            //DbSet.AsQueryable().Join(interviewers, DbSet.i, DbSet. )
            //var x =  DbSet.Aggregate().Lookup<InterviewRound, Interviewer, CommentWithUsers>(interviewers,x => x.InterviewerId,).ToList();



            //var innerJoinResult = itemsA.Join(itemsB,   // inner join A and B
            // itemA => itemA.Id,                      // from each itemA take the Id
            // itemB => itemB.Id,                      // from each itemB take the Id
            // (itemA, itemB) => new                   // when they match make a new object
            // {                                       // where you only select the properties you want
            //   NameA = itemA.Name,
            //   NameB = itemB.Name,
            //   BirthdayA = itemA.Birthday,
            // });


            ///////
            var filterId = Builders<InterviewRound>.Filter.Eq(i => i.Id, id);
            var details = await DbSet.FindAsync(filterId);
            return details.FirstOrDefault();
        }

        public async void Remove(string Id)
        {
            var filterId = Builders<InterviewRound>.Filter.Eq(i => i.Id, Id);
            await DbSet.DeleteOneAsync(filterId);
        }

        public async Task<bool> Update(InterviewRound obj)
        {
            bool result = false;
            var filterId = Builders<InterviewRound>.Filter.Eq(i => i.Id, obj.Id);

            var data = await DbSet.FindAsync(filterId);

            var interviewRound = data.FirstOrDefault();
            if (!string.IsNullOrEmpty(obj.FeedbackId))
            {
                interviewRound.FeedbackId = obj.FeedbackId;
            }
            if (!string.IsNullOrEmpty(obj.InterviewerId))
            {
                interviewRound.InterviewerId = obj.InterviewerId;
            }
            interviewRound.Date = obj.Date;
            result = Convert.ToBoolean(await DbSet.FindOneAndReplaceAsync(filterId, interviewRound));

            // Add Feedback in Interview Process after current round complete
            if (!string.IsNullOrEmpty(obj.FeedbackId))
            {
                var interviewProcessId = Builders<InterviewProcess>.Filter.Eq(i => i.Id, obj.InterviewProcessId);
                var update = Builders<InterviewProcess>.Update.Set(i => i.FeedbackStatus, obj.FeedbackId);
                var dbrecord = await mongoDatabase.GetCollection<InterviewProcess>("interviewprocess").UpdateOneAsync(interviewProcessId, update, new UpdateOptions() { IsUpsert = true });
                var upsertedId = dbrecord.UpsertedId;
                if (upsertedId != null)
                    result = true;
                else
                    result = false;
            }
            return result;


        }


    }


}
