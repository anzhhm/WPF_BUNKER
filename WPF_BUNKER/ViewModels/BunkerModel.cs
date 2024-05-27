using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_BUNKER.ViewModels
{
    public class BunkerModel
    {
        public int NumOfPlayers { get; set; }
        public int NumOfSurvivors { get; set; }

        public BunkerModel(int numOfPlayers, int numOfSurvivors)
        {
            NumOfPlayers = numOfPlayers;
            NumOfSurvivors = numOfSurvivors;
        }
    }
}
