using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SF.Foundation.Sample.Search
{
    public class CategoryComputedField : AbstractComputedIndexField
    {
        /// <summary>
        /// Sample Computed fields for category.
        /// Note this is unneeded if field was configured for indexing, but
        /// wanted to demonstrate this as well.
        /// </summary>
        /// <param name="indexable"></param>
        /// <returns></returns>
        public override object ComputeFieldValue(IIndexable indexable)
        {
            Item item = indexable as SitecoreIndexableItem; 
            
            if (item == null || !item.TemplateName.Equals("Sample Content"))
            {
                return null;
            }

            return item.Fields["SampleContentCategory"].Value;
        }
    }
}