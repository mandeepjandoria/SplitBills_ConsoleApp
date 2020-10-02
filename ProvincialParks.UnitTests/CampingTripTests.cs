using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProvincialParks.CampingApp.Infrastructure;

namespace ProvincialParks.UnitTests
{
    [TestClass]
    public class CampingTripTests
    {
        [TestMethod]
        public void TotalExpenses_ShouldReturnTotalPerTrip_WhenValuesInList()
        {
            //act
            var campingTrip = new CampingTrip(2);
            campingTrip.Expenses.Add(new Expense(1, 0.50m));
            campingTrip.Expenses.Add(new Expense(1, 0.5m));
            campingTrip.Expenses.Add(new Expense(2, 1.50m));
            campingTrip.Expenses.Add(new Expense(2, 99m));

            //assert
            Assert.AreEqual(campingTrip.NumberOfPeople, 2);
            Assert.AreEqual(campingTrip.TotalExpenses, 101.5m);
        }

        [TestMethod]
        public void GetAmountOwedPerPerson_ShouldReturnTotalOwedByPerson_WhenValuesInList()
        {
            //act
            var campingTrip = new CampingTrip(3);
            campingTrip.Expenses.Add(new Expense(1, 10m));
            campingTrip.Expenses.Add(new Expense(1, 20m));
            campingTrip.Expenses.Add(new Expense(2, 15m));
            campingTrip.Expenses.Add(new Expense(2, 15.01m));
            campingTrip.Expenses.Add(new Expense(2, 3m));
            campingTrip.Expenses.Add(new Expense(2, 3.01m));
            campingTrip.Expenses.Add(new Expense(3, 5m));
            campingTrip.Expenses.Add(new Expense(3, 9m));
            campingTrip.Expenses.Add(new Expense(3, 4m));

            //assert
            Assert.AreEqual(campingTrip.NumberOfPeople, 3);
            Assert.AreEqual(campingTrip.GetAmountOwedPerPerson(1), -1.99m);
            Assert.AreEqual(campingTrip.GetAmountOwedPerPerson(2), -8.01m);
            Assert.AreEqual(campingTrip.GetAmountOwedPerPerson(3), 10.01m);
        }
    }
}
