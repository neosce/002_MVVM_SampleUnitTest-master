using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM_Sample.Model
{
    public class Measurement_ViewModel : INotifyPropertyChanged
    {

        public class Measurement : INotifyPropertyChanged
        {
            private string dateM;
            private int gagerM;

            public string DateM
            {
                get { return dateM; }
                set
                {
                    dateM = value;
                    OnPropertyChanged("DateM");
                }
            }

            public int GagerM
            {
                get { return gagerM; }
                set
                {
                    gagerM = value;
                    OnPropertyChanged("GagerM");
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged([CallerMemberName]string prop = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            }

        }

        // сама коллекция этих моделей
        public ObservableCollection<Measurement> Measurements { get; set; }
        public Measurement_ViewModel()
        {
            Measurements = new ObservableCollection<Measurement>()
            {
                new Measurement
                {
                    DateM = "10.07",
                    GagerM = 1
                    
                },

                new Measurement
                {
                    DateM = "11.07",
                    GagerM = 2

                },

                new Measurement
                {
                    DateM = "12.07",
                    GagerM = 2

                },

                new Measurement
                {
                    DateM = "13.07",
                    GagerM = 3

                },
            };
        }

        private Measurement selectedMeasurement;
        public Measurement SelectedMeasurement
        {
            get { return selectedMeasurement; }
            set
            {
                selectedMeasurement = value;
                OnPropertyChanged("SelectedMeasurement");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
