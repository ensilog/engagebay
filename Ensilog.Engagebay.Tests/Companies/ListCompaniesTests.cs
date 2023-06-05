using Ensilog.Engagebay.Companies;
using Ensilog.Engagebay.Exceptions;
using FluentAssertions;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensilog.Engagebay.Tests.Companies
{
    public class ListCompaniesTests
    {
        [Fact]
        public void OnlyPageSize_Should_GiveCorrectRequest()
        {
            int pageSize = 20;
            ListCompanies request = new ListCompanies(pageSize);

            request.ContentType.Should().Be("application/x-www-form-urlencoded");
            request.Body.Should().Be("page_size=20&sort_key=created_time");
            request.Uri.Should().Be("/dev/api/panel/companies");
            request.Method.Should().Be(Method.Post);
        }

        [Fact]
        public void EmptySortKey_Should_GiveCorrectRequest()
        {
            int pageSize = 20;
            ListCompanies request = new ListCompanies(pageSize, "");

            request.ContentType.Should().Be("application/x-www-form-urlencoded");
            request.Body.Should().Be("page_size=20&sort_key=created_time");
            request.Uri.Should().Be("/dev/api/panel/companies");
            request.Method.Should().Be(Method.Post);
        }

        [Fact]
        public void SortKeyAndOrderSetting_Should_GiveCorrectRequest()
        {
            int pageSize = 20;
            string sortKey = "test_key";
            bool ascending = false;

            ListCompanies request = new ListCompanies(pageSize, sortKey, ascending);

            request.ContentType.Should().Be("application/x-www-form-urlencoded");
            request.Body.Should().Be("page_size=20&sort_key=-test_key");
            request.Uri.Should().Be("/dev/api/panel/companies");
            request.Method.Should().Be(Method.Post);
        }

        [Fact]
        public void NextResultWhenNull_Should_BeFalse()
        {
            int pageSize = 20;
            List<Company>? companies = null;

            ListCompanies request = new ListCompanies(pageSize);
            bool result = request.NextResults(companies);

            result.Should().BeFalse();
        }

        [Fact]
        public void NextResultWithoutCursor_Should_BeFalse()
        {
            int pageSize = 20;
            List<Company> companies = new List<Company>()
        {
            new Company()
            {
                Cursor = null
            }
        };

            ListCompanies request = new ListCompanies(pageSize);
            bool result = request.NextResults(companies);

            result.Should().BeFalse();
        }

        [Fact]
        public void NextResultWithCursor_Should_BeTrueAndRequest_Should_BeValid()
        {
            int pageSize = 20;
            List<Company> companies = new List<Company>()
        {
            new Company()
            {
                Cursor = "cursor123"
            }
        };

            ListCompanies request = new ListCompanies(pageSize);
            bool result = request.NextResults(companies);

            result.Should().BeTrue();
            request.Body.Should().Be("page_size=20&sort_key=created_time&cursor=cursor123");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1001)]
        public void PageSize_Should_BeInRange(int pageSize)
        {
            Action action = () => new ListCompanies(pageSize);

            action.Should().Throw<PageSizeInvalidException>();
        }
    }

}
