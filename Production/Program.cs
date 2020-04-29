using System;
using System.Linq;
using SharprWowApi.Models.Character;
using System.Threading.Tasks;
using SharprWowApi;
using SharprWowApi.Test;

namespace Production
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            var EuClient = new WowClient(Region.EU, Locale.en_US, TestConstants.ApiKey);

            var character = await EuClient.GetCharacterAsync(
                "gloryen",
                CharacterOptions.None,
                TestConstants.EU_en_GB_Realm);

            Console.WriteLine(character.Name);
        }
    }
}
