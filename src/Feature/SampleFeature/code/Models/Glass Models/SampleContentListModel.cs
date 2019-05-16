using Glass.Mapper.Sc.Configuration.Attributes;
using SF.Foundation.Sample.Models;
using SF.Foundation.SXAGlass.Models;
using Sitecore.XA.Foundation.Variants.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SF.Feature.SampleFeature.Models
{
    [SitecoreType(TemplateId = Constants.Templates.SampleContentList)]
    public class SampleContentListModel : GlassBase
    {
        [SitecoreField(FieldId = Constants.Fields.SampleContentList.Title)]
        public virtual string Title { get; set; }

        [SitecoreField(FieldId = Constants.Fields.SampleContentList.Category)]
        public virtual SampleContentCategory Category { get; set; }

        [SitecoreIgnore]
        public virtual List<SampleContent> Content { get; set; }
    }
}