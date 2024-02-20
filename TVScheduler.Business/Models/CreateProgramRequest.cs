using System.ComponentModel.DataAnnotations;
using TVScheduler.Business.Helpers;

namespace TVScheduler.WebApi.Models
{
    public class CreateProgramRequest
    {
        [Required]
        [StringLength(50)]
        public required string Name { get; set; }

        [StringLength(50)]
        public string? Description { get; set; }

        [Required]
        [DateLessThan(nameof(EndTime), ErrorMessage = "Start time should be less than end time")]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }
    }
}
