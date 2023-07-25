using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace KeyboardTrainer
{
    public class ButtonViewModel
    {
        private ResourceManager _upperChar; // файл ресурсов верхнего регистра
        private ResourceManager _lowerChar; // файл ресурсов нижнего регистра
        public Dictionary<string, ButtonModel> Buttons { get; set; }
        private Dictionary<ButtonModel, Style> _originalButtonStyle;
        public ButtonViewModel(Grid grid)
        {
            Buttons = new Dictionary<string, ButtonModel>();
            _originalButtonStyle = new Dictionary<ButtonModel, Style>();
            _upperChar = new ResourceManager("KeyboardTrainer.Resources.CharacterUpper", Assembly.GetExecutingAssembly());
            _lowerChar = new ResourceManager("KeyboardTrainer.Resources.CharacterLower", Assembly.GetExecutingAssembly());

            foreach (Grid b in grid.Children)
                foreach (Button button in b.Children)
                {
                    Buttons.Add(button.Name, new ButtonModel() { Button = button });
                }


            ButtonContentInitialization();
        }
        public void ButtonContentInitialization(bool isUpper = false)
        {
            ResourceManager resource = (isUpper) ? _upperChar : _lowerChar;
            for (int i = 0; i < Buttons.Count; i++)
                Buttons[Buttons.Keys.ElementAt(i)].Button.Content =
                    resource.GetString(Buttons[Buttons.Keys.ElementAt(i)].Button.Name);
        }
        public string PressButtonDown(Key key)
        {

            if (!_originalButtonStyle.ContainsKey(Buttons[key.ToString()]))
                _originalButtonStyle.Add(Buttons[key.ToString()],
                    Buttons[key.ToString()].Button.Style);

            Buttons[key.ToString()].Button.Style =
                (Style)Application.Current.Resources["PressButtonColor"];

            return Buttons[key.ToString()].Button.Content.ToString();
        }
        public void PressButtonUp(Key key)
        {
            try
            {
                if (_originalButtonStyle.ContainsKey(Buttons[key.ToString()]))
                {
                    Buttons[key.ToString()].Button.Style =
                        _originalButtonStyle[Buttons[key.ToString()]];
                    _originalButtonStyle.Remove(Buttons[key.ToString()]);
                }
            } catch (KeyNotFoundException e) { }
        }
    }
}
