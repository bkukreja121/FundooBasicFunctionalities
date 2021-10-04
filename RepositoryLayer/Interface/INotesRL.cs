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

        IEnumerable<Notes> Display();
        Notes Get(long Id);
        bool Delete(Notes notes);
        bool EditNotes(EditNotesModel editNotesModel, long Id);

        bool AddReminder(long Id, AddReminderModel addReminderModel);
        bool ArchiveNote(long Id);

        List<CollabResponse> GetAllCollabs(long UserId);

        bool ChangeColor(long Id, ChangeColorModel changeColorModel);
        bool IsPin(long id);
        bool IsTrash(long id);

        bool UploadImage(IFormFile file, int Id);

        bool AddCollaborators(int Id, AddCollaboratorResponse collaborator);
    }

}