namespace PexelStore.Models.Domain
{
    public class Genre
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<Games> games { get; set; }
    }
}
