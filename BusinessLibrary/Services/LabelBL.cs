using BusinessLayer.Interface;
using CommonLayer.Model.LabelModel;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class LabelBL : ILabelBL
    {
        ILabelRL _labelRL;
        public LabelBL(ILabelRL labelRL)
        {
            _labelRL = labelRL;
        }

        public bool AddLabel(AddLabel addLabel, long userId)
        {
            try
            {
                return this._labelRL.AddLabel(addLabel, userId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool DeleteLabel(Label label)
        {
            try
            {
                return this._labelRL.DeleteLabel(label);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<Label> DisplayLabel()
        {
            try
            {
                return this._labelRL.DisplayLabel();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool EditLabel(EditLabel editLabelModel, long labelId)
        {
            try
            {
                return this._labelRL.EditLabel(editLabelModel, labelId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Label Get(long labelId)
        {
            try
            {
                return this._labelRL.Get(labelId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}