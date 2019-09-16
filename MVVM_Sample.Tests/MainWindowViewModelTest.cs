using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVVM_Sample.ViewModel;
using MVVM_Sample.Model;
using System.Collections.ObjectModel;

//using Client = MVVM_Sample.Model.Clients_ViewModel.Client;

namespace MVVM_Sample.Tests
{
    // Класс содержит тесты для проверки работы MainViewModel
    [TestClass]
    public class MainWindowViewModelTest
    {

        public MainWindowViewModelTest()
        {
        }

        // Тест для проверки свойства Clients.
        // Проверка коллекции на пустоту элементов в ней
        [TestMethod]
        public void ClientsPropertyTest()
        {
            MainWindowViewModel viewModel = new MainWindowViewModel();
            Assert.IsNotNull(viewModel.Clients);
        }

        // Тест для проверки свойства Measurements.
        // Проверка коллекции на пустоту элементов в ней
        [TestMethod]
        public void MeasurementsPropertyTest()
        {
            MainWindowViewModel viewModel = new MainWindowViewModel();
            Assert.IsNotNull(viewModel.Measurements);
        }

        // Тест для добавления записи замера
        [TestMethod]
        public void RecordMeasurementTest()
        {
            MainWindowViewModel viewModel = new MainWindowViewModel();

            Client clientEdit = new Client
            {
                FirstName = "Иванов",
                LastName = "Иван",
                MiddleName = "Иванович",
                CityStreet = "Загорная",
                Telephone = "8-919-111-34-34",
                Date = "10.07",
                Gager = 1
            };

            viewModel.CurrentClient.Date = "10.07";
            viewModel.CurrentClient.Telephone = "8-919-111-34-34";
            
            //viewModel.RecordMeasurement.Execute(null);
            //viewModel.RecordMeasurement.CanExecute(null);
            viewModel.DataGridEdit();

            CollectionAssert.Contains(viewModel.Clients, clientEdit);
        }
    }
}
