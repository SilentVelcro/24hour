using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room11Note.Models
{
    public class CommentDetail
    {
        public int CommentId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public Guid Author { get; set; }

        public virtual List<string> Replies { get; set; }
    }
}
