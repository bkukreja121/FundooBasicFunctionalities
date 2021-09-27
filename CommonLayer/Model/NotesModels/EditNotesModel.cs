using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model.NotesModels
{
    public class EditNotesModel
    {

        public string Title { get; set; }

        public string Message { get; set; }

        public string Image { get; set; }

        public string Color { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
