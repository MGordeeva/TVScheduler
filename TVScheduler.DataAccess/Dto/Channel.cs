namespace TVScheduler.DataAccess.Dto
{
    public class Channel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}