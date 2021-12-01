using System;

namespace MariaDb_WPF.Model
{
    public class Discussion
    {
        public int? discussionid { get; set; }
        public string headline { get; set; }
        public string discussiontext { get; set; }
        public string user { get; set; }
        public DateTime createddate { get; set; }
    }
}