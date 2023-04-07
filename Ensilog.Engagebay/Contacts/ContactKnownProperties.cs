using Ensilog.Engagebay.Properties;
using static Ensilog.Engagebay.Properties.PropertyFactory;

namespace Ensilog.Engagebay.Contacts
{
    public static class ContactKnownProperties
    {
        public static Property FirstName => CreateSystemProperty("name");
        public static Property LastName => CreateSystemProperty("last_name");
        public static Property Email => CreateSystemProperty("email").WithSubType("primary");
        public static Property EmailSecondary => CreateSystemProperty("email").WithSubType("secondary");
        public static Property Role => CreateSystemProperty("role");
        public static Property PhoneWork => CreateSystemProperty("phone").WithSubType("work");
        public static Property PhoneMobile => CreateSystemProperty("phone").WithSubType("mobile");
        public static Property PhoneHome => CreateSystemProperty("phone").WithSubType("home");
        public static Property WebsiteUrl => CreateSystemProperty("website").WithSubType("url");
        public static Property WebsiteSkype => CreateSystemProperty("website").WithSubType("skype");
        public static Property WebsiteLinkedIn => CreateSystemProperty("website").WithSubType("linkedin");
        public static Property WebsiteFacebook => CreateSystemProperty("website").WithSubType("facebook");
        public static Property WebsiteGithub => CreateSystemProperty("website").WithSubType("github");
        public static Property WebsiteYoutube => CreateSystemProperty("website").WithSubType("youtube");
        public static Property Address => CreateSystemProperty("address");
    }
}
