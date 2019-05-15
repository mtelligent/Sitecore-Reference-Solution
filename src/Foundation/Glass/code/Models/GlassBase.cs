using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;


namespace SF.Foundation.SXAGlass.Models
{
    public class GlassBase
    {
        [SitecoreId]
        public virtual Guid Id { get; private set; }

        [SitecoreInfo(SitecoreInfoType.Url)]
        public string ItemUrl { get; set; }

        [SitecoreInfo(SitecoreInfoType.Name)]
        public virtual string Name { get; set; }

        [SitecoreItem]
        public virtual Sitecore.Data.Items.Item Item { get; private set; }

        [SitecoreInfo(SitecoreInfoType.Version)]
        public virtual int Version { get; private set; }
    }
}