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
       
        // GET: api/user
        [HttpGet]
        public IActionResult Display()
        {

            IEnumerable<Notes> notes = _notesBL.Display();
            return Ok(notes);
        }


     
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
   
        [HttpPut("{Id}/Archive")]
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
       
        //ISpin
        [HttpPut("{Id}/Pin")]
        public IActionResult IsPin(long Id)
        {
           
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
       
        //IsTrash
        [HttpPut("{Id}/Trash")]
        public IActionResult IsTrash(long Id)
        {
           
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

     
        //Edit Notes
        [HttpPut("{Id}")]
        public IActionResult EditNotes(EditNotesModel editNotesModel,long Id)
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
       
        [HttpPut("{Id}/Reminder")]
        public IActionResult AddReminder( AddReminderModel addReminderModel,long Id)
        {
            try
            {  
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

     
        // Change Color
        [HttpPut("{Id}/color")]
        public IActionResult ChangeColor( ChangeColorModel changeColorModel,long Id)
        {
            try
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