using System.ComponentModel.DataAnnotations;

namespace PexelStore.Models.DTO
{
    public class UpdateGameDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public IFormFile Poster { get; set; }
        [Required]
        public string Story { get; set; }
        [Required]
        public string Platform { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public Guid GenreId { get; set; }
    }
}
