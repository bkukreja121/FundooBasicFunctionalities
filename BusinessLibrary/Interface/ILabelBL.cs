using CommonLayer.Model.LabelModel;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface ILabelBL
    {
        bool AddLabel(AddLabel addLabel, long userId, int Id);
        bool EditLabel(EditLabel editLabelModel, long labelId);
        Label Get(long labelId);
        bool DeleteLabel(Label label);
        IEnumerable<LabelModel> DisplayLabel(long userId);
    }
}