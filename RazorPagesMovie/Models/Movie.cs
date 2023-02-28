using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models
{
    public class Movie
    {
        //Primary key
        public int Id { get; set; } 
        public string? Title { get; set; } //? means nullable

        [DataType(DataType.Date)] //with DataType.Date, only date displayed, not time information 
        public DateTime RelaseDate { get; set; }
        public string? Genre { get; set; }
        public decimal Price { get; set; }
    }
}
