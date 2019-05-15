using SF.Feature.SampleFeature.Models;
using SF.Foundation.Sample.Repositories;
using Sitecore.XA.Foundation.Mvc.Repositories.Base;
using Sitecore.XA.Foundation.RenderingVariants.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SF.Feature.SampleFeature.Repositories
{
    public class SampleCategoriesRepository : VariantsRepository, ISampleCategoriesRepository
    {
        protected ISampleContentRepository SampleContentRepository { get; set; }

        public SampleCategoriesRepository(ISampleContentRepository sampleContentRepository)
        {
            SampleContentRepository = sampleContentRepository;
        }

        public override IRenderingModelBase GetModel()
        {
            var model = new SampleCategoriesModel();
            FillBaseProperties(model);

            model.Categories = SampleContentRepository.GetCategories();
            
            return model;
        }
    }
}