using System.ComponentModel.DataAnnotations;
namespace Movies.Models
{
    public class MovieDetails
    {
        [Key]
        public int Id { get; set; }
        public string? MovieName { get; set; }
        public DateTime ReleaseDate { get; set; }
        //public string? Info { get; set; }
        //public int Actor_id { get; set; }
        public string? Actor_name { get; set; }
        //public int Producer_Id{ get; set;}
        public string? Producer_Name { get; set; }
    }
}
