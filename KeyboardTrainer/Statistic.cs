using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardTrainer
{
    /// <summary>
    /// Для хранения и изменения данных по статистике прогресса
    /// </summary>
    /// <param name="Speed">скорость набора символов в минуту</param>
    /// <param name="Fails">Количество допущенных ошибок</param>
    /// <param name="Diff">Устанавливаемый максимум длины слов</param>
    public class Statistic : INotifyPropertyChanged
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

        public string GenerationRandomText()
        {
            int[] onlyLowerText = { 97, 123 };
            Random random = new Random();
            string text = string.Empty;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < Diff; j++)
                {
                    text += (char)random.Next(onlyLowerText[0], onlyLowerText[1]);
                }
                text += " ";
            }
            return text;
        }
    }
}
