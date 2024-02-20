using Dapper;
using TVScheduler.DataAccess.Dto;
using TVScheduler.DataAccess.Helpers;

namespace TVScheduler.DataAccess
{
    public class ChannelRepository : IChannelRepository
    {
        private readonly IConnectionProvider _connectionProvider;

        public ChannelRepository(IConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public async Task<IEnumerable<Channel>> GetAllChannels()
        {
            using var connection = _connectionProvider.GetConnection();
            var sql = $"SELECT * FROM {Constants.ChannelsTableName}";
            return await connection.QueryAsync<Channel>(sql);
        }

        public async Task<Channel> GetChannelById(int id)
        {
            using var connection = _connectionProvider.GetConnection();
            var sql = $"SELECT * FROM {Constants.ChannelsTableName} WHERE {Constants.ChannelsTableIdColumn} = @id";
            return (await connection.QueryAsync<Channel>(sql, new { id })).FirstOrDefault();
        }

        public async Task CreateChannel(Channel channel)
        {
            using var connection = _connectionProvider.GetConnection();
            var sql = $"INSERT INTO {Constants.ChannelsTableName} ({Constants.ChannelsTableNameColumn}, {Constants.ProgramsTableDescriptionColumn}) " +
                      $"VALUES(@Name, @Description)";
            await connection.ExecuteAsync(sql, channel);
        }
    }
}