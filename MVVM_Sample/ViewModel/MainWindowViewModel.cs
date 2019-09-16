using System.Collections.ObjectModel;
using MVVM_Sample.Model;
using System.Windows.Input;
using MVVM_Sample.Infrastructure;
using System.Windows;
using System.Linq;

namespace MVVM_Sample.ViewModel
{
    // enum - отдает значения по возрастанию для переменных в нем
    // 
    public enum SearchingResult
    {
        Access,
        ClientNotExist,
        EmployeeBusy,
        ClientBusy
    }

    public partial class MainWindowViewModel : ViewModelBase
    {
        // инициализация класса моделей (хранится obervablecollection)
        public Clients_ViewModel ClientsContainer = new Clients_ViewModel();
        // хранилище (а конструкторе ниже передаём от ClientsContainer).
        //нужно для Bind'а
        public ObservableCollection<Clients_ViewModel.Client> Clients { get; set; }

        public Measurement_ViewModel MeasurementContainer = new Measurement_ViewModel();
        public ObservableCollection<Measurement_ViewModel.Measurement> Measurements { get; set; }

        private string Date;
        public string SDate
        {
            get
            {
                return Date;
            }
            set
            {
                Date = value;
                OnPropertyChanged("SDate");
            }
        }

        private string Phone;
        public string SPhone
        {
            get
            {
                return Phone;
            }
            set
            {
                Phone = value;
                OnPropertyChanged("SPhone");
            }
        }

        public MainWindowViewModel()
        {
            Clients = ClientsContainer.Clients;
            Measurements = MeasurementContainer.Measurements;
        }

        RelayCommand _recordMeasurement;
        // Записать замерщика в таблицу
        public ICommand RecordMeasurement
        {
            get
            {
                if (_recordMeasurement == null)
                    _recordMeasurement = new RelayCommand(ExecuteRecordMeasurement, CanExecuteRecordMeasurement);
                return _recordMeasurement;
            }
        }

        private void ExecuteRecordMeasurement(object parameter)
        {
            DataGridEdit();
            SDate = null;
            SPhone = null;
        }
        
        public void DataGridEdit()
        {
            // это всё LINQ
            // -- старт -- //
            Measurement_ViewModel.Measurement FreeDate = null;
            var EmployeesCollection = from obj in Measurements
                                      where obj.DateM == SDate
                                      where obj.GagerM != 0
                                      select obj;
            foreach (Measurement_ViewModel.Measurement elDoM in EmployeesCollection.ToArray())
            {
                FreeDate = elDoM;
                break;
            }

            SearchingResult Result = SearchingResult.ClientNotExist;
            var ClientsCollection = from obj in Clients
                                 where obj.Telephone == SPhone
                                 select obj;
            foreach (Clients_ViewModel.Client Client in ClientsCollection.ToArray())
            {
                if (FreeDate != null)
                {
                    if (Client.Gager == 0)
                    {
                        Result = SearchingResult.Access;
                        Client.Date = FreeDate.DateM;
                        Client.Gager++;
                        FreeDate.GagerM--;
                    }
                    else
                        Result = SearchingResult.ClientBusy;
                }
                else
                    Result = SearchingResult.EmployeeBusy;
                break;
            }
            // -- конец -- //

            switch (Result)
            {
                case SearchingResult.ClientNotExist:
                    MsgShowError("Клиента нет в базе!");
                    break;

                case SearchingResult.EmployeeBusy:
                    MsgShowError("Нет свободных замерщиков!");
                    break;

                case SearchingResult.ClientBusy:
                    MsgShowError("Клиент уже на обслуживании!");
                    break;

                default: break;
            }
        }

        public bool MsgShowError(string msg)
        {
            if (msg == null)
            {
                return false;
            }
            _ = MessageBox.Show(msg, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return true;
        }

        private bool CanExecuteRecordMeasurement(object parameter)
        {
            if (string.IsNullOrEmpty(SDate) &&
                string.IsNullOrEmpty(SPhone))
            {
                
                return false;
            }
            return true;
        }

        protected override void OnDispose()
        {
            Clients.Clear();
            Measurements.Clear();
        }

        // Проверка теста на работу
        public bool ClientExistCheker(Clients_ViewModel.Client SomeClient)
        {

            var ItIsCheker = from obj in Clients
                             where obj.CityStreet == SomeClient.CityStreet
                             where obj.Date == SomeClient.Date
                             where obj.FirstName == SomeClient.FirstName
                             where obj.Gager == SomeClient.Gager
                             where obj.LastName == SomeClient.LastName
                             where obj.MiddleName == SomeClient.MiddleName
                             where obj.Telephone == SomeClient.Telephone
                           select obj;

            foreach (Clients_ViewModel.Client client in ItIsCheker.ToArray())
                return true;
            return false;

        }

    }
}
