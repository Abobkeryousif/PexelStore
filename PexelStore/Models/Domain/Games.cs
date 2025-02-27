using System.ComponentModel.DataAnnotations;

namespace PexelStore.Models.Domain
{
    public class Games
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public byte[] Poster { get; set; }
        [Required]
        public string Story { get; set; }
        [Required]
        public string Platform { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public Guid GenreId { get; set; }
        public List<Genre> genres { get; set; }
        

    }
}
