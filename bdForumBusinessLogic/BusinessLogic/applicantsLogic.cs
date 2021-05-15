using System;
using System.Collections.Generic;
using System.Text;
using bdForumBusinessLogic.BindingModels;
using bdForumBusinessLogic.Interfaces;
using bdForumBusinessLogic.ViewModels;

namespace bdForumBusinessLogic.BusinessLogic
{
    public class applicantsLogic
    {
        private readonly IapplicantsStorage messageStorage;
        public applicantsLogic(IapplicantsStorage messageStorage)
        {
            this.messageStorage = messageStorage;
        }
        public List<MessageViewModel> Read(applicantsBindingModel model)
        {
            if (model == null)
            {
                return messageStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<MessageViewModel> { messageStorage.GetElement(model) };
            }
            return messageStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(applicantsBindingModel model)
        {
            if (model.Id.HasValue)
            {
                messageStorage.Update(model);
            }
            else
            {
                messageStorage.Insert(model);
            }
        }
        public void Delete(applicantsBindingModel model)
        {
            var element = messageStorage.GetElement(new applicantsBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            messageStorage.Delete(model);
        }
    }
}

