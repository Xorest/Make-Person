using MakeRPGPerson.Infrastructure.Commands;
using MakeRPGPerson.Models;
using MakeRPGPerson.ViewModels.Base;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MakeRPGPerson.ViewModels
{
    public class PageSkillsPersonViewModel : ViewModel
    {
        #region Person
        private Person _Person;
        public Person Person
        {
            get => _Person;
            set => Set(ref _Person, value);
        }
        #endregion
        #region Skills
        private List<string> _Skills;
        public List<string> Skills
        {
            get => _Skills;
            set => Set(ref _Skills, value);
        }
        #endregion

        #region Commands

        #region ListViewSkillsSelectionChangedCommand
        public ICommand ListViewSkillsSelectionChangedCommand { get; }
        private bool CanListViewSkillsSelectionChangedCommandExecute(object p) => true;
        private void OnListViewSkillsSelectionChangedCommandExecuted(object p)
        {
            if (!(p is ListView listView)) return;
            Person.Skills.Clear();

            foreach (var item in listView.SelectedItems)
            {
                Person.Skills.Add(item.ToString());
            }

            if (listView.SelectedItems.Count == 0)
            {
                if (listView.Items != null)
                {
                    listView.SelectedValue = listView.Items[0];
                }
            }
        }
        #endregion
        #region ListViewSkillsLoadedCommand
        public ICommand ListViewSkillsLoadedCommand { get; }
        private bool CanListViewSkillsLoadedCommandExecute(object p) => true;
        private void OnListViewSkillsLoadedCommandExecuted(object p)
        {
            if (!(p is ListView listView)) return;

            if (listView.SelectedItems.Count == 0) 
            {
                listView.SelectedIndex = 0;
                Person.Skills.Clear();
                Person.Skills.Add(Skills[0]);
            }
        }
        #endregion

        #endregion

        public Dictionary<PersonClass, List<string>> MapSkills { get; set; }
        public PageSkillsPersonViewModel(Person person, Dictionary<PersonClass, List<string>> mapSkills)
        {
            Person = person;
            Person.ClassificationUpdate += UpdateSkills;
            Skills = mapSkills[Person.Classification];
            MapSkills = mapSkills;
            Person.Skills.Add(Skills[0]);
            #region Commands
            ListViewSkillsSelectionChangedCommand = new LambdaCommand(OnListViewSkillsSelectionChangedCommandExecuted, 
                                                                    CanListViewSkillsSelectionChangedCommandExecute);
            ListViewSkillsLoadedCommand = new LambdaCommand(OnListViewSkillsLoadedCommandExecuted, CanListViewSkillsLoadedCommandExecute);
            #endregion
        }
        private void UpdateSkills(PersonClass classification) => Skills = MapSkills[classification]; 
    }
}
