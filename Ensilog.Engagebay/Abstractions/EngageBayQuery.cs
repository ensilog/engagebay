using Ensilog.Engagebay.Exceptions;
using RestSharp;
using System.Collections.Generic;
using System.Linq;

namespace Ensilog.Engagebay.Abstractions
{
    public abstract class EngageBayQuery<TResponse> : IEngageBayRequest<string, TResponse> where TResponse : class
    {
        public virtual Method Method => Method.Get;

        public abstract string Uri { get; }

        public virtual string Body => "";

        public virtual string ContentType => "application/x-www-form-urlencoded";
    }

    public abstract class PageableEngageBayQuery<TResponse> : EngageBayQuery<IEnumerable<TResponse>> where TResponse : PageableObject
    {
        protected int _pageSize;
        protected string _sortKey;
        protected string _cursor;
        protected bool _sortAscending;

        public PageableEngageBayQuery(int pageSize, string sortKey, bool ascendingSort = true)
        {
            if (pageSize < 1 || pageSize > 1000)
            {
                throw new PageSizeInvalidException();
            }

            if (string.IsNullOrEmpty(sortKey))
            {
                sortKey = "created_time";
            }

            _pageSize = pageSize;
            _sortKey = sortKey;
            _sortAscending = ascendingSort;
        }

        public bool NextResults(IEnumerable<TResponse> previousResponses)
        {
            if (previousResponses == null)
                return false;

            _cursor = previousResponses.LastOrDefault(c => !string.IsNullOrEmpty(c.Cursor))?.Cursor;

            return !string.IsNullOrEmpty(_cursor);
        }


        protected virtual string GeneratePageConfigString()
        {
            return $"page_size={_pageSize}&sort_key={(_sortAscending ? "" : "-")}{_sortKey}" + (!string.IsNullOrEmpty(_cursor) ? $"&cursor={_cursor}" : "");
        }
    }
}
