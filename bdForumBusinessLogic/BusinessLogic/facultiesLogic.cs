using System;
using System.Collections.Generic;
using bdForumBusinessLogic.BindingModels;
using bdForumBusinessLogic.Interfaces;
using bdForumBusinessLogic.ViewModels;

namespace bdForumBusinessLogic.BusinessLogic
{
    public class facultiesLogic
    {
        private readonly IfacultiesStorage likeStorage;
        public facultiesLogic(IfacultiesStorage likeStorage)
        {
            this.likeStorage = likeStorage;
        }
        public List<LikeViewModel> Read(facultiesBindingModel model)
        {
            if (model == null)
            {
                return likeStorage.GetFullList();
            }
            if (model.LoginUser != null)
            {
                return new List<LikeViewModel> { likeStorage.GetElement(model) };
            }
            return likeStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(facultiesBindingModel model)
        {
            var element = likeStorage.GetElement(new facultiesBindingModel
            {
                LoginUser = model.LoginUser,
                IdMessage = model.IdMessage
            });
            if (element != null)
            {
                throw new Exception("Такой лайк поставлен");
            }
                likeStorage.Insert(model);
        }
        public void Delete(facultiesBindingModel model)
        {
            var element = likeStorage.GetElement(new facultiesBindingModel {
                LoginUser = model.LoginUser,
                IdMessage = model.IdMessage
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            likeStorage.Delete(model);
        }
    }
}
