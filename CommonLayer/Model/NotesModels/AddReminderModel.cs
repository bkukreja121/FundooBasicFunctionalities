namespace CommonLayer.Model.NotesModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    public class AddReminderModel
    {

        [Required]
        public DateTime AddReminder { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }
    }
}
