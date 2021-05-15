using System;
using System.Collections.Generic;
using System.Text;
using bdForumBusinessLogic.BindingModels;
using bdForumBusinessLogic.Interfaces;
using bdForumBusinessLogic.ViewModels;

namespace bdForumBusinessLogic.BusinessLogic
{
    public class dirictionLogic
    {
        private readonly IdirictionStorage moderatorStorage;
        public dirictionLogic(IdirictionStorage moderatorStorage)
        {
            this.moderatorStorage = moderatorStorage;
        }
        public List<ModeratorViewModel> Read(dirictionBindingModel model)
        {
            if (model == null)
            {
                return moderatorStorage.GetFullList();
            }
            if (model.LoginUser != null)
            {
                return new List<ModeratorViewModel> { moderatorStorage.GetElement(model) };
            }
            return moderatorStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(dirictionBindingModel model)
        {
            if (moderatorStorage.GetElement(new dirictionBindingModel {
                LoginUser = model.LoginUser,
                Password = model.Password
            }) != null)
            {
                moderatorStorage.Update(model);
            }
            else
            {
                moderatorStorage.Insert(model);
            }
        }
        public void Delete(dirictionBindingModel model)
        {
            var element = moderatorStorage.GetElement(new dirictionBindingModel { LoginUser = model.LoginUser });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            moderatorStorage.Delete(model);
        }
    }
}
