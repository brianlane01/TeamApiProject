using Microsoft.AspNetCore.Mvc;
using TeamApiProject.Models.Reply;
using TeamApiProject.Models.Responses;
using TeamApiProject.Services.Reply;

namespace TeamApiProject.WebApi.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("Api/[controller]")]
    [ApiController]
    public class RepliesController : ControllerBase
    {
        private readonly IRepliesService _repliesService;

        public RepliesController(IRepliesService repliesService)
        {
            _repliesService = repliesService;
        }

        //Get api/replies
        [HttpGet]
        public async Task<IActionResult> GetAllReplies()
        {
            var replies = await _repliesService.GetAllRepliesAsync();
            return Ok(replies);
        }

        //Post api/replies
        [HttpPost]
        public async Task<IActionResult> CreateReplies([FromBody] RepliesRegister request)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _repliesService.CreateRepliesAsync(request);
            if(response is not null)
                return Ok(response);
            
            return BadRequest(new TextResponses("Could not create replies."));
        }

        //Get api/replies by Id
        [HttpGet("{repliesId:int}")]
        public async Task<IActionResult> GetRepliesById([FromRoute] int repliesId)
        {
            RepliesDetail? detail = await _repliesService.GetUserbyIdAsync(repliesId);
            return detail is not null
                ? Ok(detail)
                : NotFound();
        }

        //Update(httpPut) api/replies update
        [HttpPut]
        public async Task<IActionResult> UpdateRepliesById([FromBody] RepliesUpdate request)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return await _repliesService.UpdateNoteAsync(request)
                ? Ok("Replies Updated successfully.")
                : BadRequest("Note could not be updated.");
        }

        //Delete(httpDelte) api/replies delete
        [HttpDelete("{repliesId:int}")]
        public async Task<IActionResult> DeleteReplies([FromRoute] int repliesId)
        {
            return await _repliesService.DeleteRepliesAsync(repliesId)
                ? Ok($"Replies {repliesId} was deleted successfully.")
                : BadRequest($"Replies {repliesId} could not be deleted.");
        }

    }
}