using TVScheduler.DataAccess.Dto;

namespace TVScheduler.DataAccess
{
    public interface IChannelRepository
    {
        Task<IEnumerable<Channel>> GetAllChannels();
        Task<Channel> GetChannelById(int channelId);
        Task CreateChannel(Channel channel);
    }
}
