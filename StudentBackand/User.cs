using System;
using System.Collections.Generic;
using System.Text;

namespace StudentBackand
{
    public class User
    {
        private string Email;
        private string FullName;
        private int Age;

        public User()
        {

        }

        public User(string Email, string FullName, int Age)
        {

            this.Email = Email;
            this.FullName = FullName;
            this.Age = Age;

        }
        public int age
        {
            get { return Age; }
            set { Age = value; }
        }
        public string email
        {
            get { return Email; }
            set { Email = value; }
        }

        public string fullName
        {
            get { return FullName; }
            set { FullName = value; }
        }
    }
}