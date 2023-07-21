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

        }
        private void Window_PreviewKeyUp(object sender, KeyEventArgs e)
        {

        }

    }
}
