using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MDK0503_Pract_Test1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Catet1_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Catet1.Text == "Сторона 1") 
            { Catet1.Clear(); }
            else { return ; }
            
        }

        private void Catet2_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Catet2.Text == "Сторона 2")
            { Catet2.Clear(); }
            else { return; }
        }

        private void Gipotenuza_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Gipotenuza.Text == "Сторона 3")
            { Gipotenuza.Clear(); }
            else { return; }
        }



        private static readonly Regex _regex = new Regex("[^0-9.]+"); 
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }

        private void Catet1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
            Catet1.MaxLength = 3;
        }

        private void Catet2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
            Catet2.MaxLength = 3;
        }

        private void Gipotenuza_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
            Gipotenuza.MaxLength = 3;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Catet1.Text == "Сторона 1" || Catet2.Text == "Сторона 2" || Gipotenuza.Text == "Сторона 3")
            { MessageBox.Show("Вы не ввели одну/несколько из сторон"); }
            else
            resultat.Opacity = 100;
            if (Catet1.Text == "0" || Catet2.Text == "0" || Gipotenuza.Text == "0")
            { resultat.Text = "Одна из сторон равна нулю\n расчёт невозможен"; }
            if (Catet1.Text == Catet2.Text && Catet2.Text == Gipotenuza.Text)
            { resultat.Text = "Ваш треугольник - Равносторонний"; }
            else if (Catet1.Text == Catet2.Text || Catet1.Text == Gipotenuza.Text || Catet2.Text == Gipotenuza.Text)
            { resultat.Text = "Ваш треугольник - Равнобедренный"; }
            else if (Catet1.Text != Catet2.Text && Catet2.Text != Gipotenuza.Text)
            { resultat.Text = "Ваш треугольник - Разносторонний"; }
        }
    }
}
