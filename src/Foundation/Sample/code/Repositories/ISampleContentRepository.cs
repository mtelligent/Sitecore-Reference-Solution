
using SF.Foundation.Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SF.Foundation.Sample.Repositories
{
    public interface ISampleContentRepository
    {
        List<SampleContentCategory> GetCategories();

        List<SampleContent> GetSampleContentByCategory(SampleContentCategory category);
    }
}