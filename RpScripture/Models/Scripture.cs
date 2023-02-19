using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RpScripture.Models
{
    public class Scripture
    { 
        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9""'\s-]*$")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Book { get; set; }

        [RegularExpression(@"^[0-9]+$")]
        [StringLength(3)]
        [Required]
        public string? Chapter { get; set; }

        [RegularExpression(@"^[0-9]+$")]
        [StringLength(3)]
        [Required]
        public string? Verse { get; set; }

        [Display(Name = "Scripture")]
        public string Reference
        {
            get
            {
                return Book + " " + Chapter + ":" + Verse;
            }
        }
        [StringLength(3000, MinimumLength = 3)]
        [Required]
        public string? Notes { get; set; }
        [Display(Name = "Entry Date")]
        [DataType(DataType.Date)]
        public DateTime EntryDate { get; set; }
    }
}
