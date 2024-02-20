using TVScheduler.DataAccess.Dto;

namespace TVScheduler.DataAccess
{
    public interface IProgramRepository
    {
        Task<IEnumerable<Program>> GetProgramsByChannelAsync(int channelId, DateTime? startTime, DateTime? endTime);
        Task<Program?> GetProgramByIdAsync(int channelId, int programId);
        Task CreateProgramAsync(int channelId, Program program);
        Task DeleteProgramAsync(int channelId, int programId);
    }
}
