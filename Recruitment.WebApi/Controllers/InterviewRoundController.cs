using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recruitment.Application.RecruitmentProcess.Commands.CreateInterviewRound;
using Recruitment.Application.RecruitmentProcess.Commands.UpdateInterviewRound;
using Recruitment.Application.RecruitmentProcess.Commands.DeleteInterviewRound;
using Recruitment.Application.RecruitmentProcess.Queries;
using Microsoft.AspNetCore.Http;

namespace Recruitment.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class InterviewRoundController : BaseController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<InterviewRoundDetailModel>> Get(string id)
        {
            return Ok(await Mediator.Send(new GetInterviewRoundDetailQuery { Id = id }));
        }

        public async Task<ActionResult<InterviewRoundListDetailModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetInterviewRoundListDetailQuery()));
        }

        // POST: api/Recruitment
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateInterviewRoundCommand command)
        {
            var processId = await Mediator.Send(command);
            return Ok(processId);
        }



        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromBody] UpdateInterviewRoundCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(string id)
        {
            await Mediator.Send(new DeleteInterviewRoundCommand { Id = id });
            return NoContent();
        }

    }
}
