using System.ComponentModel.DataAnnotations;

namespace CalendarApp.Models
{
    public class Event
    {
        public int Id { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Title { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
    }


}
