using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace RepositoryLayer.Entity
{
    
   public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserId { get; set; }   
        public string FirstName { get; set; }    
        public string LastName { get; set; }       
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime  CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

      //public virtual ICollection<Notes> Notes { get; set; }

        public IList<Collaboration> Collaborations { get; set; }

        public IList<Label> Labels { get; set; }


    }
}
