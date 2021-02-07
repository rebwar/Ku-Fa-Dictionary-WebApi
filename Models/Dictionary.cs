using System.ComponentModel.DataAnnotations;

namespace Ku_Fa_Dictionary.Models
{
    public class Dictionary
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string Kurdish { get; set; }
        [Required]
         [MaxLength(60)]
        public string Farsi { get; set; }

    }
}