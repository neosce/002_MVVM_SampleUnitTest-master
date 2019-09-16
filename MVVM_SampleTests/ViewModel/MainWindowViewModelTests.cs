using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MVVM_Sample.ViewModel.Tests
{
    [TestClass()]
    public class MainWindowViewModelTests
    {

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

        [TestMethod]
        public void ClientExistCheker()
        {

            MainWindowViewModel viewModel = new MainWindowViewModel();

            Model.Clients_ViewModel.Client someClient = new Model.Clients_ViewModel.Client()
            {
                FirstName = "Иванов",
                MiddleName = "Иван",
                LastName = "Иванович",
                CityStreet = "Загорная",
                Telephone = "8-919-111-34-34",
                Date = "10.07",
                Gager = 1
            };

            viewModel.SDate = "10.07";
            viewModel.SPhone = "8-919-111-34-34";
            viewModel.DataGridEdit();

            if (!viewModel.ClientExistCheker(someClient))
                Assert.Fail();
            
        }

    }
}