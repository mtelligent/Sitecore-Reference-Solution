using Glass.Mapper.Sc.Configuration.Attributes;
using SF.Foundation.SXAGlass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SF.Foundation.Sample.Models
{
    [SitecoreType(TemplateId = Constants.Templates.SampleContentCategoryFolder)]
    public class SampleContentCategoryFolder : GlassBase
    {
        [SitecoreChildren]
        public virtual IEnumerable<SampleContentCategory> Children { get; set; }
    }
}