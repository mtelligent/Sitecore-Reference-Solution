using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Pipelines.GetGlassLoaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SF.Feature.SampleFeature.Pipelines
{
    public class GlassLoader : GetGlassLoadersProcessor
    {
        public override void Process(GetGlassLoadersPipelineArgs args)
        {

            var loader = new SitecoreAttributeConfigurationLoader("SF.Feature.SampleFeature");
            args.Loaders.Add(loader);
        }
    }
}