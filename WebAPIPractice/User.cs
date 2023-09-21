using WebAPIPractice.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.OpenApi.Any;

namespace WebAPIPractice
{
    public class User
    {
        public string Tc { get; set; }

        public int id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        private string Password { get; set; }
        public User(int id, string tc, string name, int age)
        {
            this.id = id;
            Tc = tc;
            Name = name;
            Age = age;
        }
        public User(int id, string tc, string name)
        {
            this.id = id;
            Tc = tc;
            Name = name;
        }

    }

}
