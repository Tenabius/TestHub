using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHub.ApplicationCore.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public User(string name)
        {
            Name = name;
        }
    }
}
