using System.ComponentModel.DataAnnotations;
namespace Movies.Models
{
    public class Producer
    {
        [Key]
        public int Prod_Id { get; set; }
        public string? ProdName { get; set; }
        public string? Bio { get; set; }
        public DateTime DOB { get; set; }
        public string? Gender { get; set; }
        public string? Company { get; set; }
    }
}
