using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model.NotesModels
{
    public class AddNotesModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Message { get; set; }
   
        public string Image { get; set; }
        [Required]
        public string Color { get; set; }

        [Required]
        public bool IsPin { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime AddReminder { get; set; }

        [Required]
        public int UserId { get; set; }     /// foreign key..
        [Required]
        public bool IsArchive { get; set; }
        [Required]
        public bool IsNote { get; set; }
        [Required]
        public bool IsTrash { get; set; }
    }
}
