using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using Recruitment.Application.Interfaces;
using Recruitment.Domain.Entities;

namespace Recruitment.Persistence.Repositories
{
    public class InterviewProcessRepository : IInterviewProcessRepository
    {
        
        protected readonly IDbContext _context;

        public IMongoCollection<InterviewProcess> DbSet { get; set;} 
        public IMongoCollection<Candidate> candidateDbSet { get; set; }
        public IMongoDatabase recruitment { get; }
        public IMongoDatabase resume { get; }

        //public IMongoCollection<InterviewRound> recruitDbset { get; }

        public InterviewProcessRepository(IDbContext context, IConfiguration configuration) 
        {
            _context = context;
            recruitment = _context.MongoClient.GetDatabase(Environment.GetEnvironmentVariable("DatabaseName") ?? configuration.GetSection("MongoSettings").GetSection("RecruitmentDatabaseName").Value);
            DbSet = recruitment.GetCollection<InterviewProcess>("interviewprocess");
            resume = _context.MongoClient.GetDatabase(Environment.GetEnvironmentVariable("DatabaseName") ?? configuration.GetSection("MongoSettings").GetSection("ResumeDatabaseName").Value);
            candidateDbSet = resume.GetCollection<Candidate>("Candidate");
            // recruitDbset = database.GetCollection<InterviewRound>("interviewround");
        }



        public async void Add(InterviewProcess obj)
        {
         if(obj != null)
            {
                await DbSet.InsertOneAsync(obj);
            }
              
        else
            {
                throw new Exception("Add details to start interview process of a candidate");
            }
            
        }

        public void Dispose()
        {
            _context?.Dispose();
        }


        public  async Task<InterviewProcess> GetById(string Id)
        {
            var tcFilter = Builders<InterviewProcess>.Filter.Eq(_ip => _ip.CandidateUserName, Id);
            var data = await DbSet.FindAsync(tcFilter);
            InterviewProcess interviewProcess = new InterviewProcess();
            
            foreach (var _data in data.ToList())
            {
                var filterId = Builders<Candidate>.Filter.Eq(_ip => _ip.UserName, _data.CandidateUserName);
                var candidatedetails = await candidateDbSet.FindAsync(filterId);
                if(candidatedetails != null)
                { 
                  var candidateName = candidatedetails.FirstOrDefault().Name;
                  _data.candidateName = candidateName;
                 }
                interviewProcess.candidateName = _data.candidateName;
                interviewProcess.FeedbackStatus = _data.FeedbackStatus;
                interviewProcess.Id = _data.Id;
                interviewProcess.StartDate = _data.StartDate;
                interviewProcess.EndDate = _data.EndDate;
            }
            

            return interviewProcess;
        }

        public  async Task<IEnumerable<InterviewProcess>> GetAll()
        {
            
            var all = await DbSet.FindAsync(Builders<InterviewProcess>.Filter.Empty);

            List<InterviewProcess> listofinterviewProcess = new List<InterviewProcess>();
            InterviewProcess interviewProcess = new InterviewProcess();
            foreach (var _data in all.ToList())
            {
                var filterId = Builders<Candidate>.Filter.Eq(_candidate => _candidate.UserName, _data.CandidateUserName);
                var candidatedetails = await candidateDbSet.FindAsync(filterId);
                if (candidatedetails != null)
                {
                    var candidateName = candidatedetails.FirstOrDefault().Name;
                    _data.candidateName = candidateName;
                }
                interviewProcess.CandidateUserName = _data.CandidateUserName;
                interviewProcess.candidateName = _data.candidateName;
                interviewProcess.FeedbackStatus = _data.FeedbackStatus;
                interviewProcess.Id = _data.Id;
                interviewProcess.StartDate = _data.StartDate;
                interviewProcess.EndDate = _data.EndDate;
                listofinterviewProcess.Add(interviewProcess);
            }
                return listofinterviewProcess;
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
           //var filterId = Builders<InterviewProcess>.Filter.Eq(i => i.Id, Id);
            
           // if (filterId != null)
           // {
           //     var interviewround = Builders<InterviewRound>.Filter.Eq(i => i.InterviewProcessId, Id);

                
           //     if (interviewround != null)
           //     {
           //         await recruitDbset.DeleteManyAsync(interviewround);
                    
           //     }
           //     await DbSet.DeleteOneAsync(filterId);
                
           // }

        }

    }
}
