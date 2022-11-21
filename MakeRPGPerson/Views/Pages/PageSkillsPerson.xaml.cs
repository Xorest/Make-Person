using System.Collections.ObjectModel;
using System.Windows.Controls;
using System;
using MakeRPGPerson.Models;

namespace MakeRPGPerson
{
    public partial class PageSkillsPerson : Page
    {
        public Person Person { get; set; }
        public ObservableCollection<string> Skills { get; set; }
        public PageSkillsPerson(Person person, ObservableCollection<string> skills)
        {
            InitializeComponent();
            DataContext = this;
            Person = person;
            Skills = skills;
        }
        private void UpdateListView() 
        {
            if (Person.Skills.Count != 0)
            {
                foreach (var item in ListViewSkills.Items)
                {
                    if (Person.Skills.Contains(item.ToString()))
                    {
                        ListViewSkills.SelectedItems.Add(item);
                    }
                }
            }
            else 
            {
                if (ListViewSkills.Items.Count != 0) 
                {
                    ListViewSkills.SelectedItems.Add(ListViewSkills.Items[0]);
                }
            }
        }
        private void ListViewSkills_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView listView = (ListView)sender;
            Person.Skills.Clear();

            foreach (var i in listView.SelectedItems) 
            {
                Person.Skills.Add(i.ToString());
            }

            UpdateListView();
        }
        private void ListViewSkills_LayoutUpdated(object sender, EventArgs e)
        {
            UpdateListView();
        }
    }
}
