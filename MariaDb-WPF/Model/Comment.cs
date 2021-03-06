using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariaDb_WPF.Model
{
    public class Comment
    {
        public int? commentid { get; set; }

        public string user { get; set; }

        public DateTime date { get; set; } = DateTime.Now;
        public string comment_text { get; set; }
        [ForeignKey("postid")]
        public int postid { get; set; }
        public Post? post { get; set; }
    }
}
