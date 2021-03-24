using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesApp.Models
{
    public class QuoteItem
    {
        [Key]
        [Required]
        public int QuoteID { get; set; }
        [Required]
        public string Quote { get; set; }
        [Required]
        public string QuoteAuthor { get; set; }
        [Required]
        public DateTime QuoteDate { get; set; }
        public string QuoteSubject { get; set; }
        public string QuoteCitation { get; set; }
    }
}
