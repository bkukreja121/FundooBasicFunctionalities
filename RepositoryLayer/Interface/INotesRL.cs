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
        bool ArchiveNote(long Id);
    }
}