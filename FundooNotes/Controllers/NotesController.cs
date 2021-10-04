using BusinessLayer.Interface;
using CommonLayer.Model.NotesModels;
using CommonLayer.Model.NotesModels.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
            long userId = GetTokenId();
            try
            {

                if (model == null)
                {
                    return BadRequest("notes is empty.");
                }
                var result = _notesBL.CreateNotes(model,userId);
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

        [HttpPost("{Id}/AddCollaborator")]
        public IActionResult AddCollaborators(int Id, AddCollaboratorResponse collaborator)
        {
            if (collaborator.CollaboratorId != 0 && Id != 0)
            {
                var result = _notesBL.AddCollaborators(Id, collaborator);
                if (result == true)
                {
                    return this.Ok(new { success = true, message = "Collaborator Added Successfully " });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Collaborator adding unsuccessfull" });
                }
            }
            else
            {
                return this.BadRequest(new { success = false, message = "Collaborator adding unsuccessfull" });
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
        private long GetTokenId()
        {
            return Convert.ToInt64(User.FindFirst("Id").Value);
        }

        [HttpPost("upload")]
        public IActionResult Upload(IFormFile file)
        {
            return Ok();
        }
        [HttpPut("{Id}/upload")]
        public IActionResult UploadImage(IFormFile file, int Id)
        {
            try
            {

                var result = _notesBL.UploadImage(file, Id);
                if (result == true)
                {
                    return this.Ok(new { success = true, message = "Image Added Successfully " });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Image adding unsuccessfull" });
                }
            }
            catch (Exception ex)
            {

                return this.BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpGet("Collabs")]
        public ActionResult GetAllCollabs()
        {
            try
            {
                long UserId = GetTokenId();
                var CollabList = _notesBL.GetAllCollabs(UserId);
                if (CollabList.Count > 0)
                {

                    return Ok(new { Success = true, Message = $" You have {CollabList.Count} collabs", Collabs = CollabList });
                }
                return Ok(new { Success = true, Message = $" Collab list is Empty" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, ex.Message });
            }
        }
    }


}