using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPF_BUNKER.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private int numberOfPlayers;
        private int numberOfSurvivors;

        public int NumberOfPlayers
        {
            get { return numberOfPlayers; }
            set
            {
                numberOfPlayers = value;
                OnPropertyChanged();
            }
        }

        public int NumberOfSurvivors
        {
            get { return numberOfSurvivors; }
            set
            {
                numberOfSurvivors = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
