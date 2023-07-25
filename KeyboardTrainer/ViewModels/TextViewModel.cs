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
        private readonly int _wordCount = 10;
        private readonly int[] _onlyLowerText = { 97, 123 };
        private readonly int[] _onlyUpperText = { 65, 91 };
        public TextModel TextModel { get; set; }
        public TextViewModel()
        {
            TextModel = new TextModel();
        }

        public void GenerationRandomText(int length, bool isWithUpper)
        {
            TextModel.InText = string.Empty;
            TextModel.OutText = string.Empty;
            
            int u = isWithUpper ? 2 : 1;

            Random random = new Random();
            for (int i = 0; i < _wordCount; i++)
            {
                int l = random.Next(3, length+1);
                for (int j = 0; j < l; j++)
                {
                    if (random.Next(u) == 0)
                    {
                        TextModel.OutText += (char)random.Next(_onlyLowerText[0], _onlyLowerText[1]);
                    }
                    else
                    {
                        TextModel.OutText += (char)random.Next(_onlyUpperText[0], _onlyUpperText[1]);
                    }
                }
                if (i != 9) TextModel.OutText += " ";
            }
        }
        public bool IsCorrectText(string c)
        {
            try
            {
                if (TextModel.OutText[i] == char.Parse(c))
                {
                    TextModel.InText += c;
                    i++;
                    return true;
                }
                
            }catch (FormatException e) { throw; }
            
            return false;
        }
        public bool IsFinishText()
        {
            return (TextModel.InText.Length == TextModel.OutText.Length) ? true : false;
        }
    }
}
