using System;
using Ensilog.Engagebay.Abstractions;
using Ensilog.Engagebay.Deals;
using RestSharp;

namespace Ensilog.Engagebay
{
    public class ListDeals : PageableEngageBayQuery<Deal>
    {
        public override Method Method => Method.Post;
        public override string Uri => "/dev/api/panel/deals";
        public override string Body => GeneratePageConfigString();
        public override string ContentType => "application/x-www-form-urlencoded";

        private string _trackId;

        public ListDeals(int pageSize, string sortKey = "created_time", bool ascendingSort = true, string trackId = null) : base(pageSize, sortKey, ascendingSort)
        {
            _trackId = trackId;
        }

        protected override string GeneratePageConfigString()
        {
            string baseConfig = base.GeneratePageConfigString();

            if (!string.IsNullOrWhiteSpace(_trackId))
            {
                baseConfig += $"&track_id={_trackId}";
            }

            return baseConfig;
        }
    }

}
