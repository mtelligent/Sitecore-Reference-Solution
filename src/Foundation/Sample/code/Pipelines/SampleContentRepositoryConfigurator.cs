using Microsoft.Extensions.DependencyInjection;
using SF.Foundation.Sample.Repositories;
using Sitecore.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SF.Foundation.Sample.Pipelines
{
    public class SampleContentRepositoryConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(ISampleContentRepository), typeof(SampleContentRepository));
        }
    }
}