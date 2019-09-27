using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Recruitment.Application.Interfaces;
using Recruitment.Domain.Entities;

namespace Recruitment.Application.RecruitmentProcess.Queries
{
    public class GetInterviewProcessListDetailQuery : IRequest<InterviewProcessListDetailModel>
    {
        public IEnumerable<InterviewProcess> interviewprocesslist { get; set; }
    }

    public class GetInterviewProcessListQueryHandler: IRequestHandler<GetInterviewProcessListDetailQuery, InterviewProcessListDetailModel>
    {
        private readonly IInterviewProcessRepository _context;
        private readonly IMapper _mapper;


        public GetInterviewProcessListQueryHandler(IInterviewProcessRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<InterviewProcessListDetailModel> Handle(GetInterviewProcessListDetailQuery request, CancellationToken cancellationtoken)
        {
            IEnumerable<InterviewProcess> listOfInterviewprocess;
            listOfInterviewprocess = await _context.GetAll();

            return new InterviewProcessListDetailModel
            {
                interviewprocesslist = _mapper.Map<IEnumerable<InterviewProcess>>(listOfInterviewprocess)
            };


        }
    }

}

