using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KeyboardTrainer
{
    public class ButtonViewModel
    {
        private ResourceManager _upperChar; // файл ресурсов верхнего регистра
        private ResourceManager _lowerChar; // файл ресурсов нижнего регистра
        public ObservableCollection<ButtonModel> ButtonCollection { get; set; }
        
        public ButtonViewModel(Grid grid)
        {
            ButtonCollection = new ObservableCollection<ButtonModel>();
            _upperChar = new ResourceManager("KeyboardTrainer.Resources.CharacterUpper", Assembly.GetExecutingAssembly());
            _lowerChar = new ResourceManager("KeyboardTrainer.Resources.CharacterLower", Assembly.GetExecutingAssembly());
            
            foreach (Grid b in grid.Children)
                foreach (Button button in b.Children)
                    ButtonCollection.Add(new ButtonModel
                    {
                        Button = button
                    });

            ButtonContentInitialization(_lowerChar);
        }
        public void ButtonContentInitialization(ResourceManager resource)
        {
            for (int i = 0; i < ButtonCollection.Count; i++)
            {
                ButtonCollection[i].Button.Content = resource.GetString(ButtonCollection[i].Button.Name);
            }
        }

    }
}
