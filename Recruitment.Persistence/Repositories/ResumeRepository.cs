using System;
using System.Collections.Generic;
using System.Text;
using Recruitment.Domain.Entities;
using Recruitment.Application.Interfaces;
using System.Threading.Tasks;
using MongoDB.Driver;
using System.Threading;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;

namespace Recruitment.Persistence.Repositories
{
    public class ResumeRepository: IResumeRepository 
    {
        protected readonly IDbContext _context;

        public IMongoCollection<Candidate> DbSet { get; set; }

        public string ftpPath { get; }

        public string ftpUserName { get; }

        public string ftpPassword { get; }

        public ResumeRepository(IDbContext context, IConfiguration configuration) 
        {
            _context = context;
            var database = _context.MongoClient.GetDatabase(Environment.GetEnvironmentVariable("DatabaseName") ?? configuration.GetSection("MongoSettings").GetSection("ResumeDatabaseName").Value);

            DbSet = database.GetCollection<Candidate>("Candidate");
            ftpPath = configuration.GetSection("FtpServerPath").GetSection("ServerPath").Value;
            ftpUserName = configuration.GetSection("FtpServerPath").GetSection("UserName").Value;
            ftpPassword = configuration.GetSection("FtpServerPath").GetSection("Password").Value;
        }

        public async void Add(Candidate obj)
        {
            await DbSet.InsertOneAsync(obj); 
        }

        public async Task<Candidate> GetById(string name)
        {
            var filterId = Builders<Candidate>.Filter.Eq(_ip => _ip.Name , name);
            var data = await DbSet.FindAsync(filterId);
            return data.FirstOrDefault();
        }

        public async Task<IEnumerable<Candidate>> GetAll()
        {
            var all = await DbSet.FindAsync(Builders<Candidate>.Filter.Empty);
            return all.ToList();
        }

        public async Task<bool> Update(Candidate obj)
        {
            bool result = false;
            var filterId = Builders<Candidate>.Filter.Eq(i => i.Id, obj.Id);
            var data = await DbSet.FindAsync(filterId);
            try
            {
                var candidateInfo = data.FirstOrDefault();
                if (!string.IsNullOrEmpty(obj.Name))
                    candidateInfo.Name = obj.Name;
                if(!string.IsNullOrEmpty(obj.Mobile))
                    candidateInfo.Mobile = obj.Mobile;
                if (!string.IsNullOrEmpty(obj.ResumePath))
                    candidateInfo.ResumePath = obj.ResumePath;
                if (!string.IsNullOrEmpty(obj.Email))
                    candidateInfo.Email = obj.Email;
                if (!string.IsNullOrEmpty(obj.TechnicalSkills))
                    candidateInfo.TechnicalSkills = obj.TechnicalSkills;

               result = Convert.ToBoolean(await DbSet.FindOneAndReplaceAsync(filterId, obj));
            }
            catch(Exception ex)
            {
            }
            return result;
            
         }
        

        public async void Remove(string Id)
        {
            var filterId = Builders<Candidate>.Filter.Eq(i => i.Id, Id);
            await DbSet.DeleteOneAsync(filterId);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
