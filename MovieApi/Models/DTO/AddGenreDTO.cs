using System.ComponentModel.DataAnnotations;

namespace MovieApi.Models.DTO
{
    public class AddGenreDTO
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
