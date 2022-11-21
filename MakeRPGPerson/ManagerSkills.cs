using System.Collections.Generic;
using System.Collections.ObjectModel;
using MakeRPGPerson.Models;

namespace MakeRPGPerson
{
    public class MangerSkills
    {
        public Dictionary<PersonClass, List<string>> mapSkills;
        public ObservableCollection<string> availableSkills { get; set; }
        public MangerSkills()
        {
            availableSkills = new ObservableCollection<string>();
            initSkills();
        }
        public void updateAvailableSkills(PersonClass? Classification)
        {
            if (Classification != null) 
            {
                availableSkills.Clear();

                foreach (var s in mapSkills[(PersonClass)Classification]) 
                {
                    availableSkills.Add(s);
                }
            }
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
