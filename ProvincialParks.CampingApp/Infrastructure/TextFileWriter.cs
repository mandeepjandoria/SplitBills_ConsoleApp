using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ProvincialParks.CampingApp.Infrastructure.Interfaces;

namespace ProvincialParks.CampingApp.Infrastructure
{
    // Class Responsible writing camping trip expenses to text file
    public class TextFileWriter : IFileWriter
    {
        private string FileName { get; set; }

        public TextFileWriter(string fileName)
        {
            FileName = fileName;
        }

        public void WriteFile(IList<CampingTrip> trips)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), @"InputOutput\" + FileName + ".out");
            using (TextWriter tw = new StreamWriter(path))
            {
                foreach (CampingTrip trip in trips)
                {
                    WritePesonExpense(trip, tw);
                    tw.WriteLine("");
                }
            }
        }

        private void WritePesonExpense(CampingTrip trip, TextWriter tw)
        {
            for (var person = 1; person <= trip.NumberOfPeople; person++)
            {
                tw.WriteLine(trip.GetAmountOwedPerPerson(person) > 0 ? "$" + trip.GetAmountOwedPerPerson(person).ToString() : string.Format("(${0})", Math.Abs(trip.GetAmountOwedPerPerson(person)).ToString()));
            }
        }
    }
}
