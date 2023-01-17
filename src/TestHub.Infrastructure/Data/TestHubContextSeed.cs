using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHub.ApplicationCore.Entities;

namespace TestHub.Infrastructure.Data
{
    public static class TestHubContextSeed
    {
        public static async Task SeedAsync(TestHubContext context)
        {
            if (!context.Database.GetService<IRelationalDatabaseCreator>().Exists())
            {
                context.Database.EnsureDeleted();
                context.Database.Migrate();
            }
                
            await context.Tests.AddAsync(GetTest());
            await context.SaveChangesAsync();
        }

        private static Test GetTest()
        {
            var user = new User("Mock");
            var test = new Test(user, "Animals", "Trial test", 0.8m, TimeSpan.FromMinutes(10), 2);
            var q1 = new FalseTrueQuestion(test, "Choose TRUE or FALSE", 10, "Sharks are mammals.", false);
            test.AddQuestion(q1);
            var q2 = new FalseTrueQuestion(test, "Choose TRUE or FALSE", 10, "Sea otters have a favorite rock they use to break open food.", true);
            test.AddQuestion(q2);
            var q3 = new FalseTrueQuestion(test, "Choose TRUE or FALSE", 10, "The blue whale is the biggest animal to have ever lived.", true);
            test.AddQuestion(q3);
            var q4 = new FalseTrueQuestion(test, "Choose TRUE or FALSE", 10, "The hummingbird egg is the world's smallest bird egg.", true);
            test.AddQuestion(q4);
            var q5 = new FalseTrueQuestion(test, "Choose TRUE or FALSE", 10, "Pigs roll in the mud because they don’t like being clean.", false);
            test.AddQuestion(q5);
            var q6 = new FalseTrueQuestion(test, "Choose TRUE or FALSE", 10, "Bats are blind.", false);
            test.AddQuestion(q6);
            var q7 = new FalseTrueQuestion(test, "Choose TRUE or FALSE", 10, "A dog sweats by panting its tongue.", false);
            test.AddQuestion(q7);
            var q8 = new FalseTrueQuestion(test, "Choose TRUE or FALSE", 10, "It takes a sloth two weeks to digest a meal.", true);
            test.AddQuestion(q8);
            var q9 = new FalseTrueQuestion(test, "Choose TRUE or FALSE", 10, "The largest living frog is the Goliath frog of West Africa.", true);
            test.AddQuestion(q9);
            var q10 = new FalseTrueQuestion(test, "Choose TRUE or FALSE", 10, "An ant can lift 1,000 times its body weight.", false);
            test.AddQuestion(q10);

            return test;
        }
    }
}
