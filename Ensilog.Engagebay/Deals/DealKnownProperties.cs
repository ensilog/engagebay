using Ensilog.Engagebay.Properties;
using System;
using System.Collections.Generic;
using System.Text;
using static Ensilog.Engagebay.Properties.PropertyFactory;

namespace Ensilog.Engagebay.Deals
{
    public static class DealKnownProperties
    {
        public static Property Name => CreateSystemProperty("name");
        public static Property UniqueId => CreateSystemProperty("unique_id");
        public static Property Description => CreateSystemProperty("description");
        public static Property TrackId => CreateSystemProperty("track_id");
        public static Property Amount => CreateSystemProperty("amount");
        public static Property Currency => CreateSystemProperty("currency_type");
        public static Property ClosedDate => CreateSystemProperty("closed_date");
        public static Property OwnerId => CreateSystemProperty("owner_id");
    }

}
