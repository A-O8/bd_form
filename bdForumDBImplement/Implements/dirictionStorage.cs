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
    public class dirictionStorage : IdirictionStorage
    {
        public ModeratorViewModel GetElement(dirictionBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ForumDatabase())
            {
                var moder = context.Moderator.FirstOrDefault(rec => rec.Login == model.LoginUser && rec.Password == model.Password);
                return moder != null ? new ModeratorViewModel
                {
                    LoginUser = moder.Login,
                    Password = moder.Password,
                    Email = moder.Email,
                    TotalTime = moder.TotalTime,
                    AmountOfHelp = moder.Amountofhelp
                } :
                null;
            }
        }

        public List<ModeratorViewModel> GetFilteredList(dirictionBindingModel model)
        {
            throw new NotImplementedException();
        }

        public List<ModeratorViewModel> GetFullList()
        {
            using (var context = new ForumDatabase())
            {
                return context.Moderator
                    .Select(rec => new ModeratorViewModel
                    {
                        LoginUser = rec.Login,
                        Password = rec.Password,
                        Email = rec.Email,
                        TotalTime = rec.TotalTime,
                        AmountOfHelp = rec.Amountofhelp
                    }).ToList();
            }
        }

        public void Insert(dirictionBindingModel model)
        {
            using (var context = new ForumDatabase())
            {
                diriction moder = CreateModel(model, new diriction());
                context.Moderator.Add(moder);
                context.SaveChanges();
            }
        }
        public void Update(dirictionBindingModel model)
        {
            using (var context = new ForumDatabase())
            {
                var moder = context.Moderator.FirstOrDefault(rec => rec.Login == model.LoginUser);
                if (moder == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, moder);
                context.SaveChanges();
            }
        }
        public void Delete(dirictionBindingModel model)
        {
            using (var context = new ForumDatabase())
            {
                var element = context.Moderator.FirstOrDefault(rec => rec.Login == model.LoginUser);
                if (element != null)
                {
                    context.Moderator.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private diriction CreateModel(dirictionBindingModel model, diriction moder)
        {
            moder.Amountofhelp = model.AmountOfHelp;
            moder.Login = model.LoginUser;
            moder.Password = model.Password;
            moder.Email = model.Email;
            moder.TotalTime = model.TotalTime;
            return moder;
        }
    }
}
