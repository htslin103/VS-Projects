namespace DigitalLibraryApplication.Models
{
    public class Audiobook
    {
        public Guid Id { get; set; }
        public Author Author { get; set; }
        public Publisher Publisher { get; set; }    
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public Author Narator { get; set; }

        public string Summary { get; set; }
    }
}
