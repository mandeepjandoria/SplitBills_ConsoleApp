using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvincialParks.CampingApp.Infrastructure.Interfaces
{
    public interface IFileReader
    {
        IList<CampingTrip> ReadFile(string fileName);
    }
}
