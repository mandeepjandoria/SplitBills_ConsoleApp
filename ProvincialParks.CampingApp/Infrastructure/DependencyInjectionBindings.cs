using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using Ninject;
using ProvincialParks.CampingApp.Infrastructure.Interfaces;

namespace ProvincialParks.CampingApp.Infrastructure
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IExpenseCalculator>().To<CampingTripExpenseCalculator>();
            Bind<IFileReader>().To<TextFileReader>();
        }
    }
}
