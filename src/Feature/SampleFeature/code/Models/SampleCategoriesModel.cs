using SF.Foundation.Sample.Models;
using Sitecore.XA.Foundation.Variants.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SF.Feature.SampleFeature.Models
{
    public class SampleCategoriesModel : VariantsRenderingModel
    {
        public List<SampleContentCategory> Categories { get; set; }
    }
}