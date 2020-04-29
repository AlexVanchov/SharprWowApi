using System;
using System.Linq;
using SharprWowApi.Models.Character;
using System.Threading.Tasks;
using SharprWowApi;

namespace Production
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            var EuClient = new WowClient(Region.EU, Locale.en_US, "USpzMAwiSefCBT0DXdqByqcv5VErEkZ8Bx");

            var character = await EuClient.GetCharacterAsync(
                "gloryen",
                CharacterOptions.None,
                "turalyon");

            Console.WriteLine(character.Name);
        }
    }
}
