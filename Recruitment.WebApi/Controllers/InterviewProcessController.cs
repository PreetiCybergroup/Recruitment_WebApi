using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recruitment.Application.RecruitmentProcess.Commands.CreateInterviewProcess;
using Recruitment.Application.RecruitmentProcess.Commands.UpdateInterviewProcess;
using Recruitment.Application.RecruitmentProcess.Commands.DeleteInterviewProcess;
using Recruitment.Application.RecruitmentProcess.Queries;

namespace Recruitment.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewProcessController : BaseController
    {
        // GET: api/Recruitment
        [HttpGet]
        public async Task<ActionResult<InterviewProcessListDetailModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetInterviewProcessListDetailQuery()));
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<InterviewProcessDetailModel>> Get(string id)
        {
            return Ok(await Mediator.Send(new GetInterviewProcessDetailQuery { Id = id }));
        }



        // POST: api/Recruitment
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateInterviewProcessCommand command)
        {
          var processId = await Mediator.Send(command);
            return Ok(processId);
        }

    

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromBody] UpdateInterviewProcessCommand command)
    {
       await Mediator.Send(command);
       return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    //[ProducesDefaultResponseType]
    public async Task<IActionResult> Delete(string id)
    {
        await Mediator.Send(new DeleteInterviewProcessCommand { Id = id });
        return NoContent();
    }
  }
}
