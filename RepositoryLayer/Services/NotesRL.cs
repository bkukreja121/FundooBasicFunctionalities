using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using CommonLayer.Model.NotesModels;
using CommonLayer.Model.NotesModels.Response;
using Microsoft.AspNetCore.Http;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class NotesRL : INotesRL
    {
        readonly UserContext _userContext;
        public NotesRL(UserContext context)
        {
            _userContext = context;
        }


        public List<CollabResponse> GetAllCollabs(long UserId)
        {
            List<CollabResponse> allCollabs = _userContext.Collaborations.Where(collab => collab.UserId == UserId).
                Select(collabs => new CollabResponse
                {
                    UserId = collabs.UserId,
                    NotesId = collabs.Id,
                    CollaboratorId = collabs.CollaborationId


                }).ToList();
            return allCollabs;
        }



        public bool CreateNotes(AddNotesModel model, long userId)
        {

            try
            {
                Notes notesEntity = new Notes();
                notesEntity.Id = model.Id;
                notesEntity.Title = model.Title;
                notesEntity.Message = model.Message;
                notesEntity.Image = model.Image;
                notesEntity.Color = model.Color;

                notesEntity.CreatedDate = DateTime.Now;
                notesEntity.ModifiedDate = DateTime.Now;
                notesEntity.AddReminder = model.AddReminder;
                notesEntity.UserId = userId;
                notesEntity.IsArchive = model.IsArchive;
                notesEntity.IsPin = model.IsPin;
                notesEntity.IsNote = model.IsNote;
                notesEntity.IsTrash = model.IsTrash;
                _userContext.Notes.Add(notesEntity);
                int result = _userContext.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Notes Get(long Id)
        {
            return _userContext.Notes.FirstOrDefault(e => e.Id == Id);
        }

        public IEnumerable<Notes> Display()
        {
            return _userContext.Notes.ToList();
        }

        public bool Delete(Notes notes)
        {
            try
            {
                _userContext.Notes.Remove(notes);
                var result = _userContext.SaveChanges();

                if (result > 0)
                {
                    return true;

                }

                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

      
            public bool EditNotes(EditNotesModel editNotesModel, long Id)
            {
                Notes notes = _userContext.Notes.FirstOrDefault(e => e.Id == Id);
                try
                {
                    notes.Title = editNotesModel.Title;
                    notes.Message = editNotesModel.Message;
                    notes.Image = editNotesModel.Image;
                    notes.Color = editNotesModel.Color;
                    notes.ModifiedDate = editNotesModel.ModifiedDate;
                    _userContext.Notes.Update(notes);
                    int result = _userContext.SaveChanges();
                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception ex)
                {
                    return false;
                }
            }

        public bool AddReminder(long Id, AddReminderModel addReminderModel)
        {
            try
            {
                Notes notes = _userContext.Notes.FirstOrDefault(e => e.Id == Id);
                notes.AddReminder = addReminderModel.AddReminder;
                notes.ModifiedDate = DateTime.Now;



                _userContext.Notes.Update(notes);
                int result = _userContext.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool ArchiveNote(long Id)
        {
            Notes notes = _userContext.Notes.FirstOrDefault(e => e.Id == Id);
            if (notes.IsArchive == false)
            {

                notes.IsArchive = true;

            }
            else
            {

                notes.IsArchive = false;

            }
            _userContext.Notes.Update(notes);
            int result = _userContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddCollaborators(int Id, AddCollaboratorResponse collaborator)
        {
            Collaboration collaboration = new Collaboration();
            collaboration.UserId = collaborator.UserId;
            collaboration.Id = Id;
            collaboration.CreatedAt = DateTime.Now;
            collaboration.CollaborationId = collaborator.CollaboratorId;
            _userContext.Collaborations.Add(collaboration);
            int result = _userContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [Obsolete]
        public bool UploadImage(IFormFile file, int Id)
        {
            try
            {
                Account account = new Account(
                    "selg",
                    "968789572864694",
                    "gefKxEXzG727bRz5mBN3bUww9gA");
                var Path = file.OpenReadStream();
                Cloudinary cloudinary = new Cloudinary(account);
                cloudinary.Api.Secure = true;

                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, Path)
                    //PublicId = "myfolder/mysubfolder/my_dog",
                    //Overwrite = true,
                    //NotificationUrl = "https://mysite.example.com/my_notification_endpoint"
                };
                var uploadResult = cloudinary.Upload(uploadParams);
                //string imageresult = uploadResult.Url.ToString();

                Notes notes = _userContext.Notes.FirstOrDefault(e => e.Id == Id);
                notes.Image = uploadResult.Url.ToString();
                _userContext.Notes.Update(notes);
                int result = _userContext.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public bool ChangeColor(long Id, ChangeColorModel changeColorModel)
            {
            try
            {
                Notes notes = _userContext.Notes.FirstOrDefault(e => e.Id == Id);
                notes.Color = changeColorModel.Color;


                _userContext.Notes.Update(notes);
                int result = _userContext.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            }

        public bool IsPin(long Id)
        {

            try
            {
                Notes notes = _userContext.Notes.FirstOrDefault(e => e.Id == Id);
                if (notes.IsPin == false)
                {

                    notes.IsPin = true;

                }
                else
                {

                    notes.IsPin = false;

                }
                _userContext.Notes.Update(notes);
                int result = _userContext.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception )
            {

                throw;
            }
        }

        public bool IsTrash(long Id)
        {

            try
            {
                Notes notes = _userContext.Notes.FirstOrDefault(e => e.Id == Id);
                if (notes.IsTrash == false)
                {

                    notes.IsTrash = true;

                }
                else
                {

                    notes.IsTrash = false;

                }
                _userContext.Notes.Update(notes);
                int result = _userContext.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
    }
   
    
