using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayParking;
using PayParking.Useful;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayParking.Tests
{
    [TestClass()]
    public class ParkingOperationsTests
    {
        [TestMethod()]
        public void AddCar_CorrectValue_ShouldReturnSucces()
        {
            //Arrange
            ParkingOperations operations = new ParkingOperations();
            string carNumber = "B24FGT";
            string key = "56";
            //Act
            var result = operations.AddCar(carNumber, key);

            //Assert
            Assert.AreEqual(result, Warnings.Succes);

        }
        [TestMethod()]
        public void AddCar_DuplicateCar_ShouldReturnWarning()
        {
            //Arrange
            ParkingOperations operations = new ParkingOperations();
            string carNumber = "B24FGT";
            string key = "56";
            //Act
            operations.AddCar(carNumber, key);
            var result= operations.AddCar(carNumber,key);

            //Assert
            Assert.AreEqual(result, Warnings.Duplicate);

        }

        [TestMethod()]
        public void AddCar_CapacityReached_ShouldReturnWarning()
        {
            //Arrange
            ParkingOperations operations = new ParkingOperations();
            string carNumber = "B24FGT";
            string key = "56";
            operations.Capacity = 4;
            for(int i = 0; i < operations.Capacity; i++)
            {
                operations.AddCar(String.Concat(i,carNumber), String.Concat(i, key));
            }

            //Act
            operations.AddCar(carNumber, key);
            var result = operations.AddCar(carNumber, key);

            //Assert
            Assert.AreEqual(result, Warnings.FullParking);
        }

        [TestMethod()]
        public void AddCar_NullValue_ShouldReturnWarning()
        {
            //Arrange
            ParkingOperations operations = new ParkingOperations();
            string carNumber =null;
            string key = "56";
            //Act
            operations.AddCar(carNumber, key);
            var result = operations.AddCar(carNumber, key);

            //Assert
            Assert.AreEqual(result, Warnings.Null);

        }

        [TestMethod()]
        public void RemoveCar_WrongKey_ShouldReturnWarning()
        {
            //Arrange
            ParkingOperations operations = new ParkingOperations();
            string carNumber = "B24FGT";
            string key = "56";
            string differentKey = "89";
            DateTime arrivalTime = DateTime.Now.Subtract(new TimeSpan(1, 2, 34));
            //Act
            operations.AddCar(carNumber, key);
            var result = operations.RemoveCar(carNumber, differentKey, ref arrivalTime);

            //Assert
            Assert.AreEqual(result, Warnings.InvalidKey);
        }

        [TestMethod()]
        public void RemoveCar_CorrectKey_ShouldReturnSucces()
        {
            //Arrange
            ParkingOperations operations = new ParkingOperations();
            string carNumber = "B24FGT";
            string key = "56";
            DateTime arrivalTime = DateTime.Now.Subtract(new TimeSpan(1, 2, 34));
            //Act
            operations.AddCar(carNumber, key);
            var result = operations.RemoveCar(carNumber, key, ref arrivalTime);

            //Assert
            Assert.AreEqual(result, Warnings.Succes);
        }

        [TestMethod()]
        public void RemoveCar_NoCar_ShouldReturnWarning()
        {
            //Arrange
            ParkingOperations operations = new ParkingOperations();
            string carNumber = "B24FGT";
            string differentCarNumber = "CT52OLI";
            string key = "56";
            DateTime arrivalTime = DateTime.Now.Subtract(new TimeSpan(1, 2, 34));
            //Act
            operations.AddCar(carNumber, key);
            var result = operations.RemoveCar(differentCarNumber, key, ref arrivalTime);

            //Assert
            Assert.AreEqual(result, Warnings.NoCar);
        }

        [TestMethod()]
        public void RemoveCar_NullValue_ShouldReturnWarning()
        {
            //Arrange
            ParkingOperations operations = new ParkingOperations();
            string carNumber = null;
            string key = "56";
            DateTime arrivalTime = DateTime.Now.Subtract(new TimeSpan(1, 2, 34));
            //Act
            operations.RemoveCar(carNumber, key,ref arrivalTime);
            var result = operations.AddCar(carNumber, key);

            //Assert
            Assert.AreEqual(result, Warnings.Null);

        }


    }
}      