using System.Collections.Generic;
using System.Threading.Tasks;
using MailingList.Models;

namespace MailingList.Services
{
    public interface IMailingListService
    {
        public Task<IEnumerable<MailingListRecord>> GetMailingListsAsync(string lastName, string ascdesc);

        public string AddMailingList(MailingListRecord mailingListRecord);
    }
}
