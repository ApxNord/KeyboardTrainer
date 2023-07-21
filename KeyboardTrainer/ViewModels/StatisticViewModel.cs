using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardTrainer
{
    public class StatisticViewModel
    {       
        public StatisticModel StatisticModel { get; set; }
        
        public StatisticViewModel()
        {
            StatisticModel = new StatisticModel();
        }
        public string GenerationRandomText()
        {
            int[] onlyLowerText = { 97, 123 };
            Random random = new Random();
            string text = string.Empty;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < StatisticModel.Diff; j++)
                {
                    text += (char)random.Next(onlyLowerText[0], onlyLowerText[1]);
                }
                text += " ";
            }
            return text;
        }
    }
}
