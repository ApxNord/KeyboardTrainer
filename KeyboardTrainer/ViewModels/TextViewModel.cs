using KeyboardTrainer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardTrainer.ViewModels
{
    public class TextViewModel
    {
        private int i = 0;
        public TextModel TextModel { get; set; }
        public TextViewModel()
        {
            TextModel = new TextModel();
        }

        public void GenerationRandomText(int length)
        {
            TextModel.InText = "";
            TextModel.OutText = "";
            int[] onlyLowerText = { 97, 123 };
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    TextModel.OutText += (char)random.Next(onlyLowerText[0], onlyLowerText[1]);
                }
                if (i != 9) TextModel.OutText += " ";
            }
        }
        public void CorrectText(string c)
        {
            if (TextModel.OutText[i] == char.Parse(c))
            {
                TextModel.InText += c;
                i++;
            }
        }
    }
}
