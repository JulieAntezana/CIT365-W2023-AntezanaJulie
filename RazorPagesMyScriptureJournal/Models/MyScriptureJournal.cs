using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMyScriptureJournal.Models
{
    public class MyScriptureJournal
    {
        public int Id { get; set; }
        public string? Book { get; set; }
        public string? Chapter { get; set; }
        public string? Verse { get; set; }

        [Display(Name = "Scripture")]
        public string Scripture
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
