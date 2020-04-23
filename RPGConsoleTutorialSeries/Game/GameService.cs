using System;
using System.IO;
using Newtonsoft.Json;
using RPGConsoleTutorialSeries.Adventures;

namespace RPGConsoleTutorialSeries.Game
{
    public class GameService
    {
        public void StartGame()
        {
            var basePath = $"{AppDomain.CurrentDomain.BaseDirectory}adventures";
            var initialAdventure = new Adventure();

            if (File.Exists($"{basePath}\\initial.json"))
            {
                var directory = new DirectoryInfo(basePath);
                var initialJsonFile = directory.GetFiles("initial.json");

                using (StreamReader fi = File.OpenText(initialJsonFile[0].FullName))
                {
                    initialAdventure = JsonConvert.DeserializeObject<Adventure>(fi.ReadToEnd());
                }

                Console.WriteLine($"Adventure : {initialAdventure.Title}");
                Console.WriteLine($"Description : {initialAdventure.Description}");
            }
        }
    }
}
