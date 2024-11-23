using LotrSDK.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace LotrSDK.Tests
{
    [TestClass()]
    public class LotrSDKTests
    {
        private LotrSDK sdk;
        private string bearerToken;
        public TestContext TestContext { get; set; }


        [TestInitialize]
        public async Task Setup()
        {
            bearerToken = TestContext.Properties["bearerToken"].ToString();  
            sdk = new LotrSDK(bearerToken);
        }
        #region Movies
        [TestMethod()]
        public async Task Get_Movie_5cd95395de30eff6ebccde5c_Equals_TheFellowshipOftheRing_Test()
        {
            var movie = await sdk.GetMovieById("5cd95395de30eff6ebccde5c");
            Assert.AreEqual("The Fellowship of the Ring", movie.Name);
        }

        [TestMethod()]
        public async Task GetMovies_Shorter_Than_200_Mins_And_95_Plus_RottenTomatoes_Score_Test()
        {
            var filters = new List<Filter>
            {
                new Filter("200", Filter.Operator.LessThan, "runtimeInMinutes"),
                new Filter("92", Filter.Operator.GreaterThan, "rottenTomatoesScore")
            };

            var movies = await sdk.GetMovies(filters);
            Assert.AreEqual(1, movies.Count);
            Assert.AreEqual("The Two Towers", movies[0].Name);
        }

        [TestMethod()]
        public async Task Get_Movies_Longer_Than_160_Mins_And_AcademyAwardNominations_Less_Than_OrEqual_To_5_Test()
        {
            var filters = new List<Filter>
            {
                new Filter("160", Filter.Operator.GreaterThan, "runtimeInMinutes"),
                new Filter("5", Filter.Operator.LessThanOrEqual, "academyAwardNominations")
            };

            var movies = await sdk.GetMovies(filters);
            Assert.AreEqual(2, movies.Count);
            Assert.IsTrue(movies.Any(m => m.Name == "The Unexpected Journey"));
            Assert.IsTrue(movies.Any(m => m.Name == "The Desolation of Smaug"));
        }
        #endregion

        #region Quotes

        [TestMethod()]
        public async Task Get_Quotes_From_Movie_The_Fellowship_of_the_Ring_Should_Have_The_Last_Record_Of_Page5_As_5cd96e05de30eff6ebccf124_With_PageSize_100()
        {
            var filters = new List<Filter>
            {
                new Filter("5cd95395de30eff6ebccde5c", Filter.Operator.Equal, "movie")
            };
            var quotes = await sdk.GetQuotes(filters, 5, null, 100);
            Assert.IsTrue(quotes[99].Id == "5cd96e05de30eff6ebccf124");
        }

        public async Task Get_Quotes_From_Movie_The_Fellowship_of_the_Ring_Should_Include_Hes_very_fond_of_you_Test()
        {
            var filters = new List<Filter>
            {
                new Filter("5cd95395de30eff6ebccde5c", Filter.Operator.Equal, "movie"),
                new Filter("He's very fond of you.", Filter.Operator.Equal, "dialog")
            };
            var quotes = await sdk.GetQuotes(filters);
            Assert.IsTrue(quotes.Any(m => m.Dialog == "He's very fond of you."));
        }

        [TestMethod()]
        public async Task Get_Quotes_Of_Character_Equals_5cd99d4bde30eff6ebccfca7_And_Dialog_Equals_Arrghh_Test()
        {
            var filters = new List<Filter>
            {
                new Filter("5cd99d4bde30eff6ebccfca7", Filter.Operator.Equal, "character"),
                new Filter("Arrghh!", Filter.Operator.Equal, "dialog")
            };
            var quotes = await sdk.GetQuotes(filters);
            Assert.IsTrue(quotes.Any(m => m.Movie == "5cd95395de30eff6ebccde5d"));
        }

        [TestMethod()]
        public async Task Get_QuoteById_Test()
        {
            var quote = await sdk.GetQuoteById("5cd96e05de30eff6ebcced6a");
            Assert.AreEqual(quote.Movie, "5cd95395de30eff6ebccde5c");
        }


        #endregion




    }
}