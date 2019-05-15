using Glass.Mapper;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.IoC;
using Glass.Mapper.Sc.Web;
using Glass.Mapper.Sc.Web.Mvc;
using SF.Foundation.SXAGlass.Models;
using SF.Foundation.SXAGlass.Repositories;
using Sitecore.Data.Items;
using Sitecore.DependencyInjection;
using Sitecore.XA.Foundation.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Extensions.DependencyInjection;

namespace SF.Foundation.SXAGlass.Controllers
{
    public class GlassStandardController<T> : GlassStandardController where T : class
    {
        protected readonly IGlassModelRepository Repository;

        public GlassStandardController(IMvcContext context) : base(context)
        {
            var requestContext = ServiceLocator.ServiceProvider.GetService<IRequestContext>();
            this.Repository = new GlassModelRepository<T>(requestContext);
        }
        
        public T DataSourceModel
        {
            get { return base.GetDataSourceItem<T>(); }
        }

        public T ContextModel
        {
            get { return base.GetContextItem<T>(); }
        }
        
        public RenderingGlassModel<T> Model
        {
            get
            {
                return Repository.GetModel() as RenderingGlassModel<T>;
            }
        }

        public T GlassModel
        {
            get
            {
                return Model.GlassModel;
            }
        }
    }

    public class GlassStandardController : StandardController
    {
        public IMvcContext MvcContext { get; set; }

        
        public GlassStandardController(IMvcContext mvcContext)
        {
            MvcContext = mvcContext;
        }

        /// <summary>
        /// Returns either the item specified by the DataSource or the current context item
        /// </summary>
        /// <value>The layout item.</value>
        public virtual Item LayoutItem
        {
            get
            {
                return DataSourceItem ?? ContextItem;
            }
        }

        /// <summary>
        /// Returns either the item specified by the current context item
        /// </summary>
        /// <value>The layout item.</value>
        public virtual Item ContextItem
        {
            get { return MvcContext.ContextItem; }
        }

        /// <summary>
        /// Returns the item specificed by the data source only. Returns null if no datasource set
        /// </summary>
        public virtual Item DataSourceItem
        {
            get
            {
                return MvcContext.DataSourceItem;
            }
        }

        /// <summary>
        /// Returns the Context Item as strongly typed
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected T GetContextItem<T>(bool isLazy = false, bool inferType = false) where T : class
        {
            return MvcContext.GetContextItem<T>(new GetKnownOptions() { Lazy = isLazy ? LazyLoading.Enabled : LazyLoading.Disabled , InferType = inferType });
        }

        /// <summary>
        /// Returns the Data Source Item as strongly typed
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected T GetDataSourceItem<T>(bool isLazy = false, bool inferType = false) where T : class
        {
            if (DataSourceItem == null)
            {
                return null;
            }

            return MvcContext.SitecoreService.GetItem<T>(new GetItemByItemOptions() { Item = DataSourceItem,  Lazy = isLazy ? LazyLoading.Enabled : LazyLoading.Disabled, InferType = inferType });
        }

        /// <summary>
        /// Returns the Layout Item as strongly typed
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected T GetLayoutItem<T>(bool isLazy = false, bool inferType = false) where T : class
        {
            if (LayoutItem == null)
            {
                return null;
            }

            return MvcContext.SitecoreService.GetItem<T>(new GetItemByItemOptions() { Item = LayoutItem, Lazy = isLazy ? LazyLoading.Enabled : LazyLoading.Disabled, InferType = inferType });
        }

        

        



    }
}