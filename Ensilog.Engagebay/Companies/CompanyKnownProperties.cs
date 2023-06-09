using Ensilog.Engagebay.Properties;
using System;
using System.Collections.Generic;
using System.Text;

using static Ensilog.Engagebay.Properties.PropertyFactory;

namespace Ensilog.Engagebay.Companies
{
    public class CompanyKnownProperties
    {
        public static Property Name => CreateSystemProperty("name");
        public static Property Url => CreateSystemProperty("url");
        public static Property Email => CreateSystemProperty("email").WithSubType("primary");
        public static Property Phone => CreateSystemProperty("phone").WithSubType("work");
        public static Property Website => CreateSystemProperty("website").WithSubType("url");
        public static Property Address => CreateSystemProperty("address");
        public static Property OwnerId => CreateSystemProperty("owner_id");
    }
}
