using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHub.ApplicationCore.Entities;
using TestHub.ApplicationCore.Interfaces;
using TestHub.Infrastructure.Data;

namespace TestHub.Infrastructure
{
    public class TestRepository : IRepository
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
