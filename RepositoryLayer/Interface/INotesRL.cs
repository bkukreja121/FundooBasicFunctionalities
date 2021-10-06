using CommonLayer.Model.NotesModels;
using CommonLayer.Model.NotesModels.Response;
using Microsoft.AspNetCore.Http;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface INotesRL
    {
        bool CreateNotes(AddNotesModel model, long userId);

        IEnumerable<Notes> Display(long userId);
        Notes Get(long Id);
        bool Delete(Notes notes,long userId);
        bool EditNotes(EditNotesModel editNotesModel, long Id,long userId);

        bool AddReminder(long Id, AddReminderModel addReminderModel,long userId);
        bool ArchiveNote(long Id,long userId);

        List<CollabResponse> GetAllCollabs(long UserId);

        bool ChangeColor(long Id, ChangeColorModel changeColorModel, long userId);
        bool IsPin(long id,long userId);
        bool IsTrash(long id,long userId);

        bool UploadImage(IFormFile file, int Id,long userId);

        bool AddCollaborators(int Id, AddCollaboratorResponse collaborator,long userId);
    }

}