using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Web;
using SF.Foundation.SXAGlass.Models;
using Sitecore.XA.Foundation.Mvc.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SF.Foundation.SXAGlass.Repositories
{
    public class GlassModelRepository<T> : ModelRepository, IGlassModelRepository where T : class
    {
        public IRequestContext RequestContext { get; set; }

        public GlassModelRepository(IRequestContext context)
        {
            RequestContext = context;
        }

        public override IRenderingModelBase GetModel()
        {
            var model = new RenderingGlassModel<T>();
            FillBaseProperties(model);

            model.GlassModel = RequestContext.SitecoreService.GetItem<T>(new GetItemByItemOptions() { Item = model.Item });

            return model;
        }

        
    }
}