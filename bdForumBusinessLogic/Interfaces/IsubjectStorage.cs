using System;
using System.Collections.Generic;
using System.Text;
using bdForumBusinessLogic.BindingModels;
using bdForumBusinessLogic.ViewModels;

namespace bdForumBusinessLogic.Interfaces
{
    public interface IsubjectStorage
    {
        List<TopicViewModel> GetFullList();
        List<TopicViewModel> GetFilteredList(subjectBindingModel model);
        TopicViewModel GetElement(subjectBindingModel model);
        void Insert(subjectBindingModel model);
        void Update(subjectBindingModel model);
        void Delete(subjectBindingModel model);
    }
}
