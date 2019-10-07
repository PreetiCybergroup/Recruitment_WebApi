using AutoMapper;
using MediatR;
using Recruitment.Application.Interfaces;
using Recruitment.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Recruitment.Application.RecruitmentProcess.Queries
{
    public class GetInterviewRoundListDetailQuery : IRequest<InterviewRoundListDetailModel>
    {
        public IEnumerable<InterviewRound> interviewRoundList { get; set; }
        public string interviewProcessId { get; set; }
    }

    public class GetInterviewRoundListDetailQueryHandler : IRequestHandler<GetInterviewRoundListDetailQuery, InterviewRoundListDetailModel>
    {
        private readonly IInterviewRoundRepository _context;
        private readonly IMapper _mapper;

        public GetInterviewRoundListDetailQueryHandler(IInterviewRoundRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<InterviewRoundListDetailModel> Handle(GetInterviewRoundListDetailQuery request, CancellationToken cancellationtoken)
        {
            IEnumerable<InterviewRound> listOfInterviewRound;
            if (!string.IsNullOrWhiteSpace(request.interviewProcessId))
            {
                listOfInterviewRound = await _context.GetAll(request.interviewProcessId);
            }
            else
            {
                listOfInterviewRound = await _context.GetAll();
            }

            return new InterviewRoundListDetailModel
            {
                interviewRoundList = _mapper.Map<IEnumerable<InterviewRound>>(listOfInterviewRound)
            };


        }

    }
}


