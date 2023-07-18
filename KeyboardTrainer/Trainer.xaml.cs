using KeyboardTrainer.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KeyboardTrainer
{
    /// <summary>
    /// Логика взаимодействия для Trainer.xaml
    /// </summary>
    public partial class Trainer : Window
    {
        private ResourceManager _upperChar;
        private ResourceManager _lowerChar;

        private Dictionary<Button, Style> _originalStyle; // для сохранения изначального стиля кнопки

        public Trainer()
        {
            InitializeComponent();
            _upperChar = new ResourceManager("KeyboardTrainer.Properties.CharacterUpper", Assembly.GetExecutingAssembly());
            _lowerChar = new ResourceManager("KeyboardTrainer.Properties.CharacterLower", Assembly.GetExecutingAssembly());
            ButtonContentInitialization(_lowerChar);

            _originalStyle = new Dictionary<Button, Style>();
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
                        _originalStyle.Add(button, button.Style);
                        button.Style = (Style)Application.Current.Resources["PressButtonColor"];
                    }

        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            foreach (Grid b in KeyBoardGrid.Children)
                foreach (Button button in b.Children)
                    if (e.Key.ToString() == button.Name)
                    {
                        button.Style = _originalStyle[button];
                        _originalStyle.Remove(button);
                    }
        }
    }
}
