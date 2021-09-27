using BusinessLayer.Interface;
using CommonLayer.Model.NotesModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{

    [Route("api/notes")]
    [ApiController]
    public class NotesController : ControllerBase
    {


        public static IConfiguration _config;
        private INotesBL _notesBL;
        public NotesController(INotesBL notesBL, IConfiguration config)
        {
            _notesBL = notesBL;
            _config = config;
        }

        [HttpPost("createNotes")]
        public IActionResult CreateNotes(AddNotesModel model)
        {
            if (model == null)
            {
                return BadRequest("notes is empty.");
            }
            var result = _notesBL.CreateNotes(model);
            if (result == true)
            {
                return this.Ok(new { success = true, message = "Note Created Successfully" });
            }
            else
            {
                return this.BadRequest();
            }
        }

        // GET: api/user
        [HttpGet("DisplayNotes")]
        public IActionResult Display()
        {
            IEnumerable<Notes> notes = _notesBL.Display();
            return Ok(notes);
        }



        [HttpDelete("Delete/{Id}")]
        public IActionResult DeleteNotes(long Id)
        {
            Notes notes = _notesBL.Get(Id);
            if (notes == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }
            var result = _notesBL.Delete(notes);

            if (result == true)
            {
                return this.Ok(new { success = true, message = "Notes Deleted Successfully" });
            }
            else
            {
                return this.BadRequest(new { success = false, message = "Note Deletion Failed" });
            }




        }

        [HttpPut("archive/{Id}")]
        public IActionResult ArchiveNote(long Id)
        {
            var result = _notesBL.ArchiveNote( Id);
            if (result == true)
            {
                return this.Ok(new { success = true, message = "IsArchive function successfull" });
            }
            else
            {
                return this.BadRequest(new { success = false, message = "IsArchive function unsuccessfull" });
            }
        }

        //Edit Notes
        [HttpPut("Edit/{Id}")]
        public IActionResult EditNotes(EditNotesModel editNotesModel, long Id)
        {
           
            var result = _notesBL.EditNotes(editNotesModel, Id);
            if (result == true)
            {
                return this.Ok(new { success = true, message = "Notes Edited Successfully" });
            }
            else
            {
                return this.BadRequest(new { success = false, message = "Note Edition Failed" });
            }
        }

        // Change Color
        [HttpPut("color/{Id}")]
        public IActionResult ChangeColor(long Id, ChangeColorModel changeColorModel)
        {
            var result = _notesBL.ChangeColor(Id, changeColorModel);
            if (result == true)
            {
                return this.Ok(new { success = true, message = "Color change successfull" });
            }
            else
            {
                return this.BadRequest(new { success = false, message = "Color Change unsuccessfull" });
            }
        }

    }


}