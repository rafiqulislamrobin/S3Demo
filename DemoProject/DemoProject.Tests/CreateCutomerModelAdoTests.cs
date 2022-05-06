using Autofac.Extras.Moq;
using Custom.DataLayer;
using Demo.Api.Models;
using Moq;
using NUnit.Framework;
using Shouldly;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace DemoProject.Tests
{
    [ExcludeFromCodeCoverage]
    public class CreateCutomerModelAdoTests
    {
        private AutoMock _mock;
        private Mock<IRepository> _repositoryMock;
        private CreateCutomerModelAdo _createCutomerModelAdo;

        [OneTimeSetUp]
        public void ClassSetup()
        {
            _mock = AutoMock.GetLoose();
        }

        [OneTimeTearDown]
        public void ClassCleanup()
        {
            _mock?.Dispose();
        }

        [SetUp]
        public void TestSetup()
        {
            _createCutomerModelAdo = _mock.Create<CreateCutomerModelAdo>();
            _repositoryMock = _mock.Mock<IRepository>();
        }

        [TearDown]
        public void TestCleanup()
        {
            _repositoryMock?.Reset();
        }


        [Test, Category("Unit Test")]
        public async Task CreateCustomerSpAsync_CustomerNameNotFound_CreateCustomer()
        {
            //Arrange
            _createCutomerModelAdo.Age = 19;
            _createCutomerModelAdo.Name = "robin";
            _createCutomerModelAdo.Address = "abc";
            var entityName = string.Empty;

            var customer = new Customer
            {
                Name = _createCutomerModelAdo.Name,
                Age = _createCutomerModelAdo.Age,
                Address = _createCutomerModelAdo.Address,
            };

            _repositoryMock.Setup(x => x.AddCustomerSpAsync(It.Is<Customer>(y => y.Age == _createCutomerModelAdo.Age))).
            Returns(Task.CompletedTask).Verifiable();

            // Act
            await _createCutomerModelAdo.CreateCustomerSpAsync();

            // Assert
            _repositoryMock.VerifyAll();
        }

        [Test, Category("Unit Test")]
        public async Task CreateCustomerSpAsync_CustomerNameNotFound_ThrowException()
        {
            //Arrange
            _createCutomerModelAdo.Age = 19;
            _createCutomerModelAdo.Name = "";
            _createCutomerModelAdo.Address = "abc";
            var entityName = string.Empty;

            var customer = new Customer
            {
                Name = _createCutomerModelAdo.Name,
                Age = _createCutomerModelAdo.Age,
                Address = _createCutomerModelAdo.Address,
            };

            _repositoryMock.Setup(x => x.AddCustomerSpAsync(It.Is<Customer>(y => y.Age == _createCutomerModelAdo.Age))).
            Returns(Task.CompletedTask).Verifiable();


            //Act & Assert
            await Should.ThrowAsync<InvalidOperationException>(async
                () => await _createCutomerModelAdo!.CreateCustomerSpAsync());
        }

        [Test, Category("Unit Test")]
        public async Task CreateCustomer_CustomerNameNotFound_ThrowException()
        {
            //Arrange
            _createCutomerModelAdo.Age = 19;
            _createCutomerModelAdo.Name = "";
            _createCutomerModelAdo.Address = "abc";
            var entityName = string.Empty;

            var customer = new Customer
            {
                Name = _createCutomerModelAdo.Name,
                Age = _createCutomerModelAdo.Age,
                Address = _createCutomerModelAdo.Address,
            };

            _repositoryMock.Setup(x => x.AddCustomer(It.Is<Customer>(y => y.Age == _createCutomerModelAdo.Age), 
                It.IsAny<string>())).Verifiable();


            // Act
             _createCutomerModelAdo.CreateCustomer();

            // Assert
            _repositoryMock.VerifyAll();
        }
    }
}