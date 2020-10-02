using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ProvincialParks.CampingApp.Infrastructure.Interfaces;

namespace ProvincialParks.CampingApp.Infrastructure
{
    // Class Responsible reading camping trip expenses to from file
    public class TextFileReader : IFileReader
    {
        public IList<CampingTrip> allTrips {get; private set;}
        private int rowNumber = 0;

        public TextFileReader() 
        {
            allTrips = new List<CampingTrip>();
        }

        public IList<CampingTrip> ReadFile(string fileName)
        {                    
            var allLines = GetFileContents(fileName);
                
            if (allLines == null || allLines.Count() < 1)
                return null;

            var allLinesList = new List<string>(allLines);
            
            return ProcessFileContents(allLinesList);

        }

        private string[] GetFileContents(string fileName)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), @"InputOutput\" + fileName);
            if (! File.Exists(path))
            {
                return null;
            }
                
            return File.ReadAllLines(path);
        }

        private IList<CampingTrip> ProcessFileContents(List<string> allLinesList)
        {
             bool isEndofFileContents = false;
                

                while (!isEndofFileContents)
                {
                    if(Convert.ToInt32(allLinesList[rowNumber])==0)
                    {
                        isEndofFileContents = true;
                        break;
                    }

                    CampingTrip currentTrip = new CampingTrip(Convert.ToInt32(allLinesList[rowNumber]));
                    ProcessTrip(currentTrip, allLinesList);
                    allTrips.Add(currentTrip);
                    rowNumber++;
                }

                return allTrips;
        }

        private void ProcessTrip(CampingTrip currentTrip, List<string> allLinesList)
        {
            for (var tripPersonID = 1; tripPersonID <= currentTrip.NumberOfPeople; tripPersonID++)
            {   
                rowNumber++;
                ProcessExpensess(currentTrip, allLinesList, tripPersonID);          
            }
        }

        private void ProcessExpensess(CampingTrip currentTrip, List<string> allLinesList, int tripPersonID)
        {
            int personNumberOfExpenses = Convert.ToInt32(allLinesList[rowNumber]);
            for (var personExpenseIndex = 1; personExpenseIndex <= personNumberOfExpenses; personExpenseIndex++)
            {
                rowNumber++;
                currentTrip.Expenses.Add(new Expense(tripPersonID, Convert.ToDecimal(allLinesList[rowNumber])));
            }     
        }
    }
}
