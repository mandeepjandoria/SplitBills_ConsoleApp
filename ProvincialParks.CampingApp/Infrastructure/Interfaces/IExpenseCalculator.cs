using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvincialParks.CampingApp.Infrastructure.Interfaces
{
    interface IExpenseCalculator
    {
        void CalculateExpenses(string lineRead);
    }
}
