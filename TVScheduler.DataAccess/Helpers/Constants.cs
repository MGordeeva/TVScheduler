namespace TVScheduler.DataAccess.Helpers
{
    internal static class Constants
    {
        public const string ChannelsTableName = "Channels";
        public const string ChannelsTableNameColumn = "Name";
        public const string ChannelsTableIdColumn = "Id";
        public const string ChannelsTableDecsriptionColumn = "Description";

        public const string ProgramsTableName = "Programs";
        public const string ProgramsTableNameColumn = "Name";
        public const string ProgramsTableIdColumn = "Id";
        public const string ProgramsTableChannelIdColumn = "ChannelId";
        public const string ProgramsTableDescriptionColumn = "Description";
        public const string ProgramsTableStartTimeColumn = "StartTime";
        public const string ProgramsTableEndTimeColumn = "EndTime";
    }
}
