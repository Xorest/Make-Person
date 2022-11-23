using System.Collections.ObjectModel;
using System.Windows.Controls;
using System;
using MakeRPGPerson.Models;
using MakeRPGPerson.ViewModels.Base;
using System.Diagnostics;

namespace MakeRPGPerson
{
    public partial class PageSkillsPerson : Page
    {
        public PageSkillsPerson() => InitializeComponent();
        public void SetDataContext(ViewModel model) => DataContext = model;
    }
}
