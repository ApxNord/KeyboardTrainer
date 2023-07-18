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
        ResourceManager resManager;
        public Trainer()
        {
            InitializeComponent();
            resManager = new ResourceManager("KeyboardTrainer.Properties.CharacterLower", Assembly.GetExecutingAssembly());
            foreach (Grid items in KeyBoardGrid.Children)
            {
                foreach (Button button in items.Children)
                {
                    button.Content = resManager.GetString(button.Name);
                }
            }
        }
    }
}
