using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Task_
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set;}
        [Required]
        public string? Description { get; set;}
        [Required]
        [ForeignKey("Status")]
        public int Statuc_ID { get; set;}
    }
}
