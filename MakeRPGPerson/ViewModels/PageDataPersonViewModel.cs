using MakeRPGPerson.Models;
using MakeRPGPerson.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
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
        public PageDataPersonViewModel(Person person)
        {
            Person = person;
        }

    }
}
