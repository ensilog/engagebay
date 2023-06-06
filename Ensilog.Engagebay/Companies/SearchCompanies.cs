using Ensilog.Engagebay.Abstractions;
using Ensilog.Engagebay.Exceptions;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ensilog.Engagebay.Companies
{
    public class SearchCompanies : EngageBayQuery<IEnumerable<Company>>
    {
        public override string Uri => $"/dev/api/search?q={SearchText}&page_size={PageSize}&type=Company";

        public override string ContentType => "application/json";

        public override Method Method => Method.Get;

        public string SearchText { get; }
        public int PageSize { get; }

        public SearchCompanies(string searchText, int page_size = 100)
        {
            if (string.IsNullOrEmpty(searchText))
                throw new SearchTextNullException(nameof(searchText));
            if (page_size == 0 || page_size > 1000)
                throw new PageSizeInvalidException();

            SearchText = searchText;
            PageSize = page_size;
        }
    }
}
