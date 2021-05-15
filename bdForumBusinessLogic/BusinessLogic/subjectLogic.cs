using System;
using System.Collections.Generic;
using System.Text;
using bdForumBusinessLogic.BindingModels;
using bdForumBusinessLogic.Interfaces;
using bdForumBusinessLogic.ViewModels;

namespace bdForumBusinessLogic.BusinessLogic
{
    public class subjectLogic
    {
        private readonly IsubjectStorage topicStorage;
        public subjectLogic(IsubjectStorage topicStorage)
        {
            this.topicStorage = topicStorage;
        }
        public List<TopicViewModel> Read(subjectBindingModel model)
        {
            if (model == null)
            {
                return topicStorage.GetFullList();
            }
            if (!model.Name.Equals(null))
            {
                return new List<TopicViewModel> { topicStorage.GetElement(model) };
            }
            return topicStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(subjectBindingModel model)
        {
            if (topicStorage.GetElement(new subjectBindingModel
            {
                Name = model.Name
            }) != null)
            {
                topicStorage.Update(model);
            }
            else
            {
                topicStorage.Insert(model);
            }
        }
        public void Delete(subjectBindingModel model)
        {
            var element = topicStorage.GetElement(new subjectBindingModel { Name = model.Name });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            topicStorage.Delete(model);
        }
    }
}

