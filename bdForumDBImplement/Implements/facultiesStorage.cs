using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bdForumBusinessLogic.BindingModels;
using bdForumBusinessLogic.Interfaces;
using bdForumBusinessLogic.ViewModels;
using bdForumDBImplement.DatabaseContext;
using bdForumDBImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace bdForumDBImplement.Implements
{
    public class facultiesStorage : IfacultiesStorage
    {
        public LikeViewModel GetElement(facultiesBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ForumDatabase())
            {
                var like = context.Like.FirstOrDefault
                   (rec => rec.Visitorlogin == model.LoginUser && rec.Messageid == model.IdMessage);
                return like != null ? new LikeViewModel
                {
                    LoginUser = like.Visitorlogin,
                    IdMessage = like.Messageid
                } :
                null;
            }
        }

        public List<LikeViewModel> GetFilteredList(facultiesBindingModel model)
        {
            using (var context = new ForumDatabase())
            {
                return context.Like.Where(rec => rec.Messageid == model.IdMessage).Select(rec => new LikeViewModel
                {
                    LoginUser = rec.Visitorlogin,
                    IdMessage = rec.Messageid
                }).ToList();
            }
        }

        public List<LikeViewModel> GetFullList()
        {
            using (var context = new ForumDatabase())
            {
                return context.Like.Select(rec => new LikeViewModel
                {
                    LoginUser = rec.Visitorlogin,
                    IdMessage = rec.Messageid
                }).ToList();
            }
        }

        public void Insert(facultiesBindingModel model)
        {
            using (var context = new ForumDatabase())
            {
                context.Like.Add(CreateModel(model, new Models.faculties()));
                context.SaveChanges();
            }
        }
        public void Update(facultiesBindingModel model)
        {
            using (var context = new ForumDatabase())
            {
                var element = context.Like.FirstOrDefault(rec => rec.Visitorlogin == model.LoginUser && rec.Messageid == model.IdMessage);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element); 
                context.SaveChanges();
            }
        }
        public void Delete(facultiesBindingModel model)
        {
            using (var context = new ForumDatabase())
            {
                var element = context.Like.FirstOrDefault(rec => rec.Visitorlogin == model.LoginUser && rec.Messageid == model.IdMessage);
                if (element != null)
                {
                    context.Like.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Models.faculties CreateModel(facultiesBindingModel model, Models.faculties like)
        {
            like.Visitorlogin = model.LoginUser;
            like.Messageid = model.IdMessage;
            return like;
        }
    }
}
