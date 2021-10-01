using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Entity
{
    
        public class Collaboration
        {
            public long UserId { get; set; }
            public User User { get; set; }
            public int Id { get; set; }
            public Notes Notes { get; set; }

            public DateTime CreatedAt { get; set; }

             public int CollaborationId { get; set; }
        }


    
}
