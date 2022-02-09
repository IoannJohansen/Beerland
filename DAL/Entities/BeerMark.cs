using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class BeerMark
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
