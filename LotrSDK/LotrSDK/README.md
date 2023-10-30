# Lord of the Rings C# SDK Using RestSharp Library

This C# SDK  allows to consume Lord of the Rings API endpoints easily, which are  available on https://the-one-api.dev/documentation. The current implementation supports retrieving of Movie and Quote
objects as collection or  individually,  the results are converted to type safe C# models listed under Model folder. 
Some form of filtering is also supported as described below. 
 In this version the below endpoints are implemented:

| Endpoint | Description| Corresponding SDK Method| 
-----------|------------|-------------------------|
|/quote         | List of all movie quotes  | `public async Task<List<MovieQuote>> GetQuotes(List<Filter> filters) `|                         |
|/quote/{id}    | Request one specific movie quote | `public async Task<MovieQuote> GetQuote(string Id)`        |        
|/movie         | List of all movies, including the "The Lord of the Rings" and the "The Hobbit" trilogies |  `public async Task<List<Movie>> GetMovies(List<Filter> filters) `|
|/movie/{id}    | Request one specific movie | `public async Task<Movie> GetMovie(string Id)`     | 
|/movie/{id}/quote | Request all movie quotes for one specific movie (only working for the LotR trilogy) |              `public async Task<List<MovieQuote>> GetQuotesByMovie(string Id)                                                         ` |

The SDK targets .Net Standard 2.0 which supports below .Net implementations:

| .NET implementation |	Version support|
|----------------------|--------------------|
|.NET and .NET Core |	2.0, 2.1, 2.2, 3.0, 3.1, 5.0, 6.0, 7.0|
|.NET Framework    |	4.6.1 2, 4.6.2, 4.7, 4.7.1, 4.7.2, 4.8, 4.8.1|
 https://learn.microsoft.com/en-us/dotnet/standard/net-standard?tabs=net-standard-2-0

For the endpoints that takes <code>`List<Filter>`</code> as parameter, you can create the filters as below:
<code>
  public async Task GetMoviesShorterThan200MinsAnd95PlusRottenTomatoesTest()
  {
      var filters = new List`<Filter>`();
      filters.Add(new Filter("200", Filter.Operator.LessThan, "runtimeInMinutes"));
      filters.Add(new Filter("92", Filter.Operator.GreaterThan, "rottenTomatoesScore"));
      var movies = await sdk.GetMovies(filters);
      ..
  }
  </code>
  The SDK is created using Visual Studio. The solution file is  LotrSDK/LotrSDK.sln which opens both the SDK project(a class library named as "LotrSDK") and Integration Test Project.
  To use the SDK you need to  reference the LotrSDK class library. The Integration Test Project("LotrSDKClientTests") references it and contains the tests for the methods of 
  the SDK project . 

 ## Instructions:

1. Create an account on  https://the-one-api.dev/sign-up 
2. Clone this repo in your pc
3. Open the solution file (Preferably with Visual Studio) 
4. Add your bearer token on  line 81 in the .runsettings file under LotrSDKTests project
5. Run Unit tests

## TODO LIST: 
1. Only 5 endpoints are covered so far
2. More Tests need to be added
