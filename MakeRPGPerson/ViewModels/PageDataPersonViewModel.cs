using MakeRPGPerson.Models;
using MakeRPGPerson.ViewModels.Base;
using System;
using System.Diagnostics;
using System.Windows.Controls;

namespace MakeRPGPerson.ViewModels
{
    public class PageDataPersonViewModel : ViewModel
    {
        #region Person
        private Person _Person;
        public Person Person 
        { 
            get => _Person;
            set => Set(ref _Person, value);
        }
        #endregion
        #region MangerSkills
        private MangerSkills _MangerSkills;
        public MangerSkills MangerSkills
        { 
            get => _MangerSkills;
            set => Set(ref _MangerSkills, value);
        }
        #endregion
        public PageDataPersonViewModel() 
        {
            Trace.WriteLine("defualt const");
        }
        public PageDataPersonViewModel(Person person, MangerSkills mangerSkills)
        {
            Trace.WriteLine("constructor with parametrs");
            Person = person;
            MangerSkills = mangerSkills;
            //ComboBoxClassPerson.ItemsSource = Enum.GetValues(typeof(PersonClass));
            //ComboBoxClassPerson.SelectedIndex = 0;
        }

    }
}
