using CommonLayer.Model.LabelModel;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class LabelRL : ILabelRL
    {
        readonly UserContext _userContext;
        IConfiguration _configuration;
        public LabelRL(UserContext context, IConfiguration configuration)
        {
            _userContext = context;
            _configuration = configuration;
        }

        public bool AddLabel(AddLabel addLabel, long userId, int Id)
        {
            Label labelEntity = new Label();
            labelEntity.LabelId = addLabel.LabelId;
            labelEntity.LabelName = addLabel.LabelName;
            labelEntity.UserId = userId;
            labelEntity.Id = Id;
            labelEntity.CreatedDateTime = DateTime.Now;
            labelEntity.ModifiedDateTime = DateTime.Now;
            _userContext.Labels.Add(labelEntity);
            int result = _userContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteLabel(Label label)
        {
            try
            {
                _userContext.Labels.Remove(label);
                var result = _userContext.SaveChanges();

                if (result > 0)
                {
                    return true;

                }

                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

       

        public IEnumerable<LabelModel> DisplayLabel(long userId)
        {
            try
            {
                //List<Label> label = _userContext.Labels.Where(x => x.UserId == userId ).ToList();

                //return label;

                var query = _userContext.Labels.Join(_userContext.Notes, label => label.Id, notes => notes.Id, (label, notes) => new LabelModel
                {
                    LabelId = label.LabelId,
                    LabelName = label.LabelName,
                    UserId = userId,
                    Id = label.Id,
                    Title = notes.Title,
                    Message = notes.Message,
                    Image = notes.Image,
                    Color = notes.Color

                }).ToList();
                return query;
                //return _userContext.Labels.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EditLabel(EditLabel editLabelModel, long labelId)
        {
            Label label = _userContext.Labels.FirstOrDefault(e => e.LabelId == labelId);
            label.LabelName = editLabelModel.LabelName;
            label.ModifiedDateTime = DateTime.Now;
            _userContext.Labels.Update(label);
            int result = _userContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Label Get(long labelId)
        {
            try
            {
                return _userContext.Labels.FirstOrDefault(e => e.LabelId == labelId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}