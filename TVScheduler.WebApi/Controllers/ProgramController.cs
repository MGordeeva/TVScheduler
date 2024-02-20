using Microsoft.AspNetCore.Mvc;
using TVScheduler.Business.Interfaces;
using TVScheduler.WebApi.Models;

namespace TVScheduler.WebApi.Controllers
{
    [Route("api/channel/{channelId}/program")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        private readonly IProgramService _programService;
        private readonly IChannelService _channelService;

        public ProgramController(IProgramService programService, IChannelService channelService)
        {
            _programService = programService;
            _channelService = channelService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int channelId, DateTime? startTime = null, DateTime? endTime = null)
        {
            var programs = await _programService.GetProgramsByChannelAsync(channelId, startTime, endTime);
            return Ok(programs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int channelId, int id)
        {
            var program = await _programService.GetProgramByIdAsync(channelId, id);
            return Ok(program);
        }

        [HttpPost]
        public async Task<IActionResult> Create(int channelId, CreateProgramRequest model)
        {
            var channel = await _channelService.GetChannelByIdAsync(channelId).ConfigureAwait(false);
            if (channel == null)
            {
                return BadRequest($"Channel with id {channelId} does not exist");
            }

            await _programService.CreateProgramAsync(channelId, model);
            return Ok(new { message = "Channel created" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int channelId, int id)
        {
            await _programService.DeleteProgramAsync(channelId, id);
            return Ok(new { message = "Program deleted" });
        }
    }
}