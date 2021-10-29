using MailingList.Models;
using MailingList.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailingList.Services.Implementation
{
    public class MailingListService : IMailingListService
    {
        private readonly IMailingListRepository _mailingListRepository;

        public MailingListService(IMailingListRepository mailingListRepository)
        {
            _mailingListRepository = mailingListRepository;
        }
        public async Task<IEnumerable<MailingListRecord>> GetMailingListsAsync(string lastName, string ascdesc)
        {
            return await _mailingListRepository.GetMailingListsAsync(lastName, ascdesc);
        }


        public string AddMailingList(MailingListRecord mailingListRecord)
        {
            return _mailingListRepository.AddMailingList(mailingListRecord);
        }
    }
}
