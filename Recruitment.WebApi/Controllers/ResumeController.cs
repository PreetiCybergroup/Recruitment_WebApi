using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recruitment.Application.Candidates.Commands.CreateCandidate;
using Recruitment.Application.Candidates.Commands.UpdateCandidate;
using Recruitment.Application.Candidates.Commands.DeleteCandidate;
using Recruitment.Application.Candidates.Queries;


namespace Recruitment.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumeController : BaseController
    {
        // GET: api/Resume

        [HttpGet]
        public async Task<ActionResult<CandidatesListViewModel>> GetAll()
        {
           return Ok(await Mediator.Send(new GetAllCandidateDetailQuery()));
        }

        [HttpGet("{id}")]
        
        public async Task<ActionResult<CandidateDetailModel>> Get(string id)
        {
            return Ok(await Mediator.Send(new GetCandidateDetailQuery { Id = id }));
        }

       

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateCandidateCommand command)
        {
            
            var candidateId = await Mediator.Send(command);
            return Ok(candidateId);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromBody] UpdateCandidateCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(string id)
        {
            await Mediator.Send(new DeleteCandidateCommand { Id = id });
            return NoContent();
        }

    }
}
