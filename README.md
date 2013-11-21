AniDb.Api
---------

AniDb.Api is wrapper for [www.anidb.info](www.anidb.info) api. Now it's provides only implementation of http api and only parts that could interest client such as:

 * anime
 * categories
 * hot

For detailed api description please check [wiki page](http://wiki.anidb.info/w/HTTP_API_Definition).

Usage
------

Retreive info from anime api:
```csharp
var client = new ClientCredentials("xxx", 1); // you could register it here http://anidb.net/perl-bin/animedb.pl?show=client
var aid = 1; // should be taken from http://anidb.net/api/anime-titles.dat.gz
var request = HttpRequests.CreateToAnime(client, aid);
var response = await request.GetResponseAsync();
var animeReader = new AnimeReader();
var anime = response.Read(animeReader);
```

From categories api:
```csharp
var client = new ClientCredentials("xxx", 1);
var request = HttpRequests.CreateToCategory(client);
var response = await request.GetResponseAsync();
var categoryReader = new CategoryReader();
var categories = response.Read(categoryReader);
```

Hot api is the same as previous two.