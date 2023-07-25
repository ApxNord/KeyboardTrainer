using KeyboardTrainer.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
//using System.Media;
using System.Reflection;
using System.Resources;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace KeyboardTrainer
{
    /// <summary>
    /// Логика взаимодействия для Trainer.xaml
    /// </summary>
    public partial class Trainer : Window
    {
        private Stopwatch timer;
        public ButtonViewModel ButtonViewModel { get; set; }
        public StatisticViewModel StatisticViewModel { get; set; }
        public TextViewModel TextViewModel { get; set; }

        private SoundViewModel _soundClick;
              
        private bool _isCaps = false;
        public Trainer()
        {
            InitializeComponent();
            ButtonViewModel = new ButtonViewModel(KeyBoardGrid);
            StatisticViewModel = new StatisticViewModel();
            TextViewModel = new TextViewModel();

            _soundClick = new SoundViewModel();

            StatisticViewModel.StatisticModel.Diff = (int)slider.Value;
            timer = new Stopwatch();
            DataContext = this;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (StatisticViewModel != null)
                StatisticViewModel.StatisticModel.Diff = (int)slider.Value;
        }
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            TextViewModel.GenerationRandomText(StatisticViewModel.StatisticModel.Diff, (bool)UpperCheckBox.IsChecked);
            InputText.Clear();
            StatisticViewModel.StatisticModel.Fails = 0;
            timer.Start();

            StopButton.IsEnabled = true;
            StopButton.Style = (Style)Application.Current.Resources["EnabledColorButton"];
            StartButton.IsEnabled = false;

            PreviewKeyDown += Window_PreviewKeyDown;
            PreviewKeyUp += Window_PreviewKeyUp;
        }
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            _soundClick.PlaySoundClickButton();
            Space.Focus();
            if (e.Key == Key.System) // Alt
            {
                ButtonViewModel.PressButtonDown(e.SystemKey);
                return;
            }
            if (e.Key == Key.Capital || e.Key == Key.LeftShift || e.Key == Key.RightShift) // CapsLock and Shift
            {
                _isCaps = !_isCaps;
                ButtonViewModel.ButtonContentInitialization(_isCaps);
            }
            try
            {
                if (!TextViewModel.IsCorrectText(ButtonViewModel.PressButtonDown(e.Key)))
                    StatisticViewModel.StatisticModel.Fails++;
            }
            catch { }

            if (TextViewModel.IsFinishText())
            {
                MessageBox.Show("End!");
                timer.Stop();
            }          
        }
        private void Window_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftShift || e.Key == Key.RightShift)
            {
                _isCaps = !_isCaps;
                ButtonViewModel.ButtonContentInitialization(_isCaps);
            }
            if((e.Key != Key.Capital && _isCaps) || !_isCaps) ButtonViewModel.PressButtonUp((e.Key == Key.System)?e.SystemKey: e.Key);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           DispatcherTimer t = new DispatcherTimer();
            t.Interval = TimeSpan.FromSeconds(1);
            t.Tick += (s, args) => StatisticViewModel.StatisticModel.Speed = InputText.Text.Length / ((int)timer.Elapsed.TotalMinutes + 1);
            t.Start();          
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            StartButton.Style = (Style)Application.Current.Resources["EnabledColorButton"];
            StopButton.Style = (Style)Application.Current.Resources["NotEnabledColorButton"];
            StopButton.IsEnabled = false;
            StartButton.IsEnabled = true;

            PreviewKeyDown -= Window_PreviewKeyDown;
            PreviewKeyUp -= Window_PreviewKeyUp;
        }
    }
}
