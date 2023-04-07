using Ensilog.Engagebay.Addresses;
using Ensilog.Engagebay.Contacts;
using Ensilog.Engagebay.Contacts.Exceptions;
using Ensilog.Engagebay.Properties;
using Ensilog.Engagebay.Tags;
using FluentAssertions;
using System.Text.Json;

namespace Ensilog.Engagebay.Tests.Contacts
{
    public class CreateContactTests
    {
        [Fact]
        public void ContactWithAllAttributes_Should_CreateCorrectRequest()
        {
            // Plan
            Address address = new Address()
            {
                AddressLine = "13 nowhere street",
                City = "Paris",
                Country = "France",
                State = "Seine",
                Zip = "75000"
            };
            var testProperty1 = new Property()
            {
                FieldType = PropertyFieldType.TEXT,
                IsSearchable = true,
                Name = "Test field 1",
                Type = PropertyType.CUSTOM,
                SubType = null,
                Value = "Test field 1 value"
            };
            Contact contactToCreate = new Contact()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "some-email@domain.com",
                Phone = "0000000000",
                Address = address,
                Tags = new Tag[] { new Tag("tag1"), new Tag("tag2") },
                CompanyIds = new long[] { 123, 124 },
                Role = "CEO",
                Website = "www.domain.com",
                OtherProperties = new List<Property>()
                {
                    testProperty1
                }
            };

            // Do
            var request = new CreateContact(contactToCreate);

            // Check
            request.Body.Properties.Should().HaveCount(8)
                 .And.Contain(ContactKnownProperties.Email.WithValue("some-email@domain.com"))
                 .And.Contain(ContactKnownProperties.FirstName.WithValue("John"))
                 .And.Contain(ContactKnownProperties.LastName.WithValue("Doe"))
                 .And.Contain(ContactKnownProperties.PhoneWork.WithValue("0000000000"))
                 .And.Contain(ContactKnownProperties.Role.WithValue("CEO"))
                 .And.Contain(ContactKnownProperties.Address.WithValue(JsonSerializer.Serialize(address)))
                 .And.Contain(ContactKnownProperties.WebsiteUrl.WithValue("www.domain.com"))
                 .And.Contain(testProperty1);
            request.Body.Tags.Should().BeEquivalentTo(new Tag[] { new Tag("tag1"), new Tag("tag2") });
            request.Body.CompanyIds.Should().BeEquivalentTo(new long[] { 123, 124 });
            request.ContentType.Should().Be("application/json");
            request.Uri.Should().Be("/dev/api/panel/subscribers/subscriber");
            request.Method.Should().Be(RestSharp.Method.Post);
        }

        [Fact]
        public void NullContact_Should_ThrowException()
        {
            // Plan
            Contact? contactToCreate = null;

            // Do
            Action act = () => new CreateContact(contactToCreate);

            // Check
            act.Should().Throw<ContactNullException>();
        }


        [Fact]
        public void ContactWithoutName_Should_ThrowException()
        {
            // Plan
            Contact contactToCreate = new Contact()
            {
                Email = "some-email@domain.com"
            }; ;

            // Do
            Action act = () => new CreateContact(contactToCreate);

            // Check
            act.Should().Throw<ContactFirstNameNullException>();
        }
    }
}
