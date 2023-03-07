﻿namespace TestHub.Core.Entities
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
