using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHub.Core.Entities;
using TestHub.Core.Interfaces;
using TestHub.Infrastructure.Data.Models;

namespace TestHub.Infrastructure
{
    public class TestRepository : IRepository<Test>
    {
        private readonly TestHubContext _context;

        public TestRepository(TestHubContext context)
        {
            _context = context;
        }

        public Test GetById(int id)
        {
            return _context.Tests.First(x => x.Id == id);
        }

    }
}
