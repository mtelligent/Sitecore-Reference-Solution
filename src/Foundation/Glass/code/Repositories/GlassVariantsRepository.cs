using Glass.Mapper.Sc;
using Glass.Mapper.Sc.IoC;
using Glass.Mapper.Sc.Web;
using SF.Foundation.SXAGlass.Models;
using Sitecore.XA.Foundation.Mvc.Repositories.Base;
using Sitecore.XA.Foundation.RenderingVariants.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SF.Foundation.SXAGlass.Repositories
{
    public class GlassVariantsRepository<T> : VariantsRepository, IGlassVariantsRepository where T : class
    {

        public IRequestContext RequestContext { get; set; }

        public GlassVariantsRepository(IRequestContext context)
        {
            RequestContext = context;
        }

        public override IRenderingModelBase GetModel()
        {
            var model = new VariantsRenderingGlassModel<T>();
            FillBaseProperties(model);

            
            model.GlassModel = RequestContext.SitecoreService.GetItem<T>(new GetItemByItemOptions() { Item = model.Item });


            return model;
        }

        
    }
}