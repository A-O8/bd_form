using System;
using System.Collections.Generic;

namespace bdForumDBImplement.Models
{
    public partial class applicants
    {
        public applicants()
        {
            Like = new HashSet<faculties>();
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }
        public string Visitorlogin { get; set; }
        public string Topicname { get; set; }

        public virtual subject TopicnameNavigation { get; set; }
        public virtual university VisitorloginNavigation { get; set; }
        public virtual ICollection<faculties> Like { get; set; }
    }
}
