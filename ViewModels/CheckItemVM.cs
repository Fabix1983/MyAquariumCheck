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
        public decimal PH { get; set; }
        public decimal GH { get; set; }
        public decimal KH { get; set; }
        public decimal NO2 { get; set; }
        public decimal NO3 { get; set; }

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
