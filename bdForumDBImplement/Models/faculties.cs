using System;
using System.Collections.Generic;

namespace bdForumDBImplement.Models
{
    public partial class faculties
    {
        public string Visitorlogin { get; set; }
        public int Messageid { get; set; }

        public virtual applicants Message { get; set; }
        public virtual university VisitorloginNavigation { get; set; }
    }
}
