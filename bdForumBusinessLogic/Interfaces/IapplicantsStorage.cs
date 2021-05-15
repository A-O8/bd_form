using System;
using System.Collections.Generic;
using System.Text;
using bdForumBusinessLogic.BindingModels;
using bdForumBusinessLogic.ViewModels;

namespace bdForumBusinessLogic.Interfaces
{
    public interface IapplicantsStorage
    {
        List<MessageViewModel> GetFullList();
        List<MessageViewModel> GetFilteredList(applicantsBindingModel model);
        MessageViewModel GetElement(applicantsBindingModel model);
        void Insert(applicantsBindingModel model);
        void Update(applicantsBindingModel model);
        void Delete(applicantsBindingModel model);
    }
}
