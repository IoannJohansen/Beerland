using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class ProductionStatistic
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public double Target { get; set; }

        public double Produced { get; set; }
        [Required]
        public long BeerMarkId { get; set; }
        
        public BeerMark BeerMark { get; set; }
    }
}
