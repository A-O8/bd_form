using System;
using System.Collections.Generic;
using System.Text;
using bdForumBusinessLogic.BindingModels;
using bdForumBusinessLogic.ViewModels;

namespace bdForumBusinessLogic.Interfaces
{
    public interface IdirictionStorage
    {
        List<ModeratorViewModel> GetFullList();
        List<ModeratorViewModel> GetFilteredList(dirictionBindingModel model);
        ModeratorViewModel GetElement(dirictionBindingModel model);
        void Insert(dirictionBindingModel model);
        void Update(dirictionBindingModel model);
        void Delete(dirictionBindingModel model);
    }
}
