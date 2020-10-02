using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvincialParks.CampingApp.Infrastructure
{
    // Class container object for a single expense instance
    public class Expense
    {
        public int PersonID {get; private set;}
        public decimal Amount { get; private set; }

        public Expense (int personID, decimal amount)
        {
            PersonID = personID;
            Amount = amount;
        }
    }
}
