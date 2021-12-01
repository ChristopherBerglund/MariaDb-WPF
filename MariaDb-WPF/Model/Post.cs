using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariaDb_WPF.Model
{
    public class Post
    {
        public int? postid { get; set; }
        public string User { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        [ForeignKey("discussionid")]
        public int discussionid { get; set; }
        public Discussion? Discussion { get; set; }
    }
}
