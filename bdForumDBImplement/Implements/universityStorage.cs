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
    public class universityStorage : IuniversityStorage
    {
        public VisitorViewModel GetElement(universityBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ForumDatabase())
            {
                var visitor = context.Visitor.FirstOrDefault(rec => rec.Login == model.LoginUser && rec.Password == model.Password);
                return visitor != null ? new VisitorViewModel
                {
                    LoginUser = visitor.Login,
                    Password = visitor.Password,
                    Email = visitor.Email,
                    TotalTime = visitor.TotalTime,
                    Status = visitor.Status,
                    Decency = visitor.Decency,
                    CountOfMessages = visitor.Countmessages,
                } :
                null;
            }
        }

        public List<VisitorViewModel> GetFilteredList(universityBindingModel model)
        {
            using (var context = new ForumDatabase())
            {
                return context.Visitor.Where(rec => rec.Countmessages > model.CountOfMessages)
                    .Select(rec => new VisitorViewModel
                    {
                        LoginUser = rec.Login,
                        Password = rec.Password,
                        Email = rec.Email,
                        TotalTime = rec.TotalTime,
                        Status = rec.Status,
                        Decency = rec.Decency,
                        CountOfMessages = rec.Countmessages,
                    }).ToList();
            }
        }

        public List<VisitorViewModel> GetFullList()
        {
            using (var context = new ForumDatabase())
            {
                return context.Visitor
                    .Select(rec => new VisitorViewModel
                    {
                        LoginUser = rec.Login,
                        Password = rec.Password,
                        Email = rec.Email,
                        TotalTime = rec.TotalTime,
                        Status = rec.Status,
                        Decency = rec.Decency,
                        CountOfMessages = rec.Countmessages,
                    }).ToList();
            }
        }

        public void Insert(universityBindingModel model)
        {
            using (var context = new ForumDatabase())
            {
                university visitor = CreateModel(model, new university());
                context.Visitor.Add(visitor);
                context.SaveChanges();
            }
        }
        public void Update(universityBindingModel model)
        {
            using (var context = new ForumDatabase())
            {
                var visitor = context.Visitor.FirstOrDefault(rec => rec.Login == model.LoginUser);
                if (visitor == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, visitor);
                context.SaveChanges();
            }
        }
        public void Delete(universityBindingModel model)
        {
            using (var context = new ForumDatabase())
            {
                var element = context.Visitor.FirstOrDefault(rec => rec.Login == model.LoginUser);
                if (element != null)
                {
                    context.Visitor.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private university CreateModel(universityBindingModel model, university visitor)
        {
            visitor.Countmessages = model.CountOfMessages;
            visitor.Decency = model.Decency;
            visitor.Status = model.Status;
            visitor.Login = model.LoginUser;
            visitor.Password = model.Password;
            visitor.Email = model.Email;
            visitor.TotalTime = model.TotalTime;
            return visitor;
        }
    }
}
