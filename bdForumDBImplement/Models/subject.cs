using System;
using System.Collections.Generic;

namespace bdForumDBImplement.Models
{
    public partial class subject
    {
        public subject()
        {
            Message = new HashSet<applicants>();
        }

        public string Name { get; set; }
        public int Numberofvisitors { get; set; }
        public int Numberofmessages { get; set; }

        public virtual ICollection<applicants> Message { get; set; }
    }
}
