using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scripture.Models
{
    public class Scripture
    {
        public int Id { get; set; }
        public string? Book { get; set; }
        public string? Chapter { get; set; }
        public string? Verse { get; set; }

        [Display(Name = "Scripture")]
        public string Reference
        {
            get
            {
                return Book + " " + Chapter + ":" + Verse;
            }
        }
        public string? Notes { get; set; }
        [Display(Name = "Entry Date")]
        [DataType(DataType.Date)]
        public DateTime EntryDate { get; set; }
    }
}

