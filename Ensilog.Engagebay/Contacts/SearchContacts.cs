using Ensilog.Engagebay.Abstractions;
using Ensilog.Engagebay.Exceptions;
using System.Collections.Generic;
using System.Net;

namespace Ensilog.Engagebay.Contacts
{
    public class SearchContacts : EngageBayQuery<IEnumerable<Contact>>
    {
        public string SearchText { get; }
        public int PageSize { get; }

        public SearchContacts(string searchText, int pageSize = 10)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                throw new SearchTextNullException(nameof(searchText));

            if (pageSize <= 0)
                throw new PageSizeOutOfRangeException(nameof(pageSize));

            SearchText = searchText;
            PageSize = pageSize;
        }

        public override string Uri => $"dev/api/search?q={WebUtility.UrlEncode(SearchText)}&type=Subscriber&page_size={PageSize}";
    }
}
