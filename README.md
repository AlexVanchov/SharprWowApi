###SharprWowApi
SharprWowApi is a strongly typed .NET library for accessing blizzards Wow API (https://dev.battle.net/).


#####Changelog
__01-21__ Initial Commit

## Usage example

#####Get achievement By ID

```c#
var client = ApiClient(Region.Eu, Locale.en_GB, ApiKey.Value);
var achievement = client.GetAchievement(2144);
Console.WriteLine(achievement.Title);
```  

#####Get Character by realm and name

```c#
var client = new ApiClient(Region.EU, Locale.en_GB, ApiKey.Value);

var characterOne = client.GetCharacter("Grim Batol", "Hjortronsmak", CharacterOptions.None);
var characterTwo = client.GetCharacter("Xavius", "Tuds", CharacterOptions.GetPvP);

Console.WriteLine(character.Name);
Console.WriteLine(character.Pvp.Brackets.Arena_Bracket_2v2.Rating);
```
You can also set __realm__ in the _ApiClient_ and use overloaded methods if all characters you're getting are from the same realm.

```C#
client = new ApiClient(Region.EU, Locale.en_GB, "Grim Batol", ApiKey.Value);

var characterOne = client.GetCharacter("Hjortronsmak", CharacterOptions.None);
var characterTwo = client.GetCharacter("xzy", CharacterOptions.None);
var characterThree = client.GetCharacter("Lingonberry", CharacterOptions.None);

Console.WriteLine(characterOne.Name);
Console.WriteLine(characterTwo.Name);
Console.WriteLine(characterThree.Name);
```

#####Usage example ASP.NET MVC
Returns a strongly typed _GuildRoot_ object to the view.
```C#
using SharprWowApi.Models.Guild;

public ActionResult Members()
{
    var client = new ApiClient(Region.EU, Locale.en_GB, "Grim Batol", ApiKey.Value);
    var guild = client.GetGuild("Guild name", GuildOptions.GetEverything);
    
     return View(guild);
}
```
```html
@model SharprWowApi.Models.Guild.GuildRoot

<div class="tab-ctrl" id="tabCtrl">
    <div id="page1" class="main-page">
    
       @foreach (var member in Model.Members.OrderByDescending(m => m.Character.Class))
        {
                Do something
        }
...
```


#####Async
Since some of the data returned by blizzards wow API is quite big (especially auction data & PVP leaderboard), it can be a good idea to use the async methods even though the json parsing is not async. Since it offloads it to a new thread.  (https://github.com/JamesNK/Newtonsoft.Json/issues/66). 

```C#
var client = new ApiClient(Region.EU, Locale.en_GB, ApiKey.Value);
var getAuctionFile = client.GetAuctionFile("Grim batol");
var someCachedValue = "...";

var lm = from f in getAuctionFile.Files
            select f.LastModified;

  if (!lm.Equals(someCachedValue))
  {
    var getAuction = await client.GetAuctionsAsync("Grim batol");
    var auction = getAuction.Auctions.Auction;
    
     foreach (var a in auction.Take(5))
     {
      Console.WriteLine(a.owner);
     }
 ...
```