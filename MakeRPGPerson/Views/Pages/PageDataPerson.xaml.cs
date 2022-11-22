using System;
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using MakeRPGPerson.Models;
using MakeRPGPerson.ViewModels.Base;

namespace MakeRPGPerson
{
    public partial class PageDataPerson : Page
    {
        public PageDataPerson()
        {
            InitializeComponent();
            InitaializeComboBox();
        }
        public void SetDataContext(ViewModel model) 
        {
            DataContext = model;
        }
        private void InitaializeComboBox() 
        {
            ComboBoxClassPerson.ItemsSource = Enum.GetValues(typeof(PersonClass));
            ComboBoxClassPerson.SelectedIndex = 0;
        }
        private void TextBoxPersonAge_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void TextBoxPersonAge_GotMouseCapture(object sender, System.Windows.Input.MouseEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.SelectAll();
        }
        private void TextBoxPersonName_GotMouseCapture(object sender, System.Windows.Input.MouseEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.SelectAll();
        }
    }
}
