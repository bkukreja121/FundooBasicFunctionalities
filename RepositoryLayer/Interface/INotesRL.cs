using CommonLayer.Model.NotesModels;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface INotesRL
    {
        bool CreateNotes(AddNotesModel model);

        IEnumerable<Notes> Display();
        Notes Get(long Id);
        bool Delete(Notes notes);
        bool EditNotes(EditNotesModel editNotesModel, long Id);

        bool AddReminder(long Id, AddReminderModel addReminderModel);
        bool ArchiveNote(long Id);

        bool ChangeColor(long Id, ChangeColorModel changeColorModel);
        bool IsPin(long id);
        bool IsTrash(long id);
    }
}