using LotrSDK.Helpers;
using LotrSDK.Model;
using RestSharp;

namespace LotrSDK
{
    public class LotrSDK
    {
        private string BearerToken;
        private LotrClient client;
        public LotrSDK(string bearerToken)
        {
            BearerToken = bearerToken;
            client = new LotrClient(BearerToken);
        }

        #region Movie
        public async Task<Movie> GetMovieById(string Id)
        {
            try
            {
                var request = new RestRequest("movie/{id}").AddUrlSegment("id", Id);
                return await Utils.GetOneFromApiById<Movie>(client, request);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<IList<Movie>> GetMovies(List<Filter> filters)
        {
            try
            {
                var request = new RestRequest("movie");
                return await Utils.GetMultiFromApiByFilters<Movie>(client, request, filters);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return null;
            }
        }
        #endregion

        #region Quote
        public async Task<List<Quote>> GetQuotesByMovieId(string Id, List<Filter> filters, int? page = null, int? offset = null, int? limit = null)
        {
            try
            {
                var request = new RestRequest("movie/{id}/quote").AddUrlSegment("id", Id);
                return await Utils.GetMultiFromApiByFilters<Quote>(client, request, filters, page, offset, limit);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<Quote> GetQuoteById(string Id)
        {
            try
            {
                var request = new RestRequest("quote/{id}").AddUrlSegment("id", Id);
                return await Utils.GetOneFromApiById<Quote>(client, request);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        public async Task<List<Quote>> GetQuotes(List<Filter> filters, int? page=null, int? offset=null, int? limit = null)
        {
            try
            {
                var request = new RestRequest("quote");
                return await Utils.GetMultiFromApiByFilters<Quote>(client, request, filters, page, offset, limit);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
        #endregion

        #region Character

        public async Task<Character> GetCharacterById(string Id)
        {
            try
            {
                var request = new RestRequest("character/{id}").AddUrlSegment("id", Id);
                return await Utils.GetOneFromApiById<Character>(client, request);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        #endregion
    }
}
