using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using SF.Foundation.SXAGlass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SF.Foundation.Sample.Models
{
    [SitecoreType(TemplateId = Constants.Templates.SampleContent)]
    public class SampleContent : GlassBase
    {
        [SitecoreField(FieldId = Constants.Fields.SampleContent.Title)]
        public virtual string Title { get; set; }

        [SitecoreField(FieldId = Constants.Fields.SampleContent.BodyCopy, Setting = SitecoreFieldSettings.RichTextRaw)]
        public virtual string BodyCopy { get; set; }

        [SitecoreField(FieldId = Constants.Fields.SampleContent.Image)]
        public virtual Image Image { get; set; }

        [SitecoreField(FieldId = Constants.Fields.SampleContent.CTALink)]
        public virtual Link CTALink { get; set; }

        

        
    }
}