using BusinessLayer.Interface;
using CommonLayer.Model.NotesModels;
using CommonLayer.Model.NotesModels.Response;
using Microsoft.AspNetCore.Http;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class NotesBL : INotesBL
    {
        private INotesRL _notesRL;
        public NotesBL(INotesRL notesRL)
        {
            this._notesRL = notesRL;
        }

        public bool CreateNotes(AddNotesModel model, long userId)
        {
            return _notesRL.CreateNotes(model, userId);
        }

        public Notes Get(long Id)
        {
            try
            {
                return this._notesRL.Get(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<CollabResponse> GetAllCollabs(long UserId)
        {
            return _notesRL.GetAllCollabs(UserId);
        }
        public IEnumerable<Notes> Display(long userId)
        {
            try
            {
                return this._notesRL.Display(userId);
            }
            catch (Exception )
            {
                throw;
            }
        }

        public bool Delete(Notes notes,long userId )
        {
            try
            {
                return this._notesRL.Delete(notes,userId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool AddReminder(long Id, AddReminderModel addReminderModel,long userId)
        {
            try
            {
                return this._notesRL.AddReminder(Id, addReminderModel,userId);
            }
            catch (Exception )
            {
                throw;
            }
        }

        public bool AddCollaborators(int Id, AddCollaboratorResponse collaborator,long userId)
        {

            try
            {
                return this._notesRL.AddCollaborators(Id, collaborator,userId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool UploadImage(IFormFile file, int Id,long userId)
        {
            try
            {
                return this._notesRL.UploadImage(file, Id,userId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool EditNotes(EditNotesModel editNotesModel, long Id, long userId)
            {
                try
                {
                    return this._notesRL.EditNotes(editNotesModel, Id, userId);
                }
                catch (Exception )
                {
                    throw;
                }
            }

        public bool ArchiveNote(long Id,long userId)
        {
            try
            {
                return this._notesRL.ArchiveNote(Id,userId);
            }
            catch (Exception )
            {
                throw;
            }
        }
        //ISPin Method
        public bool IsPin(long Id, long userId)
        {
            try
            {
                return this._notesRL.IsPin(Id, userId);
            }
            catch (Exception )
            {
                throw;
            }
        }

        //isTrash
        public bool IsTrash(long Id, long userId)
        {
            try
            {
                return this._notesRL.IsTrash(Id, userId);
            }
            catch (Exception )
            {
                throw;
            }
        }
        public bool ChangeColor(long Id, ChangeColorModel changeColorModel, long userId)
        {
            try
            {
                return this._notesRL.ChangeColor(Id, changeColorModel, userId);
            }
            catch (Exception )
            {
                throw;
            }
        }
    }
    
}