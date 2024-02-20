using AutoMapper;
using TVScheduler.Business.Interfaces;
using TVScheduler.DataAccess;
using TVScheduler.DataAccess.Dto;
using TVScheduler.WebApi.Models;

namespace TVScheduler.Business
{
    public class ChannelService : IChannelService
    {
        private readonly IChannelRepository _channelRepository;
        private readonly IMapper _mapper;

        public ChannelService(IChannelRepository channelRepository, IMapper mapper)
        {
            _channelRepository = channelRepository;
            _mapper = mapper;
        }

        public async Task CreateChannelAsync(CreateChannelRequest channelModel)
        {
            var channel = _mapper.Map<Channel>(channelModel);
            await _channelRepository.CreateChannel(channel);
        }

        public async Task<IEnumerable<Channel>> GetAllChannelsAsync()
        {
            return await _channelRepository.GetAllChannels();
        }

        public async Task<Channel> GetChannelByIdAsync(int channelId)
        {
            return await _channelRepository.GetChannelById(channelId);
        }
    }
}