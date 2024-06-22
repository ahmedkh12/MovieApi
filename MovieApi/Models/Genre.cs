using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApi.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required,MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
