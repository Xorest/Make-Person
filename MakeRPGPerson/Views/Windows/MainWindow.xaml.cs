using System;
using System.Windows;
using System.Diagnostics;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Win32;
using System.IO;
using System.Text.Json;

namespace MakeRPGPerson
{ 
    public partial class MainWindow : Window
    {
        private Person Person;
        private List<Page> Pages;
        private MangerSkills ManagerSkills;
        public MainWindow()
        {
            InitializeComponent();
            Person = new Person();
            ManagerSkills = new MangerSkills();
            initPages();
            initContent();
        }
        private void initContent() 
        {
            if (Pages != null)
            {
                Main.Content = Pages.First();
                DataContext = Pages.First().DataContext;
            }
            else
            {
                Close();
            }
        }
        private void initPages() 
        {
            Pages = new List<Page>();
            Page pageDataPerson = new PageDataPerson(Person, ManagerSkills);
            Page pageSkillsPreson = new PageSkillsPerson(Person, ManagerSkills.availableSkills);
            Pages.Add(pageDataPerson);
            Pages.Add(pageSkillsPreson);
        }
        private void updateButton() 
        {
            ButtonBack.Visibility = Main.Content == Pages.First() ? Visibility.Hidden : Visibility.Visible;
            ButtonNext.Content = Main.Content == Pages.Last() ? ButtonNext.Content = "Ок" : ButtonNext.Content = "Дальше";
        }
        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            if (Main.Content != Pages.Last())
            {
                var nextPage = Pages.SkipWhile(x => x != Main.Content).Skip(1).DefaultIfEmpty(Pages[0]).FirstOrDefault();

                if (nextPage != null)
                {
                    Main.Content = nextPage;
                }
            }
            else 
            {
                string jsonString = JsonSerializer.Serialize(Person);
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text file (*.txt)|*.txt";

                if (saveFileDialog.ShowDialog() == true)
                    File.WriteAllText(saveFileDialog.FileName, jsonString);
            }
        }
        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            if (Main.Content != Pages.First())
            {
                var prevPage = Pages.TakeWhile(x => x != Main.Content).DefaultIfEmpty(Pages[Pages.Count - 1]).LastOrDefault();

                if (prevPage != null) 
                {
                    Main.Content = prevPage;
                }
            }
        }
        private void Main_LayoutUpdated(object sender, EventArgs e)
        {
            updateButton();
        }
    }
}
