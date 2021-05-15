using System;
using System.Collections.Generic;

namespace bdForumDBImplement.Models
{
    public partial class university
    {
        public university()
        {
            Like = new HashSet<faculties>();
            Message = new HashSet<applicants>();
        }

        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public int Countmessages { get; set; }
        public int Decency { get; set; }
        public int TotalTime { get; set; }

        public virtual ICollection<faculties> Like { get; set; }
        public virtual ICollection<applicants> Message { get; set; }
    }
}
