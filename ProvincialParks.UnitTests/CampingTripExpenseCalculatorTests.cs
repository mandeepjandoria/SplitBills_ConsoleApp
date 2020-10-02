using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProvincialParks.CampingApp.Infrastructure;
using ProvincialParks.CampingApp.Infrastructure.Interfaces;
using System.Collections.Generic;

namespace ProvincialParks.UnitTests
{
    [TestClass]
    public class CampingTripExpenseCalculatorTests
    {
        [TestMethod]
        public void CalculateExpenses_ShouldInvokeReadFile_WhenReadLine()
        {
            //Arrange
            IList<CampingTrip> trips = new List<CampingTrip>();
            var fileReader = new Mock<IFileReader>();
            fileReader.Setup(x => x.ReadFile(It.IsAny<string>())).Returns(trips);

            //Act
            var expenseCalculator = new CampingTripExpenseCalculator(fileReader.Object);
            expenseCalculator.CalculateExpenses("anystring");

            //Assert
            fileReader.Verify(m => m.ReadFile(It.IsAny<string>()), Times.Once());

        }
    }
}
