using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MakeRPGPerson.Models
{
    public class ManagerSkills
    {
        public Dictionary<PersonClass, List<string>> mapSkills;
        public ManagerSkills()
        {
            initSkills();
        }
        private void initSkills()
        {
            mapSkills = new Dictionary<PersonClass, List<string>>();
            mapSkills.Add(PersonClass.Org, new List<string> { "Byu Silno", "Mnogo Zdorovie", "otkidivaet", "zloy", "Visokiy" });
            mapSkills.Add(PersonClass.Paladin, new List<string> { "Letaet", "Mag", "Strelaet Ognom", "Legkyy", "Nizkyy" });
            mapSkills.Add(PersonClass.Druid, new List<string> { "Nevidimy", "visoky intelect", "dalniy boy", "legky", "strelaey ldom" });
        }
    }
}
