using System;
using System.Collections.Generic;

namespace MakeRPGPerson
{
    public enum PersonClass { Org, Druid, Paladin }
    public class Person
    {
        public Person()
        {
            Name = "Name";
            Skills = new List<string>();
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public PersonClass Classification { get; set; }
        public List<string> Skills { get; set; }
    }
}
