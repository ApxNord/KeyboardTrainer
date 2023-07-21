using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KeyboardTrainer
{
    public class ButtonModel //: INotifyPropertyChanged
    {       
        /*private Button _button;
        public Button Button
        {
            get { return _button; }
            set
            {
                _button = value;
                OnPropertyChanged(nameof(Button));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }*/
        public Button Button { get; set; }
    }
}
