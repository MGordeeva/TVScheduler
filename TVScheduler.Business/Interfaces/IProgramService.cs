using TVScheduler.DataAccess.Dto;
using TVScheduler.WebApi.Models;

namespace TVScheduler.Business.Interfaces
{
    public interface IProgramService
    {
        Task<IEnumerable<Program>> GetProgramsByChannelAsync(int channelId, DateTime? startTime, DateTime? endTime);
        Task<Program?> GetProgramByIdAsync(int channelId, int id);
        Task DeleteProgramAsync(int channelId, int id);
        Task CreateProgramAsync(int channelId, CreateProgramRequest program);
    }
}
