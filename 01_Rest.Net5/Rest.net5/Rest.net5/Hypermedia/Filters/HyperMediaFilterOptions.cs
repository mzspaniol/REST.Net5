using Rest.net5.Hypermedia.Abstract;
using System.Collections.Generic;

namespace Rest.net5.Hypermedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}
