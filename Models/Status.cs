using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApplication1.Models
{
    public class Status
    {
        [Key]
        public int Statuc_ID { get; set; }
        [Required]
        [DefaultValue("Start")]
        [StringRange(typeof(ListOfStatuces),ErrorMessage = "IncorrectStatuc")]
        public string? Statuc_name { get; set; }
    }
}
