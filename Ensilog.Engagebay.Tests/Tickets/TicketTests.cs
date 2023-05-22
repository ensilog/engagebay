using Ensilog.Engagebay.Properties;
using Ensilog.Engagebay.Tickets;
using FluentAssertions;
using static Ensilog.Engagebay.Properties.PropertyFactory;

namespace Ensilog.Engagebay.Tests.Tickets
{
    public class TicketTests
    {
        [Fact]
        public void ExtractAllProperties_ShouldExtractCorrectProperties()
        {
            // Arrange
            var ticket = new Ticket
            {
                Subject = "Test Subject",
                Type = 1,
                Priority = 1,
                Status = 1,
                GroupId = 1,
                AssigneeId = 1,
                HtmlBody = "<p>Test Html Body</p>",
                OtherProperties = new List<Property>()
                {
                    CreateCustomProperty("custom_property", PropertyFieldType.TEXT).WithValue("custom_property_value")
                }
            };

            // Act
            var properties = ticket.ExtractAllProperties().ToList();

            // Assert
            properties.Should().HaveCount(8);
            properties.Should().ContainSingle(p => p.Name == "subject" && p.Value == ticket.Subject);
            properties.Should().ContainSingle(p => p.Name == "type" && p.Value == ticket.Type.ToString());
            properties.Should().ContainSingle(p => p.Name == "priority" && p.Value == ticket.Priority.ToString());
            properties.Should().ContainSingle(p => p.Name == "status" && p.Value == ticket.Status.ToString());
            properties.Should().ContainSingle(p => p.Name == "group_id" && p.Value == ticket.GroupId.ToString());
            properties.Should().ContainSingle(p => p.Name == "assignee_id" && p.Value == ticket.AssigneeId.ToString());
            properties.Should().ContainSingle(p => p.Name == "html_body" && p.Value == ticket.HtmlBody);
            properties.Should().ContainSingle(p => p.Name == "custom_property" && p.Value == "custom_property_value");
        }
    }

}
