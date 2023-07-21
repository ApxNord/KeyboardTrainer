using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Resources;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace KeyboardTrainer
{
    /// <summary>
    /// Логика взаимодействия для Trainer.xaml
    /// </summary>
    public partial class Trainer : Window
    {
        public ButtonViewModel ButtonViewModel { get; set; }
        public StatisticViewModel StatisticViewModel { get; set; }

        private bool _isCaps = false;
        public Trainer()
        {
            InitializeComponent();
            ButtonViewModel = new ButtonViewModel(KeyBoardGrid);
            StatisticViewModel = new StatisticViewModel();

            DataContext = this;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.System) // Alt
            {
                ButtonViewModel.PressButtonDown(e.SystemKey);
                return;
            }
            if (e.Key == Key.Capital) // CapsLock
            {
                _isCaps = !_isCaps;
                ButtonViewModel.ButtonContentInitialization(_isCaps);
            }        

            ButtonViewModel.PressButtonDown(e.Key);

        }
        private void Window_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.System)
            {
                ButtonViewModel.PressButtonUp(e.SystemKey);
                return;
            }
            ButtonViewModel.PressButtonUp(e.Key);
        }

    }
}
