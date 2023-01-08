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
    public class TestHubContextSeed
    {
        public static async Task SeedAsync(TestHubContext context)
        {
            if (!context.Database.GetService<IRelationalDatabaseCreator>().Exists())
                context.Database.Migrate();

            await context.Tests.AddAsync(GetTest());
            await context.SaveChangesAsync();
        }

        private static Test GetTest()
        {
            var user = new User("Mock");
            var test = new Test(user, "Animals", "Trial test", 0.8m, TimeSpan.FromMinutes(10), 2);
            var q1 = new FalseTrueQuestion(test, "Sharks are mammals.", 10, false);
            test.AddQuestion(q1);
            var q2 = new FalseTrueQuestion(test, "Sea otters have a favorite rock they use to break open food.", 10, true);
            test.AddQuestion(q2);
            var q3 = new FalseTrueQuestion(test, "The blue whale is the biggest animal to have ever lived.", 10, true);
            test.AddQuestion(q3);
            var q4 = new FalseTrueQuestion(test, "The hummingbird egg is the world's smallest bird egg.", 10, true);
            test.AddQuestion(q4);
            var q5 = new FalseTrueQuestion(test, "Pigs roll in the mud because they don’t like being clean.", 10, false);
            test.AddQuestion(q5);
            var q6 = new FalseTrueQuestion(test, "Bats are blind.", 10, false);
            test.AddQuestion(q6);
            var q7 = new FalseTrueQuestion(test, "A dog sweats by panting its tongue.", 10, false);
            test.AddQuestion(q7);
            var q8 = new FalseTrueQuestion(test, "It takes a sloth two weeks to digest a meal.", 10, true);
            test.AddQuestion(q8);
            var q9 = new FalseTrueQuestion(test, "The largest living frog is the Goliath frog of West Africa.", 10, true);
            test.AddQuestion(q9);
            var q10 = new FalseTrueQuestion(test, "An ant can lift 1,000 times its body weight.", 10, false);
            test.AddQuestion(q10);

            return test;
        }
    }
}
