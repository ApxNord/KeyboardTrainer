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
    }
}
