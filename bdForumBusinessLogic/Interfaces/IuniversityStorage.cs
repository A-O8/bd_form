using System;
using System.Collections.Generic;
using System.Text;
using bdForumBusinessLogic.BindingModels;
using bdForumBusinessLogic.ViewModels;

namespace bdForumBusinessLogic.Interfaces
{
    public interface IuniversityStorage
    {
        List<VisitorViewModel> GetFullList();
        List<VisitorViewModel> GetFilteredList(universityBindingModel model);
        VisitorViewModel GetElement(universityBindingModel model);
        void Insert(universityBindingModel model);
        void Update(universityBindingModel model);
        void Delete(universityBindingModel model);
    }
}
