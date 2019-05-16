using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Converters;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SF.Foundation.Sample.Models
{
    public class SampleContentSearchResultItem : Sitecore.ContentSearch.SearchTypes.SearchResultItem
    {
        [IndexField("categoryid")]
        public string Category { get; set; } 

    }
}