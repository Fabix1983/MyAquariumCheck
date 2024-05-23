using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyAquariumCheck.ViewModels
{
    public class CheckItemVM : INotifyPropertyChanged
    {
        public long Id { get; set; }
        public DateTime Data { get; set; }
        public int Temperatura { get; set; }
        public string PH { get; set; }
        public string GH { get; set; }
        public string KH { get; set; }
        public string NO2 { get; set; }
        public string NO3 { get; set; }

        private bool _eseguito;
        public bool Eseguito
        {
            get { return _eseguito; }
            set
            {
                _eseguito = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
