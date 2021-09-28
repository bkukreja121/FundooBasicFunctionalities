using BusinessLayer.Interface;
using CommonLayer.Model.NotesModels;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        [HttpPost]
        public IActionResult CreateNotes(AddNotesModel model)
        {
            try
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
            catch (Exception ex)
            {

                return this.BadRequest(new { success = false, message = ex.Message });
            }
        }
        [Authorize]
        // GET: api/user
        [HttpGet]
        public IActionResult Display()
        {

            IEnumerable<Notes> notes = _notesBL.Display();
            return Ok(notes);
        }


        [Authorize]
        [HttpDelete("{Id}")]
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
       [Authorize]
        [HttpPut("{Id}/Archive")]
        public IActionResult ArchiveNote()
        {
            var Id = GetTokenId();
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
        [Authorize]
        //ISpin
        [HttpPut("{Id}/IsPin")]
        public IActionResult IsPin()
        {
            var Id = GetTokenId();
            var result = _notesBL.IsPin(Id);
            if (result == true)
            {
                return this.Ok(new { success = true, message = "Ispin function successfull" });
            }
            else
            {
                return this.BadRequest(new { success = false, message = "Ispin function unsuccessfull" });
            }
        }
        [Authorize]
        //IsTrash
        [HttpPut("{Id}")]
        public IActionResult IsTrash()
        {
            var Id = GetTokenId();
            var result = _notesBL.IsTrash(Id);
            if (result == true)
            {
                return this.Ok(new { success = true, message = "IsTrash function successfull" });
            }
            else
            {
                return this.BadRequest(new { success = false, message = "IsTrash function unsuccessfull" });
            }
        }

        [Authorize]
        //Edit Notes
        [HttpPut("{Id}")]
        public IActionResult EditNotes(EditNotesModel editNotesModel)
        {

            var Id = GetTokenId();
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
        [Authorize]
        [HttpPut("{Id}")]
        public IActionResult AddReminder( AddReminderModel addReminderModel)
        {
            try
            {
                var Id = GetTokenId();
                var result = _notesBL.AddReminder(Id, addReminderModel);
                if (result == true)
                {
                    return this.Ok(new { success = true, message = "Reminder Added Successfully " });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Reminder adding unsuccessfull" });
                }
            }
            catch (Exception ex)
            {

                return this.BadRequest(new { success = false, message = ex.Message });
            }
        }

      [Authorize]
        // Change Color
        [HttpPut("{Id}/color")]
        public IActionResult ChangeColor( ChangeColorModel changeColorModel)
        {
            try
            {
                var Id = GetTokenId();
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
            catch (Exception ex)
            {

                return this.BadRequest(new { success = false, message = ex.Message }); 
            }
        }
        public long GetTokenId()
        {
            return Convert.ToInt64(User.FindFirst("Id").Value);
        }

    }


}