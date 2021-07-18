using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace Rest.net5.Hypermedia.Abstract
{
    public interface IResponseEnricher
    {
        bool CanEnrich(ResultExecutingContext context);

        Task Enrich(ResultExecutingContext context);
    }
}
