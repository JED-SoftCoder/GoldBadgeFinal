using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartInsuranceChallenge;
using System;

namespace SmartInsuranceRepoTests
{
    [TestClass]
    public class DataRepoTests
    {
        private Data _data;
        private DataRepo _repo;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new DataRepo();
            _data = new Data(1234, 1, 1, 1, 1);
            _repo.AddDataToList(_data);
        }
        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            Data data = new Data();
            data.PolicyNumber = 8921;
            DataRepo repository = new DataRepo();
            repository.AddDataToList(data);
            Data dataFromDirectory = repository.GetDataByPolicyNumber(8921);
            Assert.IsNotNull(dataFromDirectory);
        }
        [TestMethod]
        public void GetDataList_ShouldGetNotNull()
        {
            Data data = new Data();
            data.PolicyNumber = 8921;
            DataRepo repository = new DataRepo();
            repository.AddDataToList(data);
            Assert.IsNotNull(repository.GetDataList());
        }
        [TestMethod]
        public void UpdateExisitingData_ShouldReturnTrue()
        {
            Data newData = new Data(5643, 1, 1, 1, 4);
            bool updateResult = _repo.UpdateExistingData(1234, newData);
            Assert.IsTrue(updateResult);
        }
        [TestMethod]
        public void DeleteExisitingData_ShouldReturnTrue()
        {
            bool wasDeleted = _repo.DeleteDataFromList(1234);
            Assert.IsTrue(wasDeleted);
        }
    }
}
