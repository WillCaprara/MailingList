using MailingList.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailingList.Repositories.Implementation
{
    public class MailingListRepository : IMailingListRepository
    {
        private readonly IMemoryCache _memoryCache;
        private static readonly string _malingListKey = "malingListKey";

        public MailingListRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public Task<List<MailingListRecord>> GetMailingListsAsync(string lastName, string ascdesc)
        {
            var mailingListsData = GetCachedData();
            var result = new List<MailingListRecord>();

            if (lastName != null)
            {
                result = mailingListsData.Where(c => c.LastName.ToLower().Trim() == lastName.ToLower().Trim()).OrderBy(c => c.LastName).ToList();

                if (ascdesc == "desc")
                {
                    result = result.OrderByDescending(c => c.LastName).OrderByDescending(c => c.FirstName).ToList();
                }
            }

            return Task.FromResult(result);
        }

        public string AddMailingList(MailingListRecord request)
        {
            var mailingListData = GetCachedData();

            //Check if there is already a record with the same data
            if (mailingListData.Where(c => c.LastName.ToLower().Trim() == request.LastName.ToLower().Trim()
                                     && c.FirstName.ToLower().Trim() == request.FirstName.ToLower().Trim()
                                     && c.Email.ToLower().Trim() == request.Email.ToLower().Trim()).Count() > 0)
            {
                return "There is already a record with the same data.";
            }

            //Add new entry to cache (temp storage)
            _memoryCache.Remove(_malingListKey);

            mailingListData.Add(request);

            //
            _memoryCache.Set(_malingListKey, mailingListData);
            

            return "Record addded successfully!";
        }

        private List<MailingListRecord> GetCachedData()
        {
            var cachedData = _memoryCache.Get(_malingListKey);

            if (cachedData == null)
            {
                _memoryCache.Set(_malingListKey, new List<MailingListRecord>());
            }

            return _memoryCache.Get<List<MailingListRecord>>(_malingListKey);
        }
    }
}
