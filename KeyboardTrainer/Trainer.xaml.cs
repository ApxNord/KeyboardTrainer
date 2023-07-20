using System.Collections.Generic;
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
        int index = 0;

        private ResourceManager _upperChar; // файл ресурсов верхнего регистра
        private ResourceManager _lowerChar; // файл ресурсов нижнего регистра

        private Dictionary<Button, Style> _originalStyle; // для сохранения изначального стиля кнопки

        private bool IsCaps = false; // нажата ли клавиша CapsLock

        public Statistic Stat { get; set; }
        public Trainer()
        {
            InitializeComponent();
            _upperChar = new ResourceManager("KeyboardTrainer.Properties.CharacterUpper", Assembly.GetExecutingAssembly());
            _lowerChar = new ResourceManager("KeyboardTrainer.Properties.CharacterLower", Assembly.GetExecutingAssembly());
            ButtonContentInitialization(_lowerChar);

            _originalStyle = new Dictionary<Button, Style>();
            Stat = new Statistic();
            Stat.Diff = (int)slider.Value;
            this.DataContext = this;
        }
        /// <summary>
        /// Для инициализации контента кнопок на форме Trainer.xaml
        /// </summary>
        /// <param name="resource">Передаваемый файл ресурсов (верхний или нижний регистр символов)</param>
        private void ButtonContentInitialization(ResourceManager resource)
        {
            foreach (Grid items in KeyBoardGrid.Children)
            {
                foreach (Button button in items.Children)
                {
                    button.Content = resource.GetString(button.Name);
                }
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            
            foreach (Grid b in KeyBoardGrid.Children)
                foreach (Button button in b.Children)
                    if (e.Key.ToString() == button.Name)
                    {
                        if (!_originalStyle.ContainsKey(button))
                            _originalStyle.Add(button, button.Style);
                        button.Style = (Style)Application.Current.Resources["PressButtonColor"];

                        if (OutputText.Text[index] == char.Parse(button.Content.ToString()))
                        {
                            InputText.Text += button.Content.ToString();
                            ReInputText.Text += button.Content.ToString();
                            index++;
                        }
                        break;
                    }

            if (e.Key == Key.Capital)
            {
                IsCaps = !IsCaps;
            }
            if (e.Key == Key.LeftShift || e.Key == Key.RightShift || IsCaps)
                ButtonContentInitialization(_upperChar);
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            foreach (Grid b in KeyBoardGrid.Children)
                foreach (Button button in b.Children)
                    if (e.Key.ToString() == button.Name)
                    {
                        if (e.Key == Key.Capital && IsCaps) break;
                        if (_originalStyle.ContainsKey(button))
                        {
                            button.Style = _originalStyle[button];
                            _originalStyle.Remove(button);
                            break;
                        }
                    }
            if (!IsCaps) ButtonContentInitialization(_lowerChar);
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Stat != null)
                Stat.Diff = (int)((Slider)sender).Value;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Space.Focus();
            if (OutputText != null) OutputText.Text = "";
            OutputText.Text += Stat.GenerationRandomText();
        }
    }
}
