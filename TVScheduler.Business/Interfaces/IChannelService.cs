using TVScheduler.DataAccess.Dto;
using TVScheduler.WebApi.Models;

namespace TVScheduler.Business.Interfaces
{
    public interface IChannelService
    {
        Task<IEnumerable<Channel>> GetAllChannelsAsync();
        Task<Channel> GetChannelByIdAsync(int channelId);
        Task CreateChannelAsync(CreateChannelRequest channel);
    }
}
