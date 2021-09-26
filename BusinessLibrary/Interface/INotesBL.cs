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

        IEnumerable<Notes> GetAll();
    }
}