using Glass.Mapper.Sc.Configuration.Attributes;
using SF.Foundation.SXAGlass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SF.Foundation.Sample.Models
{
    [SitecoreType(TemplateId = Constants.Templates.SampleContentCategory)]
    public class SampleContentCategory : GlassBase
    {
        [SitecoreField(FieldId = Constants.Fields.SampleContentCategory.CategoryName)]
        public virtual string CategoryName { get; set; }
    }
}