using System;

namespace Multiscan.Entities
{
    public class User
    {
        public User() { }

        public User(string username, string password) { }

        public int id { get; set; }
        public int username { get; set; }
        public Role role { get; set; }

        public enum Role
        {
            Admin = 1,
            Operator = 0
        }

        public void Login() { }
    }
};
