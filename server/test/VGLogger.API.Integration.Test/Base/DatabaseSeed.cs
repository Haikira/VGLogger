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
                Name = "Test"
            };

            database.Add(developer);
            database.SaveChanges();
        }
    }
}
