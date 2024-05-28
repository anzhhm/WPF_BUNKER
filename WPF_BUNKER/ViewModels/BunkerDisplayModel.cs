using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_BUNKER.Models
{
    
        public class BunkerDisplayModel
        {
            public int NumOfPlayers { get; set; }
            public int NumOfSurvivors { get; set; }

            public BunkerDisplayModel(int numOfPlayers, int numOfSurvivors)
            {
                NumOfPlayers = numOfPlayers;
                NumOfSurvivors = numOfSurvivors;
            }
        }
    
}
