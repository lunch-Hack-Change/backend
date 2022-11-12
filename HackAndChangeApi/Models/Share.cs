using System.ComponentModel.DataAnnotations;

namespace HackAndChangeApi.Models
{
    public class Share
    {
        [Key]
        public int ShareId { get; set; }
        [Required]
        public string Name { get; set; }
        public int MokeCost { get; set; }
        [Required]
        public string Img { get; set; }
        public int MokePercent { get; set; }
    }
}
