using CommonLayer.Model.NotesModels;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface INotesBL
    {
        bool CreateNotes(AddNotesModel model);

        IEnumerable<Notes> Display();
        Notes Get(long Id);
        bool Delete(Notes notes);
        bool EditNotes(EditNotesModel editNotesModel, long Id);
        bool ArchiveNote(long Id);

        bool ChangeColor(long Id, ChangeColorModel changeColorModel);
    }
}