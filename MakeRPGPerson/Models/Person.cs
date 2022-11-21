using System;
using System.Collections.Generic;

namespace MakeRPGPerson.Models
{
    public enum PersonClass { Org, Druid, Paladin }
    public class Person
    {
        public Person()
        {
            Name = "Имя";
            Skills = new List<string>();
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public PersonClass Classification { get; set; }
        public List<string> Skills { get; set; }
    }
}
