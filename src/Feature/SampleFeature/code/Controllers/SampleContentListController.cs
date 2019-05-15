using Glass.Mapper.Sc.Web.Mvc;
using SF.Feature.SampleFeature.Models;
using SF.Feature.SampleFeature.Repositories;
using SF.Foundation.Sample.Repositories;
using SF.Foundation.SXAGlass.Controllers;
using Sitecore.XA.Foundation.RenderingVariants.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SF.Feature.SampleFeature.Controllers
{
    public class SampleContentListController : GlassVariantController<SampleContentListModel>
    {
        protected ISampleContentRepository SampleContentRepository { get; set; }

        public SampleContentListController(IMvcContext context, ISampleContentRepository repository) : base(context)
        {
            SampleContentRepository = repository;
        }

        public override ActionResult Index()
        {
            this.Model.GlassModel.Content = SampleContentRepository.GetSampleContentByCategory(this.Model.GlassModel.Category);

            return View(this.Model);
        }
    }
}