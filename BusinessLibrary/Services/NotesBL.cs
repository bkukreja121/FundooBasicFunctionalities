using BusinessLayer.Interface;
using CommonLayer.Model.NotesModels;
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

        public bool CreateNotes(AddNotesModel model)
        {
            return _notesRL.CreateNotes(model);
        }

        public IEnumerable<Notes> GetAll()
        {
            try
            {
                return this._notesRL.GetAll();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}