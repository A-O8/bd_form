using System;
using System.Collections.Generic;
using System.Text;
using bdForumBusinessLogic.BindingModels;
using bdForumBusinessLogic.Interfaces;
using bdForumBusinessLogic.ViewModels;

namespace bdForumBusinessLogic.BusinessLogic
{
    public class universityLogic
    {
        private readonly IuniversityStorage visitorStorage;
        public universityLogic(IuniversityStorage visitorStorage)
        {
            this.visitorStorage = visitorStorage;
        }
        public List<VisitorViewModel> Read(universityBindingModel model)
        {
            if (model == null)
            {
                return visitorStorage.GetFullList();
            }
            if (model.LoginUser != null)
            {
                return new List<VisitorViewModel> { visitorStorage.GetElement(model) };
            }
            return visitorStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(universityBindingModel model)
        {
            if (visitorStorage.GetElement(new universityBindingModel
            {
                LoginUser = model.LoginUser,
                Password = model.Password
            }) != null)
            {
                visitorStorage.Update(model);
            }
            else
            {
                visitorStorage.Insert(model);
            }
        }
        public void Delete(universityBindingModel model)
        {
            var element = visitorStorage.GetElement(new universityBindingModel { LoginUser = model.LoginUser });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            visitorStorage.Delete(model);
        }
    }
}
