using System;
using System.Collections.Generic;
using System.Text;
using bdForumBusinessLogic.BindingModels;
using bdForumBusinessLogic.ViewModels;

namespace bdForumBusinessLogic.Interfaces
{
    public interface IfacultiesStorage
    {
        List<LikeViewModel> GetFullList();
        List<LikeViewModel> GetFilteredList(facultiesBindingModel model);
        LikeViewModel GetElement(facultiesBindingModel model);
        void Insert(facultiesBindingModel model);
        void Update(facultiesBindingModel model);
        void Delete(facultiesBindingModel model);
    }
}
