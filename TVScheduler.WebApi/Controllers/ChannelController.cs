using Microsoft.AspNetCore.Mvc;
using TVScheduler.Business.Interfaces;
using TVScheduler.WebApi.Models;

namespace TVScheduler.WebApi.Controllers
{
    [Route("api/channel")]
    [ApiController]
    public class ChannelController : ControllerBase
    {
        private readonly IChannelService _channelService;

        public ChannelController(IChannelService channelService)
        {
            _channelService = channelService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var channels = await _channelService.GetAllChannelsAsync();
            return Ok(channels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var channel = await _channelService.GetChannelByIdAsync(id);
            return Ok(channel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateChannelRequest model)
        {
            await _channelService.CreateChannelAsync(model);
            return Ok(new { message = "Channel created" });
        }
    }
}