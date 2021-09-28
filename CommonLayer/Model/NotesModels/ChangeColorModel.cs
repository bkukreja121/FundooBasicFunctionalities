using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model.NotesModels
{
    public class ChangeColorModel
    {
        [Required]
        public string Color { get; set; }
    }
}
