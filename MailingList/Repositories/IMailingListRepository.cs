using MailingList.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MailingList.Repositories
{
    public interface IMailingListRepository
    {
        public Task<List<MailingListRecord>> GetMailingListsAsync(string lastName, string ascdesc);

        public string AddMailingList(MailingListRecord request);
    }
}
