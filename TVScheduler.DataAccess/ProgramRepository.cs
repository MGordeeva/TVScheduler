using Dapper;
using TVScheduler.DataAccess.Dto;
using TVScheduler.DataAccess.Helpers;

namespace TVScheduler.DataAccess
{
    public class ProgramRepository : IProgramRepository
    {
        private readonly IConnectionProvider _connectionProvider;

        public ProgramRepository(IConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public async Task CreateProgramAsync(int channelId, Program program)
        {
            using var connection = _connectionProvider.GetConnection();
            var sql = $"INSERT INTO {Constants.ProgramsTableName} " +
                          $"({Constants.ProgramsTableChannelIdColumn}, " +
                          $"{Constants.ProgramsTableNameColumn}, " +
                          $"{Constants.ProgramsTableDescriptionColumn}, " +
                          $"{Constants.ProgramsTableStartTimeColumn}, " +
                          $"{Constants.ProgramsTableEndTimeColumn}) " +
                      $"VALUES(@ChannelId, @Name, @Description, @StartTime, @EndTime)";
            await connection.ExecuteAsync(sql,
                new
                {
                    ChannelId = channelId,
                    program.Name,
                    program.Description,
                    program.StartTime,
                    program.EndTime,
                });
        }

        public async Task DeleteProgramAsync(int channelId, int programId)
        {
            using var connection = _connectionProvider.GetConnection();
            var sql = $"DELETE FROM {Constants.ProgramsTableName} " +
                      $"WHERE {Constants.ProgramsTableChannelIdColumn} = @ChannelId " +
                      $"AND {Constants.ProgramsTableIdColumn} = @id";
            await connection.ExecuteAsync(sql, new { ChannelId = channelId, Id = programId });
        }

        public async Task<Program?> GetProgramByIdAsync(int channelId, int id)
        {
            using var connection = _connectionProvider.GetConnection();
            var sql = $"SELECT * FROM {Constants.ProgramsTableName} " +
                      $"WHERE {Constants.ProgramsTableChannelIdColumn} = @channelId " +
                      $"AND {Constants.ProgramsTableIdColumn} = @id";
            var result = await connection.QueryAsync<Program?>(sql, new { channelId, id });

            return result?.FirstOrDefault();
        }

        public async Task<IEnumerable<Program>> GetProgramsByChannelAsync(int channelId, DateTime? startTime, DateTime? endTime)
        {
            using var connection = _connectionProvider.GetConnection();
            var sql = $"SELECT * FROM {Constants.ProgramsTableName} " +
                      $"WHERE {Constants.ProgramsTableChannelIdColumn} = @channelId " +
                      $"AND (@startTime IS NULL OR {Constants.ProgramsTableStartTimeColumn} = @startTime) " +
                      $"AND (@endTime IS NULL OR {Constants.ProgramsTableEndTimeColumn} = @endTime)";
            return await connection.QueryAsync<Program>(sql, new { channelId, startTime, endTime });
        }
    }
}