using System;
using System.ComponentModel.DataAnnotations;

namespace FinalTest413.Models
{
    public class Quote
    {
        [Key]
        [Required]
        public int QuoteID { get; set; }
        [Required]
        public string QuoteText { get; set; }
        [Required]
        public string Author { get; set; }
        public string Date { get; set; }
        public string Subject { get; set; }
        public string Citation { get; set; }
    }
}
