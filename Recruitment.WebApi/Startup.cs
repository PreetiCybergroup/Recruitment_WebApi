using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Recruitment.Application.Candidates.Commands.CreateCandidate;
using Recruitment.Application.Candidates.Commands.UpdateCandidate;
using Recruitment.Application.RecruitmentProcess.Commands.CreateInterviewProcess;
using Recruitment.Application.RecruitmentProcess.Commands.UpdateInterviewProcess;
using Recruitment.Application.RecruitmentProcess.Commands.CreateInterviewRound;
using Recruitment.Application.RecruitmentProcess.Commands.UpdateInterviewRound;
using Recruitment.Application.Candidates.Queries;
using Recruitment.Application.Infrastructure;
using Recruitment.Application.Interfaces;
using Recruitment.Persistence;
using Recruitment.Persistence.Repositories;
using Recruitment.WebApi.Filters;
using System.Reflection;
using Recruitment.Application.RecruitmentProcess.Queries;
using AutoMapper;

namespace Recruitment.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            services.AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateCandidateCommandValidator>());


            // Customise default API behavour
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            RegisterServices(services);


            //Enable cors
            //services.AddCors(c =>
            //{
            //    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(options => options
                .SetIsOriginAllowed((host) => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseMvc();

        }
        private void RegisterServices(IServiceCollection services)
        {

            //services.AddScoped<IResumeRepository, ResumeRepository>();

            // Add AutoMapper
            //services.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly });
            // Add MediatR
            //services.AddMediatR(typeof(GetCandidateDetailQueryHandler).GetType().Assembly);
            services.AddAutoMapper(typeof(GetCandidateDetailQueryHandler).GetType().Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddScoped<IDbContext, DbContext>();
            services.AddScoped(typeof(IResumeRepository), typeof(ResumeRepository));
            services.AddScoped(typeof(IInterviewProcessRepository), typeof(InterviewProcessRepository));
            services.AddScoped(typeof(IInterviewRoundRepository), typeof(InterviewRoundRepository));
            


            //To create collections and insert new records
            services.AddScoped(typeof(IRequest), typeof(CreateCandidateCommand));
            services.AddMediatR(typeof(CreateCandidateCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(Unit));

            //To get documents of matching condition
            services.AddScoped(typeof(IRequest), typeof(GetCandidateDetailQueryHandler));
            services.AddMediatR(typeof(GetCandidateDetailQueryHandler).GetTypeInfo().Assembly);

            services.AddScoped(typeof(IRequest), typeof(GetCandidateListQueryHandler));
            services.AddMediatR(typeof(GetCandidateListQueryHandler).GetTypeInfo().Assembly);

            services.AddScoped(typeof(IRequest), typeof(GetInterviewProcessDetailQueryHandler));
            services.AddMediatR(typeof(GetInterviewProcessDetailQueryHandler).GetTypeInfo().Assembly);

            //To get all documents related to InterviewProcess
            services.AddScoped(typeof(IRequest), typeof(GetInterviewProcessListQueryHandler));
            services.AddMediatR(typeof(GetInterviewProcessListQueryHandler).GetTypeInfo().Assembly);

            //To get all documents related to InterviewRound
            services.AddScoped(typeof(IRequest), typeof(GetInterviewRoundDetailQueryHandler));
            services.AddMediatR(typeof(GetInterviewRoundDetailQueryHandler).GetTypeInfo().Assembly);

            //To get all documents related to InterviewRound
            services.AddScoped(typeof(IRequest), typeof(GetInterviewRoundListDetailQueryHandler));
            services.AddMediatR(typeof(GetInterviewRoundListDetailQueryHandler).GetTypeInfo().Assembly);

            //To update collections and update new values
            services.AddScoped(typeof(IRequest), typeof(UpdateCandidateCommand));
            services.AddMediatR(typeof(UpdateCandidateCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(Unit));

            services.AddScoped(typeof(IRequest), typeof(CreateInterviewProcessCommand));
            services.AddMediatR(typeof(CreateInterviewProcessCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(Unit));

            services.AddScoped(typeof(IRequest), typeof(UpdateInterviewProcessCommand));
            services.AddMediatR(typeof(UpdateInterviewProcessCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(Unit));

            services.AddScoped(typeof(IRequest), typeof(CreateInterviewRoundCommand));
            services.AddMediatR(typeof(CreateInterviewRoundCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(Unit));

            services.AddScoped(typeof(IRequest), typeof(UpdateInterviewRoundCommand));
            services.AddMediatR(typeof(UpdateInterviewRoundCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(Unit));

        }
    }
}
