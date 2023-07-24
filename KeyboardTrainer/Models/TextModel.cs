using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardTrainer.Models
{
    public class TextModel : INotifyPropertyChanged
    {

        private string _inText;
        private string _outText;

        public string InText
        {
            get
            {
                return _inText;
            }
            set
            {
                _inText = value;
                OnPropertyChanged("InText");
            }
        }
        public string OutText
        {
            get
            {
                return _outText;
            }
            set
            {
                _outText = value;
                OnPropertyChanged("OutText");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
