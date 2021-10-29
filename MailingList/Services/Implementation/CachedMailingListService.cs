using MailingList.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailingList.Services.Implementation
{
    public class CachedMailingListService : IMailingListService
    {
        private readonly MailingListService _mailingListService;

        public CachedMailingListService(MailingListService mailingListService)
        {
            _mailingListService = mailingListService;
        }
        public async Task<IEnumerable<MailingListRecord>> GetMailingListsAsync(string lastName, string ascdesc)
        {
            return await _mailingListService.GetMailingListsAsync(lastName, ascdesc);
        }

        public string AddMailingList(MailingListRecord request)
        {
            return _mailingListService.AddMailingList(request);
        }
    }
}
