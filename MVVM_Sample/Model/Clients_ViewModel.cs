using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM_Sample.Model
{
    public class Clients_ViewModel : INotifyPropertyChanged
    {
        // "каскад" модели
        public class Client : INotifyPropertyChanged
        {
            private string firstName;
            private string lastName;
            private string middleName;
            private string cityStreet;
            private string telephone;
            private string date;
            private int gager;

            public string FirstName
            {
                get { return firstName; }
                set
                {
                    firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
            public string LastName
            {
                get { return lastName; }
                set
                {
                    lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
            public string MiddleName
            {
                get { return middleName; }
                set
                {
                    middleName = value;
                    OnPropertyChanged("MiddleName");
                }
            }
            public string CityStreet
            {
                get { return cityStreet; }
                set
                {
                    cityStreet = value;
                    OnPropertyChanged("CityStreet");
                }
            }
            public string Telephone
            {
                get { return telephone; }
                set
                {
                    telephone = value;
                    OnPropertyChanged("Telephone");
                }
            }
            public string Date
            {
                get { return date; }
                set
                {
                    date = value;
                    OnPropertyChanged("Date");
                }
            }
            public int Gager
            {
                get { return gager; }
                set
                {
                    gager = value;
                    OnPropertyChanged("Gager");
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged([CallerMemberName]string prop = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            }
        }

        // сама коллекция этих моделей
        public ObservableCollection<Client> Clients { get; set; }
        public Clients_ViewModel()
        {
            Clients = new ObservableCollection<Client>()
            {
                new Client
                {
                    FirstName = "Иванов",
                    MiddleName = "Иван",
                    LastName = "Иванович",
                    CityStreet = "Загорная",
                    Telephone = "8-919-111-34-34",
                    Date = "0.0",
                    Gager = 0
                },

                new Client
                {
                    FirstName = "Сидоров",
                    MiddleName = "Сидр",
                    LastName = "Сидорович",
                    CityStreet = "Огородная",
                    Telephone = "8-929-222-54-44",
                    Date = "0.0",
                    Gager = 0
                },

                new Client
                {
                    FirstName = "Петров",
                    MiddleName = "Петр",
                    LastName = "Петорович",
                    CityStreet = "Радищева",
                    Telephone = "8-939-333-64-54",
                    Date = "0.0",
                    Gager = 0
                },

                new Client
                {
                    FirstName = "Игнатенко",
                    MiddleName = "Игнат",
                    LastName = "Игнатович",
                    CityStreet = "Первомайская",
                    Telephone = "8-949-444-74-64",
                    Date = "0.0",
                    Gager = 0
                },

                new Client
                {
                    FirstName = "Узбатов",
                    MiddleName = "Узбат",
                    LastName = "Узбатович",
                    CityStreet = "Мира",
                    Telephone = "8-959-555-84-74",
                    Date = "0.0",
                    Gager = 0
                }
            };
        }

        // -- Выбор одной модели из коллекции. -- //
        // -- Применяемо в Listbox и Combobox с помощью Bind'ов -- //
        private Client selectedClient;
        public Client SelectedClient
        {
            get { return selectedClient; }
            set
            {
                selectedClient = value;
                OnPropertyChanged("SelectedClient");
            }
        }
        // -- конец -- //

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
