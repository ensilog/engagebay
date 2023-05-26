using Ensilog.Engagebay.Abstractions;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ensilog.Engagebay.Companies
{
    public class ListCompanies : PageableEngageBayQuery<Company>
    {
        public override Method Method => Method.Post;
        public override string Uri => $"/dev/api/panel/companies";
        public override string Body => GeneratePageConfigString();
        public override string ContentType => "application/x-www-form-urlencoded";

        public ListCompanies(int pageSize, string sortKey = "created_time", bool ascendingSort = true)
            : base(pageSize, sortKey, ascendingSort)
        {
        }
    }

}
