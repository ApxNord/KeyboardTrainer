using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardTrainer
{
    public class StatisticModel : INotifyPropertyChanged
    {

        private int _speed; // скорость набора текста
        private int _fails; // кол-во ошибок
        private int _diff; // длина слова

        public int Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value;
                OnPropertyChanged("Speed");
            }
        }
        public int Fails
        {
            get
            {
                return _fails;
            }
            set
            {
                _fails = value;
                OnPropertyChanged("Fails");
            }
        }
        public int Diff
        {
            get
            {
                return _diff;
            }
            set
            {
                _diff = value;
                OnPropertyChanged("Diff");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
