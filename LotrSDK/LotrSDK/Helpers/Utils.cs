using Newtonsoft.Json;
using RestSharp;
using System.Xml;

namespace LotrSDK.Helpers
{
    public class Utils
    {
        public static void ApplyPaginationParamsToRequest(RestRequest request, int? page, int? offset, int? limit)
        {
            if (page.HasValue)
                request.AddParameter("page", page.Value);
            if (offset.HasValue)
                request.AddParameter("offset", offset.Value);
            if (limit.HasValue)
                request.AddParameter("limit", limit.Value);
        }
        public static void ApplyFilterToRequest(RestRequest request, List<Filter> filters)
        {
            if (filters.Any())
            {
                foreach (var filter in filters)
                {
                    request.AddQueryParameter(filter.FilterAsString, "");
                }
            }
        }

        // Gets a single entity from the endpoint
        public static async Task<T> GetOneFromApiById<T>(LotrClient client, RestRequest request)
        {
            var result = await client.RestClient.GetAsync<ApiResponse>(request);
            return JsonConvert.DeserializeObject<T>(result?.Records[0]?.ToString());
        }

        // Gets a collection using provided filters from the endpoint 
        public static async Task<List<T>> GetMultiFromApiByFilters<T>(LotrClient client, RestRequest request, List<Filter> filters, int? page=null, int? offset= null, int? limit = null)
        {
            var result = new List<T>();    
            ApplyFilterToRequest(request, filters);
            ApplyPaginationParamsToRequest(request,page,offset,limit);

            var httpResult = await client.RestClient.GetAsync<ApiResponse>(request);
            // todo there must be an easier way to do this
            foreach (var i in httpResult?.Records)
            {
                result.Add(JsonConvert.DeserializeObject<T>(i.ToString()));
            }
            return result;
        }
    }
}
