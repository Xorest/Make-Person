using MakeRPGPerson.Infrastructure.Commands;
using MakeRPGPerson.Models;
using MakeRPGPerson.ViewModels.Base;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Controls;
using System.Windows.Input;

namespace MakeRPGPerson.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private Person Person;
        private List<Page> Pages;
        private ManagerSkills ManagerSkills;

        #region SelectedPage
        private Page _SelectedPage;
        public Page SelectedPage 
        {
            get => _SelectedPage;
            set => Set(ref _SelectedPage, value);
        }
        #endregion

        #region Commands
        #region BakсPageCommand
        public ICommand BakсPageCommand { get; }
        private bool CanBakсPageCommandExecute(object p) => SelectedPage != Pages.First();
        private void OnBakсPageCommandExecuted(object p)
        {
            var prevPage = Pages.TakeWhile(x => x != SelectedPage).DefaultIfEmpty(Pages[Pages.Count - 1]).LastOrDefault();

            if (prevPage != null)
            {
                SelectedPage = prevPage;
            }
        }
        #endregion
        #region NextPageCommand
        public ICommand NextPageCommand { get; }
        private bool CanNextPageCommandExecute(object p) => true;
        private void OnNextPageCommandExecuted(object p)
        {
            if (SelectedPage != Pages.Last())
            {

                var nextPage = Pages.SkipWhile(x => x != SelectedPage).Skip(1).DefaultIfEmpty(Pages[0]).FirstOrDefault();

                if (nextPage != null)
                {
                    SelectedPage = nextPage;
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
        #endregion
        #endregion


        public MainWindowViewModel()
        {
            Person = new Person();
            ManagerSkills = new ManagerSkills();
            initPages();
            SelectedPage = Pages.First();
            #region Commands
            BakсPageCommand = new LambdaCommand(OnBakсPageCommandExecuted, CanBakсPageCommandExecute);
            NextPageCommand = new LambdaCommand(OnNextPageCommandExecuted, CanNextPageCommandExecute);
            #endregion
        }

        private void initPages()
        {
            Pages = new List<Page>();
            PageDataPerson pageDataPerson = new PageDataPerson();
            pageDataPerson.SetDataContext(new PageDataPersonViewModel(Person));
            PageSkillsPerson pageSkillsPreson = new PageSkillsPerson();
            pageSkillsPreson.SetDataContext(new PageSkillsPersonViewModel(Person, ManagerSkills.mapSkills));
            Pages.Add(pageDataPerson);
            Pages.Add(pageSkillsPreson);
        }
    }
}
