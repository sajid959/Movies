using System.ComponentModel.DataAnnotations;
namespace Movies.Models
{
    public class Actor
    {
        [Key]
        public int Actor_Id { get; set; }
        public string? ActorName { get; set; }
        public string? Bio { get; set; }
        public DateTime DOB { get; set; }
        public string? Gender { get; set; }
        public int Movie_id { get; set; }
    }
}
