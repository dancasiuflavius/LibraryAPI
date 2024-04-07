using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookAPI.Books.Model
{
    [Table("books")]
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("title")]

        public string Title { get; set; }
        [Required]
        [Column("author")]

        public string Author { get; set; }
        [Required]
        [Column("category")]

        public string Category { get; set; }
        [Required]
        [Column("publish_date")]

        public DateTime PublishDate { get; set; }
    }
}
