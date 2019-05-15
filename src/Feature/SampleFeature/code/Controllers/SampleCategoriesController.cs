using SF.Feature.SampleFeature.Repositories;
using SF.Foundation.SXAGlass.Controllers;
using Sitecore.XA.Foundation.Mvc.Controllers;
using Sitecore.XA.Foundation.RenderingVariants.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SF.Feature.SampleFeature.Controllers
{
    public class SampleCategoriesController : VariantsController
    {
        protected ISampleCategoriesRepository SampleCategoriesRepository;
        public SampleCategoriesController(ISampleCategoriesRepository repository)
        {
            SampleCategoriesRepository = repository;
        }

        protected override object GetModel()
        {
            return SampleCategoriesRepository.GetModel();
        }

        public override ActionResult Index()
        {
            return View(GetModel());
        }
    }
}