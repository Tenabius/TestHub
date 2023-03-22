using Microsoft.AspNetCore.Identity;
using TestHub.Core.Entities;

namespace TestHub.Infrastructure
{ 
    public class TestAttemptInfo
    {
        public IdentityUser Candidate { get; private set; }
        public Test Test { get; private set; }
        public DateTimeOffset StartTime { get; private set; }
        public TimeSpan Expiration { get; private set; }

#pragma warning disable CS8618
        private TestAttemptInfo() { }
#pragma warning restore

        public TestAttemptInfo(IdentityUser candidate, Test test, DateTimeOffset startTime, TimeSpan expiration)
        {
            Candidate = candidate;
            Test = test;
            StartTime = startTime;
            Expiration = expiration;
        }
    }
}
