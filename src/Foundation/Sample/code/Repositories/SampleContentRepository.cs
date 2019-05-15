using SF.Foundation.Sample.Models;
using Sitecore.DependencyInjection;
using Sitecore.XA.Foundation.Multisite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.XA.Foundation.SitecoreExtensions.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Glass.Mapper.Sc.Web;
using Sitecore.Data.Items;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.ContentSearch.Linq;

namespace SF.Foundation.Sample.Repositories
{
    public class SampleContentRepository : ISampleContentRepository
    {
        /// <summary>
        /// Retreives Collection of Categories as Configured in the Current Site's SXA data folder
        /// </summary>
        /// <returns></returns>
        public List<SampleContentCategory> GetCategories()
        {

            var dataRoot = getDataFolder();
            if (dataRoot == null)
            {
                return null;
            }

            var categoriesRoot = dataRoot.FirstChildInheritingFrom(new Sitecore.Data.ID(SF.Foundation.Sample.Constants.Templates.SampleContentCategoryFolder));
            if (categoriesRoot == null)
            {
                return null;
            }

            var requestContext = ServiceLocator.ServiceProvider.GetService<IRequestContext>();
            var categories = requestContext.SitecoreService.GetItem<SampleContentCategoryFolder>(new Glass.Mapper.Sc.GetItemByItemOptions() { Item = categoriesRoot, Lazy= Glass.Mapper.LazyLoading.Disabled, InferType= true });

            return categories.Children.ToList();
        }

        /// <summary>
        /// Performs Sitecore Content Search of Site's Sample Content Folder based on provided Category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public List<SampleContent> GetSampleContentByCategory(SampleContentCategory category)
        {
            var dataRoot = getDataFolder();
            if (dataRoot == null)
            {
                return null;
            }

            var contentRoot = dataRoot.FirstChildInheritingFrom(new Sitecore.Data.ID(SF.Foundation.Sample.Constants.Templates.SampleContentFolder));
            if (contentRoot == null)
            {
                return null;
            }

            SitecoreIndexableItem indexableItem = new SitecoreIndexableItem(contentRoot);
            ISearchIndex index = ContentSearchManager.GetIndex(indexableItem);
            using (IProviderSearchContext context = index.CreateSearchContext())
            {
                var categoryId = new Sitecore.Data.ID(category.Id);
                //Using Predicate Builder as Example only, Can add subqueries if needed.
                var baseQuery = PredicateBuilder.True<SampleContentSearchResultItem>();
                baseQuery = baseQuery.And(item => item.Paths.Contains(contentRoot.ID));
                baseQuery = baseQuery.And(item => item.Category == categoryId);

                var queryRunner = context.GetQueryable<SampleContentSearchResultItem>().Where(baseQuery);
                var results = queryRunner.GetResults();

                //If we didn't need things editable, we could return the search result item directly.
                var requestContext = ServiceLocator.ServiceProvider.GetService<IRequestContext>();

                return results.Hits.Select(x => requestContext.SitecoreService.GetItem<SampleContent>(new Glass.Mapper.Sc.GetItemByIdOptions() { Id = x.Document.ItemId.Guid })).ToList();
                
            }
            
        }

        private Item getDataFolder()
        {
            var multiSiteContext = ServiceLocator.ServiceProvider.GetService<IMultisiteContext>();
            if (multiSiteContext == null || Sitecore.Context.Site == null || string.IsNullOrEmpty(Sitecore.Context.Site.StartPath))
            {
                return null;
            }

            var dataRoot = multiSiteContext.GetDataItem(Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath));
            return dataRoot;
        }
    }
}