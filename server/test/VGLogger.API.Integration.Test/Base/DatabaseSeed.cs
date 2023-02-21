using VGLogger.DAL.Context;
using VGLogger.DAL.Models;

namespace VGLogger.API.Integration.Test.Base
{
    public static class DatabaseSeed
    {
        public static void SeedDatabase(VGLoggerContext database)
        {
            var developer = new Developer
            {
                Id = 1,
                Name = "TestDeveloper"
            };

            var platform = new Platform
            {
                Id = 1,
                Name = "TestPlatform"
            };

            var game = new Game 
            { 
                Description = "",
                Developer = developer,
                DeveloperId = developer.Id,
                GamePlatforms = new List<GamePlatform>(),
                Id = 1,
                Name = "TestGame"
            };

            database.Add(developer);
            database.Add(platform);
            database.Add(game);

            database.SaveChanges();
        }
    }
}
