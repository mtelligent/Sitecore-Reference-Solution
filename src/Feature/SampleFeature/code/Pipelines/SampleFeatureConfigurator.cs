using Microsoft.Extensions.DependencyInjection;
using SF.Feature.SampleFeature.Controllers;
using SF.Feature.SampleFeature.Repositories;
using SF.Foundation.Sample.Repositories;
using Sitecore.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SF.Feature.SampleFeature.Pipelines
{

    public class SampleFeatureConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ISampleCategoriesRepository, SampleCategoriesRepository>();
            serviceCollection.AddTransient<SampleCategoriesController>();
            serviceCollection.AddTransient<SampleContentListController>();
        }
    }
}