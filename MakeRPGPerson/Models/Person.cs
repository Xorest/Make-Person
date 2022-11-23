using System.Collections.Generic;

namespace MakeRPGPerson.Models
{
    public enum PersonClass { Org, Druid, Paladin }
    public delegate void ClassificationUpdate(PersonClass _Classification);
    public class Person
    {
        public event ClassificationUpdate ClassificationUpdate = null;
        public Person()
        {
            Name = "Имя";
            Classification = PersonClass.Org;   
            Skills = new List<string>();
        }
        public string Name { get; set; }
        public int Age { get; set; }
        #region Classification
        private PersonClass _Classification;
        public PersonClass Classification 
        {
            get => _Classification;
            set 
            {
                if (_Classification == value) return;
                _Classification = value;
                ClassificationUpdate.Invoke(_Classification);
            }
        }
        #endregion
        public List<string> Skills { get; set; }

    }
}
