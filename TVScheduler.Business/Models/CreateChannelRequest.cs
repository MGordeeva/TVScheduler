using System.ComponentModel.DataAnnotations;

namespace TVScheduler.WebApi.Models
{
    public class CreateChannelRequest
    {
        [Required]
        public required string Name { get; set; }

        public string? Description { get; set; }
    }
}
