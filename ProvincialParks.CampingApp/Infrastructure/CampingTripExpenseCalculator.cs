using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProvincialParks.CampingApp.Infrastructure;
using ProvincialParks.CampingApp.Infrastructure.Interfaces;

namespace ProvincialParks.CampingApp.Infrastructure
{
    // Class Responsible for Processing Expneses relating to Camping Trips
    public class CampingTripExpenseCalculator : IExpenseCalculator
    {
        static string filePath;
        private IFileReader FileReader { get;  set; }
        private IFileWriter FileWriter { get; set; }

        public CampingTripExpenseCalculator(IFileReader fileReader)
        {
            FileReader = fileReader;
        }

        public void CalculateExpenses(string lineRead)
        {
            try
            {
                filePath = lineRead;
                
                var campingTrips = FileReader.ReadFile(filePath);
                if (campingTrips != null && campingTrips.Count > 0)
                {
                    FileWriter = new TextFileWriter(filePath);
                    FileWriter.WriteFile(campingTrips);
                }
                else
                {
                    Console.WriteLine("No trips found in file or file not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing file");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
